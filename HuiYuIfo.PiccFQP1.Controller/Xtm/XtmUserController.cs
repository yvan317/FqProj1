using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Controller;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Service.Xtm;
using NPOI.SS.UserModel;

namespace HuiYuIfo.PiccFQP1.Controller.Xtm
{
    public class XtmUserController:BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                case "resetPwd":
                    ResetPwd(task, ref errmsg);
                    break;
                case "export":
                    Export(task, ref errmsg);
                    break;
                case "upri":
                    task.Width = 500;
                    task.Height = 600;
                    task.PagePath = "MenuPriEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "uywpri":
                    task.Width = 700;
                    task.Height = 600;
                    task.PagePath = "UserPriEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "ucreate":
                    task.PagePath = "UserEdit.aspx";
                    task.Width = 700;
                    task.Height = 300;
                    break;
                case "uedit":
                    task.PagePath = "UserEdit.aspx";
                    task.Width = 700;
                    task.Height = 300;
                    task.PageParam = task.CommandArgument;
                    break;
                case "ushow":
                    task.PagePath = "UserShow.aspx";
                    task.Width = 700;
                    task.Height = 300;
                    task.PageParam = task.CommandArgument;
                    break;
                case "udelete":
                    Delete(task, ref errmsg);
                    break;
                case "save":
                    Save(task, ref errmsg);
                    break;
            }
            return true;
        }
        private void ResetPwd(Framework.Task.Task task, ref string errmsg)
        {
            BaseDao baseDao=new BaseDao();
            XtmUser user = new XtmUser();
            user.Did = int.Parse(task.CommandArgument);
            user = baseDao.Get(user);
            if (user == null)
            {
                errmsg = "没有找到用户信息";
                return;
            }
            else
            {
                user.UserPwd = HuiYuIfo.Framework.Library.Encry.Encode(user.UserCode + "123");
                baseDao.Update(user);
               
                errmsg = "重置成功,密码为用户编码+123";
            }
        }
        private void Export(Framework.Task.Task task, ref string errmsg)
        {
            XtmUserService service1 = new XtmUserService();
            IWorkbook book = service1.ExportData(ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        private bool Save(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            BaseDao baseDao = new BaseDao();
            XtmUser entity = task.Entity as XtmUser;
            XtmUserService service = new XtmUserService();
            result = service.Validate("all", entity, ref errmsg);
            if (result == false)
            {
                return false;
            }
            if (entity.Did > 0)
            {
                baseDao.Update(entity);
            }
            else
            {
                XtmUser temp = new XtmUser();
                temp.UserCode = entity.UserCode;
                int count = baseDao.Count(temp);
                if (count > 0)
                {
                    errmsg = "该人员代码已经被使用";
                    return false;
                }
                entity.UserPwd = HuiYuIfo.Framework.Library.Encry.Encode(entity.UserCode + "123");
                baseDao.Insert(entity);
            }
           
            if (result == true)
            {
                errmsg = "保存成功";
                task.ParentRebind = true;
                task.IsClose = true;
            }
            return result;
        }
        private bool Delete(Framework.Task.Task task, ref string errmsg)
        {
            XtmUser delModel = new XtmUser();
            delModel.SysKey = task.CommandArgument;
            BaseDao baseDao = new BaseDao();
            this.BeginTran();
            try
            {
                XtmMenuPri delMenuPri = new XtmMenuPri();
                delMenuPri.UserId = int.Parse(task.CommandArgument);
                baseDao.Delete(delMenuPri);

                XtmUserPri delUserPri = new XtmUserPri();
                delUserPri.UserId = int.Parse(task.CommandArgument);
                baseDao.DeleteUdf("XtmUserPriDeleteAll", delUserPri);

                baseDao.Delete(delModel);
                this.CommitTran();
            }
            catch(Exception ex)
            {
                this.RollbackTran();
                errmsg = ex.Message;
                return false;
            }
            if (errmsg != "")
            {
                return false;
            }
            errmsg = "删除成功";
            task.Rebind = true;
            return true;
        }
    }
}
