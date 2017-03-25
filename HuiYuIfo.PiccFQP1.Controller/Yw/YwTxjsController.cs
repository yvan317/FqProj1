using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.PiccFQP1.Service.Yw;
using NPOI.SS.UserModel;
using HuiYuIfo.Framework.Controller;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using System.Collections;
using System.IO;
using NPOI.XSSF.UserModel;

namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwTxjsController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            switch (task.Command)
            {
                case "export":
                    YwTxjsService epService2 = new YwTxjsService();
                    XSSFWorkbook book2 = epService2.Export();
                    if (task.paralist == null)
                    {
                        task.paralist = new System.Collections.ArrayList();
                    }
                    task.paralist.Add(book2);
                    break;
                case "exportExample":
                    YwTxjsService epService1 = new YwTxjsService();
                    XSSFWorkbook book1 = epService1.ExportExample();
                    if (task.paralist == null)
                    {
                        task.paralist = new System.Collections.ArrayList();
                    }
                    task.paralist.Add(book1);
                    break;
                case "importSave":
                    result = DealImport(task, ref errmsg);
                    if (result == false)
                    {
                        return false;
                    }
                    break;
                case "import":
                    task.Width = 400;
                    task.Height = 250;
                    task.PagePath = "TxjsImport.aspx";
                    break;
                case "ucreate":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "TxjsEdit.aspx";
                    break;
                case "uedit":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "TxjsEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "ushow":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "TxjsEdit.aspx";
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
        private bool Save(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;

            YwTxjsService service = new YwTxjsService();
            YwTxjs entity = task.Entity as YwTxjs;
            if (service.Validate("all", entity, ref errmsg) == false)
            {
                return false;
            }
            BaseDao baseDao = new BaseDao();
            if (entity.Did > 0)
            {
                baseDao.Update(entity);
            }
            else
            {
                YwTxjs temp = new YwTxjs();
                temp.Txm = entity.Txm;
                int count = baseDao.Count(temp);
                if (count > 0)
                {
                    errmsg = "该推修码已经被定义";
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
            YwTxjs delModel = new YwTxjs();
            delModel.SysKey = task.CommandArgument;
            BaseDao baseDao = new BaseDao();
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
        private bool DealImport(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            this.BeginTran();
            try
            {
                using (FileStream fs = File.OpenRead(task.paralist[0].ToString()))
                {
                    IWorkbook book = WorkbookFactory.Create(fs);
                    YwTxjsService specService = new YwTxjsService();
                    result = specService.DealWorkbook(book, ref errmsg);
                }
                if (result == false)
                {
                    this.RollbackTran();
                    return false;
                }
                this.CommitTran();
                errmsg = "上传成功";
                task.ParentRebind = true;
                task.IsClose = true;
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                this.RollbackTran();
                return false;
            }
            return true;
        }
    }
}
