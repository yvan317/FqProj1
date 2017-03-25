using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Controller;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.PiccFQP1.Service.Xtm;
using NPOI.SS.UserModel;

namespace HuiYuIfo.PiccFQP1.Controller.Xtm
{
    public class XtmDepartController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                case "export":
                    Export(task, ref errmsg);
                    break;
                case "ucreate":
                    task.PagePath = "DepartEdit.aspx";
                    task.Width = 700;
                    task.Height = 300;
                    break;
                case "uedit":
                    task.PagePath = "DepartEdit.aspx";
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
        private void Export(Framework.Task.Task task, ref string errmsg)
        {
            XtmDepartService service1 = new XtmDepartService();
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
            XtmDepart entity = task.Entity as XtmDepart;
            XtmDepartService service = new XtmDepartService();
            result = service.Validate("all", entity, ref errmsg);
            if (result == false)
            {
                return false;
            }
            if (entity.Did != 0 && entity.ParentId != 0)
            {
                if (entity.Did == entity.ParentId)
                {
                    errmsg = "自己不能为自己的隶属机构";
                    return false;
                }
            }

            if (entity.ParentId == 0)
            {
                entity.DepartLayer = 1;
            }
            else
            {
                XtmDepart parDep = new XtmDepart();
                parDep.Did = entity.ParentId;
                parDep = baseDao.Get(parDep);
                entity.DepartLayer = parDep.DepartLayer + 1;
            }
            if (entity.Did > 0)
            {
                baseDao.Update(entity);
            }
            else
            {
                XtmDepart temp = new XtmDepart();
                temp.DepartCode = entity.DepartCode;
                int count = baseDao.Count(temp);
                if (count > 0)
                {
                    errmsg = "该机构代码已经被使用";
                    return false;
                }
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
            XtmDepart delModel = new XtmDepart();
            delModel.SysKey = task.CommandArgument;
            BaseDao baseDao = new BaseDao();
            XtmDepart temp = new XtmDepart();
            temp.ParentId = delModel.Did;
            int count = baseDao.Count(temp);
            if (count > 0)
            {
                errmsg = "该部门底下挂有子部门，不允许删除";
                return false;
            }
            XtmUser userM = new XtmUser();
            userM.DepartId = delModel.Did;
            count = baseDao.Count(userM);
            if (count > 0)
            {
                errmsg = "该部门底下挂有人员，不允许删除";
                return false;
            }
            try
            {
                baseDao.Delete(delModel);
            }
            catch (Exception ex)
            {
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
