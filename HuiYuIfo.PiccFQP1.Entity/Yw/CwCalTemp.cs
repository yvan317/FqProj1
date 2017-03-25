using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Entity;

namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    public class CwCalTemp : BaseEntity
    {
        public CwCalTemp()
            : base("CwCalTemp")
        {
        }
        public DateTime EndD = DateTime.Parse("1900-01-01");
        public DateTime BegD = DateTime.Parse("1900-01-01");
        private string _ywyCode = "";
        public string YwyCode
        {
            get
            {
                return _ywyCode;
            }
            set
            {
                _ywyCode = value;
            }
        }
        private decimal _zdxje = 0;
        public decimal Zdxje
        {
            get
            {
                return _zdxje;
            }
            set
            {
                _zdxje = value;
            }
        }
    }
}
