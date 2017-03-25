using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Controller;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Controller.Xtm
{
    public class XtmConfigController : BaseController
    {
        public override bool Execute(Framework.Task.Task task, ref string errmsg)
        {
            switch (task.Command)
            {
               
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
            XtmConfig entity = task.Entity as XtmConfig;
            if (entity.Config1 == "")
            {
                errmsg = "结账日不能为空";
                return false;
            }
            try
            {
                int temp = int.Parse(entity.Config1);
                if (temp < 0 || temp > 28)
                {
                    errmsg = "结账日只能在1到28号之间";
                    return false;
                }
            }
            catch
            {
                errmsg = "结账日不正确，应该是整数";
                return false;
            }
            baseDao.Update(entity);
            errmsg = "保存成功";
            return result;
        }
        
    }
}
