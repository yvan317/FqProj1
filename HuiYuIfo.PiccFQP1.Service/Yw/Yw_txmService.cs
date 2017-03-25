using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Service.Yw
{
    public class Yw_txmService
    {
        private BaseDao baseDao = new BaseDao();
        public bool Validate(string type, Yw_txm entity, ref string errmsg)
        {
            if (entity.Txm == "")
            {
                errmsg = "推修码不能为空";
                return false;
            }
            return true;
        }
        public bool CheckExist(Yw_txm entity)
        {
            Yw_txm model = new Yw_txm();
            model.Txm = entity.Txm;
            int count = baseDao.Count(model);
            if (count > 0)
            {
                return false;
            } return true;

        }
    }
}
