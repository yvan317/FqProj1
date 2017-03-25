using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwAnlay:BaseEntity
    {
        public YwAnlay():base("YwAnlay")
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
        private string _depart = "";
        public string Depart
        {
            get
            {
                return _depart;
            }
            set
            {
                _depart = value;
            }
        }
        private string _bz = "";
        public string Bz
        {
            get
            {
                return _bz;
            }
            set
            {
                _bz = value;
            }
        }
        //did
        private int _did;
        //统计年
        private int _year;
        //统计月
        private int _month;
        //业务员Id
        private int _ywyId;
        //业务员编码
        private string _ywyCode;
        //业务员名称
        private string _ywyName;
        //上月结余
        private decimal _syjy;
        //车险总兑现金额
        private decimal _cxzdxje;
        //车险浮动绩效
        private decimal _cxfdjx;
        //应付工资
        private decimal _sryfgz;
        //收入合计
        private decimal _srhj;
        //手续费
        private decimal _sxf;
        //费用报销
        private decimal _fybx;
        //应付工资
        private decimal _zcyfgz;
        //宣传品
        private decimal _xcp;
        //支出合计
        private decimal _zchj;
        //本月结余
        private decimal _byjy;
        //创建人
        private int _createId;
        //创建时间
        private DateTime _createDate;
        //修改人
        private int _modifyId;
        //修改时间
        private DateTime _modifyDate;
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
        //统计年
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                _year=value;
            }
        }
        //统计月
        public int Month
        {
            get
            {
                return _month;
            }
            set
            {
                _month=value;
            }
        }
        //业务员Id
        public int YwyId
        {
            get
            {
                return _ywyId;
            }
            set
            {
                _ywyId=value;
            }
        }
        //业务员编码
        public string YwyCode
        {
            get
            {
                return _ywyCode;
            }
            set
            {
                _ywyCode=value;
            }
        }
        //业务员名称
        public string YwyName
        {
            get
            {
                return _ywyName;
            }
            set
            {
                _ywyName=value;
            }
        }
        //上月结余
        public decimal Syjy
        {
            get
            {
                return _syjy;
            }
            set
            {
                _syjy=value;
            }
        }
        //车险总兑现金额
        public decimal Cxzdxje
        {
            get
            {
                return _cxzdxje;
            }
            set
            {
                _cxzdxje=value;
            }
        }
        //车险浮动绩效
        public decimal Cxfdjx
        {
            get
            {
                return _cxfdjx;
            }
            set
            {
                _cxfdjx=value;
            }
        }
        //应付工资
        public decimal Sryfgz
        {
            get
            {
                return _sryfgz;
            }
            set
            {
                _sryfgz=value;
            }
        }
        //收入合计
        public decimal Srhj
        {
            get
            {
                return _srhj;
            }
            set
            {
                _srhj=value;
            }
        }
        //手续费
        public decimal Sxf
        {
            get
            {
                return _sxf;
            }
            set
            {
                _sxf=value;
            }
        }
        //费用报销
        public decimal Fybx
        {
            get
            {
                return _fybx;
            }
            set
            {
                _fybx=value;
            }
        }
        //应付工资
        public decimal Zcyfgz
        {
            get
            {
                return _zcyfgz;
            }
            set
            {
                _zcyfgz=value;
            }
        }
        //宣传品
        public decimal Xcp
        {
            get
            {
                return _xcp;
            }
            set
            {
                _xcp=value;
            }
        }
        //支出合计
        public decimal Zchj
        {
            get
            {
                return _zchj;
            }
            set
            {
                _zchj=value;
            }
        }
        //本月结余
        public decimal Byjy
        {
            get
            {
                return _byjy;
            }
            set
            {
                _byjy=value;
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
