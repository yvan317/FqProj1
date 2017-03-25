using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Controller;
using System.IO;
using NPOI.HSSF.UserModel;
using HuiYuIfo.PiccFQP1.Service.Yw;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwSpecController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            switch (task.Command)
            {
                case "export":
                    YwSpecService epService2 = new YwSpecService();
                    XSSFWorkbook book2 = epService2.Export();
                    if (task.paralist == null)
                    {
                        task.paralist = new System.Collections.ArrayList();
                    }
                    task.paralist.Add(book2);
                    break;
                case "exportExample":
                    YwSpecService epService1 = new YwSpecService();
                    XSSFWorkbook book1 = epService1.ExportExample();
                    if (task.paralist == null)
                    {
                        task.paralist = new System.Collections.ArrayList();
                    }
                    task.paralist.Add(book1);
                    break;
                case "importSave":
                    result=DealImport(task, ref errmsg);
                    if (result == false)
                    {
                        return false;
                    }
                    break;
                case "import":
                    task.Width = 400;
                    task.Height = 250;
                    task.PagePath = "SpecImport.aspx";
                    break;
                case "ucreate":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "SpecEdit.aspx";
                    break;
                case "uedit":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "SpecEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "ushow":
                    task.Width = 600;
                    task.Height = 400;
                    task.PagePath = "SpecEdit.aspx";
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
            
            YwSpecService service = new YwSpecService();
            YwSpec entity = task.Entity as YwSpec;
            if (service.Validate("all",entity, ref errmsg) == false)
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
                YwSpec temp = new YwSpec();
                temp.SpecName = entity.SpecName;
                int count = baseDao.Count(temp);
                if (count > 0)
                {
                    errmsg = "该特殊情况已经被定义";
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
            YwSpec delModel = new YwSpec();
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
                    YwSpecService specService = new YwSpecService();
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
