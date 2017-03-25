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

namespace HuiYuIfo.PiccFQP1.Controller.Yw
{
    public class YwAnlayController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
                case "uedit":
                    task.PagePath = "CwAnalyEdit.aspx";
                   
                    task.PageParam = task.CommandArgument;
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
            BaseDao baseDao = new BaseDao();
            YwAnlay entity = task.Entity as YwAnlay;
            if (entity.Bz != "Y")
            {
                errmsg = "该条数据已过帐期，不能修改";
                return false;
            }

            entity.Srhj = entity.Cxzdxje + entity.Cxfdjx + entity.Sryfgz;
            entity.Zchj = entity.Sxf + entity.Fybx + entity.Zcyfgz + entity.Xcp;
            entity.Byjy = entity.Syjy + entity.Srhj - entity.Zchj;
            baseDao.Update(entity);
            if (result == true)
            {
                errmsg = "保存成功";
                task.ParentRebind = true;
                task.IsClose = true;
            }
            return result;
        }
    }
}
