using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Service.Yw;
using HuiYuIfo.Framework.Controller;

namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwCwDataController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                case "cwUnComfirm":
                    CwUnConfirm(task, ref errmsg);
                    break;
                case "cwComfirmEdit"://财务审核
                    task.PagePath = "CwComfirmEdit.aspx";
                    task.PageParam = task.CommandArgument;
                    break;
                case "cwSave"://财务保存
                    CwSave(task, ref errmsg);
                    break;
                case "showAtt":
                    task.PagePath = "CbShowAtt.aspx";
                    task.PageParam = ((YwData)task.Entity).Did.ToString();
                    break;
            }
            return true;
        }

        #region 财务操作（保存，审核）
        private bool CwUnConfirm(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                YwData entity = task.Entity as YwData;
                BaseDao baseDao = new BaseDao();
                YwDataService service = new YwDataService();
                DateTime begD = service.GetBegDate();
                if (entity.CreateDate < begD)
                {
                    throw new Exception("数据已经超过结账日，不允许修改");
                }
                entity.Status = "3";
                entity.Cwback = "Y";
                //service.FirstCalculate(1, entity);
                //service.SeconeCalculate(entity);
                baseDao.Update(entity);
                if (result == true)
                {
                    errmsg = "保存成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
            }
            catch (Exception ex)
            {
                errmsg = "保存失败:" + ex.Message;
                return false;
            }
            return result;
        }
        private bool CwSave(Framework.Task.Task task, ref string errmsg)
        {
            bool result = true;
            try
            {
                YwData entity = task.Entity as YwData;
                BaseDao baseDao = new BaseDao();
                YwDataService service = new YwDataService();
                DateTime begD = service.GetBegDate();
                if (entity.CreateDate < begD)
                {
                    throw new Exception("数据已经超过结账日，不允许修改");
                }
                service.FirstCalculate(1, entity);
                service.SeconeCalculate(entity);
                entity.CwConfirm = DateTime.Now;
                baseDao.Update(entity);
                if (result == true)
                {
                    errmsg = "保存成功";
                    task.ParentRebind = true;
                    task.IsClose = true;
                }
            }
            catch (Exception ex)
            {
                errmsg = "保存失败:"+ex.Message;
                return false;
            }
            return result;
        }
        #endregion
    }
}