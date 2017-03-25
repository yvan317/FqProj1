using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmConfig:BaseEntity
    {
        public XtmConfig():base("XtmConfig")
        {
        }
        private string _Bcsry = "";
        public string Bcsry
        {
            get
            {
                return _Bcsry;
            }
            set
            {
                _Bcsry = value;
            }
        }

        private string _Bdqx = "";
        public string Bdqx
        {
            get
            {
                return _Bdqx;
            }
            set
            {
                _Bdqx = value;
            }
        }
        private string _Bzrx = "";
        public string Bzrx
        {
            get
            {
                return _Bzrx;
            }
            set
            {
                _Bzrx = value;
            }
        }
        private string _Bfdj = "";
        public string Bfdj
        {
            get
            {
                return _Bfdj;
            }
            set
            {
                _Bfdj = value;
            }
        }
        private string _Sz100 = "";
        public string Sz100
        {
            get
            {
                return _Sz100;
            }
            set
            {
                _Sz100 = value;
            }
        }
        private string _Tx = "";
        public string Tx
        {
            get
            {
                return _Tx;
            }
            set
            {
                _Tx = value;
            }
        }

        private string _Yzpa = "";
        public string Yzpa
        {
            get
            {
                return _Yzpa;
            }
            set
            {
                _Yzpa = value;
            }
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
        //did
        private int _did = 0;
        //部门编码
        private string _config1="";
        //部门名称
        private string _config2="";
        //隶属部门
        private string _config3="";
        //部门层级
        private string _config4="";
        //创建人
        private int _createId = 0;
        //创建时间
        private DateTime _createDate = DateTime.Parse("1900-01-01");
        //修改人
        private int _modifyId = 0;
        //修改时间
        private DateTime _modifyDate = DateTime.Parse("1900-01-01");
        //did
        public int Did
        {
            get
            {
                return _did;
            }
            set
            {
                _did=value;
            }
        }
        //部门编码
        public string Config1
        {
            get
            {
                return _config1;
            }
            set
            {
                _config1=value;
            }
        }
        //部门名称
        public string Config2
        {
            get
            {
                return _config2;
            }
            set
            {
                _config2=value;
            }
        }
        //隶属部门
        public string Config3
        {
            get
            {
                return _config3;
            }
            set
            {
                _config3=value;
            }
        }
        //部门层级
        public string Config4
        {
            get
            {
                return _config4;
            }
            set
            {
                _config4=value;
            }
        }
        //创建人
        public int CreateId
        {
            get
            {
                return _createId;
            }
            set
            {
                _createId=value;
            }
        }
        //创建时间
        public DateTime CreateDate
        {
            get
            {
                return _createDate;
            }
            set
            {
                _createDate=value;
            }
        }
        //修改人
        public int ModifyId
        {
            get
            {
                return _modifyId;
            }
            set
            {
                _modifyId=value;
            }
        }
        //修改时间
        public DateTime ModifyDate
        {
            get
            {
                return _modifyDate;
            }
            set
            {
                _modifyDate=value;
            }
        }
    }
}
