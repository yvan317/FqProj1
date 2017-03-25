using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HuiYuIfo.Framework.Entity;

namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    public class Yw_txm : BaseEntity
    {
        public Yw_txm(): base("Yw_txm")
        {
        }
        public override string SysKey
        {
            get
            {
                return _did .ToString();
            }
            set
            {
                _did=int.Parse(value);
            }
        }
        private int _did=0;
        private string _txm="";
        private string _xlc="";
        private string _zy="";
        private int _js=0;

        public int Did
        {
            get{
                return _did;
            }
            set
            {
                _did=value;
            }
        }
        public string Txm
        {
            get
            {
                return _txm;
            }
            set{
                _txm=value;
            }
        }
        public string Zy 
        {
            get
            {
                return _zy;
            }
            set
            {
                _zy=value;
            }
        }
        public int Js
        {
            get
            {
                return _js;
            }
            set
            {
                _js=value;
            }
        }

          
    }
}
