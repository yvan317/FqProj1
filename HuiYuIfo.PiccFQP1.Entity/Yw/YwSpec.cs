using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwSpec:BaseEntity
    {
        public YwSpec():base("YwSpec")
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
        //did
        private int _did = 0;
        //特殊类型
        private string _specName="";
        //商业险费率
        private decimal _syxfv = 0;
        //交强险费率
        private decimal _jqxfv = 0;
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
        //特殊类型
        public string SpecName
        {
            get
            {
                return _specName;
            }
            set
            {
                _specName=value;
            }
        }
        //商业险费率
        public decimal Syxfv
        {
            get
            {
                return _syxfv;
            }
            set
            {
                _syxfv=value;
            }
        }
        //交强险费率
        public decimal Jqxfv
        {
            get
            {
                return _jqxfv;
            }
            set
            {
                _jqxfv=value;
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
