using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Service.Yw
{
    public class YwAnlayService
    {
        private BaseDao baseDao = new BaseDao();
        public bool Validate(string type, YwAnlay entity, ref string errmsg)
        {
            return true;
        }
    }
}
