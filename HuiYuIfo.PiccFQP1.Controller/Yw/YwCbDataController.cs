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
    public class YwCbDataController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            switch (task.Command)
            {
                #region 新增页面处理
                case "cbCreate":
                    //打开承保页面
                    task.PagePath = "CbCreate.aspx";
                    break;
                case "cbCreateSave":
                    //保存承保页面
                    CbCreateSave(task, ref errmsg);
                    break;
                #endregion
                #region 承保list导出功能
                case "cbExportPriNoEnd":
                    //导出上期未处理数据
                    ExportPriNoEnd(task, ref errmsg);
                    break;
                case "cbExportPriAll":
                    //导出上期所有数据
                    ExportPriAll(task, ref errmsg);
                    break;
                case "cbExportNowNoend":
                    //导出本期未处理数据
                    ExportNowNoEnd(task, ref errmsg);
                    break;
                case "cbExportNowAll":
                    //导出本期所有数据
                    ExportAll(task, ref errmsg);
                    break;
                #endregion
                #region 承保导入处理
                case "cbImport"://打开承保导入页面
                    task.Width = 400;
                    task.Height = 250;
                    task.PagePath = "CbImport.aspx";
                    break;
                case "cbImportSave": //数据导入
                    result = DealImport(task, ref errmsg);
                    if (result == false)
                    {
                        return false;
                    }
                    break;
                #endregion
                #region 编辑页面处理
                case "cbEdit"://打开承保编辑
                    task.PagePath = "CbDataEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "cbSave"://承保单条保存（第一步)
                    CbSave(task, ref errmsg);
                    break;
                #endregion
                #region 承保审核页面处理
                case "cbComfirmEdit"://承保审核
                    task.PagePath = "CbComfirmEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "showAtt":
                    task.PagePath = "CbShowAtt.aspx";
                    task.PageParam = ((YwData)task.Entity).Did.ToString();
                    break;
                case "cbComfirm"://承保审核通过，进行第二次计算
                    CbComfirm(task, ref errmsg);
                    break;
                case "cbUnComfirm"://承保不通过,驳回业务员填写
                    CbUnComfirm(task, ref errmsg);
                    break;
                #endregion

            }
            return true;
        }
        //承保新增保存
        private bool CbCreateSave(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                BaseDao baseDao = new BaseDao();
                YwData entity = task.Entity as YwData;
                YwDataService service = new YwDataService();
                result = service.Validate("cbCreate", entity, ref errmsg);
                if (result == false)
                {
                    return false;
                }
                if (entity.Sybf <= 0)
                {
                    entity.Xz = "交强险";
                }
                else
                {
                    entity.Xz = "商业险";
                }
                entity.Status = "4";
                
                service.FirstCalculate(1, entity);
                service.SeconeCalculate(entity);
                entity.CbSubmit = DateTime.Now;
                baseDao.Insert(entity);
                errmsg = "新增成功";
          
                task.ParentRebind = true;
                task.IsClose = true;
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
            return result;

        }
        //承保导出上月未完成数据
        private void ExportPriNoEnd(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = task.Entity as YwData;
            YwDataService service = new YwDataService();

            YwData param = new YwData();
            DateTime dtTemp = DateTime.Now.AddMonths(-1);

            param.BegD = new DateTime(dtTemp.Year, dtTemp.Month, 1);
            param.EndD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            param.GetOpType = "CbExportNoEnd";
            IWorkbook book = service.ExportData(param, ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        //承保导出上月所有数据
        private void ExportPriAll(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = task.Entity as YwData;
            YwDataService service = new YwDataService();

            YwData param = new YwData();
            DateTime dtTemp = DateTime.Now.AddMonths(-1);

            param.BegD = new DateTime(dtTemp.Year, dtTemp.Month, 1);
            param.EndD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            param.GetOpType = "CbExportAll";
            IWorkbook book = service.ExportData(param, ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        //承保导出本月未完成数据
        private void ExportNowNoEnd(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = task.Entity as YwData;
            YwDataService service = new YwDataService();

            YwData param = new YwData();
            DateTime dtTemp = DateTime.Now.AddMonths(1);

            param.BegD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            param.EndD = new DateTime(dtTemp.Year, dtTemp.Month, 1);

            param.GetOpType = "CbExportNoEnd";
            IWorkbook book = service.ExportData(param, ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        //承保导出本月所有数据
        private void ExportAll(Framework.Task.Task task, ref string errmsg)
        {
            YwData entity = task.Entity as YwData;
            YwDataService service = new YwDataService();

            YwData param = new YwData();
            DateTime dtTemp = DateTime.Now.AddMonths(1);

            param.BegD = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            param.EndD = new DateTime(dtTemp.Year, dtTemp.Month, 1);

            param.GetOpType = "CbExportAll";
            IWorkbook book = service.ExportData(param, ref errmsg);
            if (task.paralist == null)
            {
                task.paralist = new System.Collections.ArrayList();
            }
            task.paralist.Add(book);
        }
        //承保数据导入处理
        private bool DealImport(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            this.BeginTran();
            try
            {
                string errType="";
                XSSFWorkbook errBook = new XSSFWorkbook();
                using (FileStream fs = File.OpenRead(task.paralist[0].ToString())) 
                {
                    IWorkbook book = WorkbookFactory.Create(fs);
                    YwDataService service = new YwDataService();
                    result = service.DealCbImport(book, errBook, ref errType,ref errmsg);
                }
                task.paralist = new System.Collections.ArrayList();
                if (result == false)
                {
                    if (errType== "content")
                    {
                       
                        task.paralist.Add(errBook);
                    }
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
        //承保编辑保存
        private bool CbSave(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                YwData entity = task.Entity as YwData;
                YwDataService service = new YwDataService();
                if (service.Validate("cbEdit", entity, ref errmsg) == false)
                {
                    return false;
                }
                DateTime begD = service.GetBegDate();
                if (entity.CreateDate < begD)
                {
                    throw new Exception("数据已经超过结账日，不允许修改");
                }
                BaseDao baseDao = new BaseDao();
                if (entity.Sybf <= 0)
                {
                    entity.Xz = "交强险";
                }
                else
                {
                    entity.Xz = "商业险";
                }
                if (entity.Xz == "商业险")
                {
                    entity.Status = "2";
                }
                else
                {
                    entity.Status = "4";
                    service.FirstCalculate(1, entity);
                    service.SeconeCalculate(entity);
                }
                entity.CbSubmit = DateTime.Now;
                int count=baseDao.Update(entity);
                if (count <= 0)
                {
                    errmsg = "数据在页面显示后被其他人修改过，请重新打开编辑";
                    task.ParentRebind = true;
                    task.IsClose = true;
                    return false;
                }
                if (result == true)
                {
                    errmsg = "保存成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
            return result;
        }
        //承保审核退回
        private bool CbUnComfirm(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                YwData entity = task.Entity as YwData;
                BaseDao baseDao = new BaseDao();
                YwDataService service = new YwDataService();
                entity.Status = "2";
                entity.Cbback = "Y";
                DateTime begD = service.GetBegDate();
                if (entity.CreateDate < begD)
                {
                    throw new Exception("数据已经超过结账日，不允许修改");
                }
                baseDao.Update(entity);
                if (result == true)
                {
                    errmsg = "操作成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
            return result;
        }
        //承保审核通过
        private bool CbComfirm(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                YwData entity = task.Entity as YwData;
                YwDataService service = new YwDataService();
                DateTime begD = service.GetBegDate();
                if (entity.CreateDate < begD)
                {
                    throw new Exception("数据已经超过结账日，不允许修改");
                }
                BaseDao baseDao = new BaseDao();
                entity.Status = "4";
                entity.CbConfirm = DateTime.Now;
                service.FirstCalculate(1, entity);
                service.SeconeCalculate(entity);
                baseDao.Update(entity);
                if (result == true)
                {
                    errmsg = "操作成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
            }
            catch (Exception ex)
            {
                errmsg = ex.Message;
                return false;
            }
            return result;
        }      
    }
}
