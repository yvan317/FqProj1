using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Controller;
using HuiYuIfo.PiccFQP1.Service.Yw;
using NPOI.SS.UserModel;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwQueryDataController : BaseController
    {
        private BaseDao baseDao = new BaseDao();
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            switch (task.Command)
            {
                case "showAtt":
                    task.PagePath = "../Yw/CbShowAtt.aspx";
                    task.PageParam = ((YwData)task.Entity).Did.ToString();
                    break;
                case "ywyShow":
                    task.PagePath = "YwyDataShow.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "queryExport":
                    DataExportLastZQ(task, ref errmsg);
                    break;
                case "ywyQueryExport":
                    //业务员导出最后结帐数据
                    YwyExportLastZQ(task, ref errmsg);
                    break;
                case "historyExport":
                    HistoryExport(task, ref errmsg);
                    break;
            }
            return result;
        }
        private void HistoryExport(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = (YwData)task.Entity;
            YwDataService service = new YwDataService();
            YwData param = new YwData();

            param.BegD = DateTime.Parse("" + entity.Year + "-" + entity.Month + "-01");
            param.EndD = param.BegD.AddMonths(1);
            param.Depart = entity.Depart;
            param.Ywy = entity.Ywy;
            IWorkbook book = null;
            if (entity.SysUserType=="ywy")
            {
                param.Ywy = entity.SysUserCode;
                book = service.QueryExportData("ywy", param, ref errmsg);
            }
            else
            {
                param.GetOpType = "departPri";
                book = service.QueryExportData("all", param, ref errmsg);
            }


            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        private void DataExportLastZQ(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = (YwData)task.Entity;
            YwDataService service = new YwDataService();
            YwData param = new YwData();
            param.EndD = service.GetBegDate();
            param.BegD = param.EndD.AddMonths(-1);
            IWorkbook book = null;
            if (entity.SysUserType == "ywy")
            {
                param.Ywy = entity.Ywy;
                book = service.QueryExportData("ywy", param, ref errmsg);
            }
            else
            {
                param.GetOpType = "departPri";
                book = service.QueryExportData("all", param, ref errmsg);
            }

            
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        private void YwyExportLastZQ(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity=(YwData)task.Entity;
            YwDataService service = new YwDataService();
            YwData param = new YwData();
            param.EndD = service.GetBegDate();
            param.BegD = param.EndD.AddMonths(-1);
            param.Ywy = entity.Ywy;

            IWorkbook book = service.QueryExportData("ywy",param,ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
    }
}
