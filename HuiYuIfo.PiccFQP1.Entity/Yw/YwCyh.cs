using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwCyh:BaseEntity
    {
        public YwCyh():base("YwCyh")
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
        //优质转入基数
        private string _yzzrjs = "";
        public string Yzzrjs
        {
            get
            {
                return _yzzrjs;
            }
            set
            {
                _yzzrjs = value;
            }
        }
        private string _cx3c = "";
        //did
        private int _did = 0;
        //渠道
        private string _qd="";
        //险种
        private string _xz="";
        //是否单保第三者
        private string _dbdsz="";
        //是否单保交强
        private string _dbjq="";
        //车辆类型
        private string _cllx="";
        //业务来源
        private string _ywly="";
        //综合出险次数
        private string _zhcxcs="";
        //使用年限
        private string _synx="";
        //是否保车损
        private string _sfbcs="";
        //赔付率是否超100%
        private string _pfvsfc100="";
        //基础手续费
        private string _jcsxf="";
        //保车上人员
        private string _bcsry="";
        //保盗抢险
        private string _bdqx="";
        //保自燃险
        private string _bzrx="";
        //保发动机
        private string _bfdj="";
        //三者100万
        private string _sz100="";
        //抢修
        private string _qx="";
        //优质平安
        private string _uzpa="";
        //手续费差异化
        private decimal _xxfcyh = 0;
        //创建人
        private int _createId = 0;
        //创建时间
        private DateTime _createDate = DateTime.Parse("1900-01-01");
        //修改人
        private int _modifyId = 0;
        //修改时间
        private DateTime _modifyDate = DateTime.Parse("1900-01-01");

        private string _sxflx = "";
        public string Sxflx
        {
            get
            {
                return _sxflx;
            }
            set
            {
                _sxflx = value;
            }
        }
        private string _Wfglcxcs="";
        public string Wfglcxcs
        {
            get
            {
                return _Wfglcxcs;
            }
            set
            {
                _Wfglcxcs = value;
            }
        }

        public string Cx3c
        {
            get
            {
                return _cx3c;
            }
            set
            {
                _cx3c = value;
            }
        }
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
        //渠道
        public string Qd
        {
            get
            {
                return _qd;
            }
            set
            {
                _qd=value;
            }
        }
        //险种
        public string Xz
        {
            get
            {
                return _xz;
            }
            set
            {
                _xz=value;
            }
        }
        //是否单保第三者
        public string Dbdsz
        {
            get
            {
                return _dbdsz;
            }
            set
            {
                _dbdsz=value;
            }
        }
        //是否单保交强
        public string Dbjq
        {
            get
            {
                return _dbjq;
            }
            set
            {
                _dbjq=value;
            }
        }
        //车辆类型
        public string Cllx
        {
            get
            {
                return _cllx;
            }
            set
            {
                _cllx=value;
            }
        }
        //业务来源
        public string Ywly
        {
            get
            {
                return _ywly;
            }
            set
            {
                _ywly=value;
            }
        }
        //综合出险次数
        public string Zhcxcs
        {
            get
            {
                return _zhcxcs;
            }
            set
            {
                _zhcxcs=value;
            }
        }
        //使用年限
        public string Synx
        {
            get
            {
                return _synx;
            }
            set
            {
                _synx=value;
            }
        }
        //是否保车损
        public string Sfbcs
        {
            get
            {
                return _sfbcs;
            }
            set
            {
                _sfbcs=value;
            }
        }
        //赔付率是否超100%
        public string Pfvsfc100
        {
            get
            {
                return _pfvsfc100;
            }
            set
            {
                _pfvsfc100=value;
            }
        }
        //基础手续费
        public string Jcsxf
        {
            get
            {
                return _jcsxf;
            }
            set
            {
                _jcsxf=value;
            }
        }
        //保车上人员
        public string Bcsry
        {
            get
            {
                return _bcsry;
            }
            set
            {
                _bcsry=value;
            }
        }
        //保盗抢险
        public string Bdqx
        {
            get
            {
                return _bdqx;
            }
            set
            {
                _bdqx=value;
            }
        }
        //保自燃险
        public string Bzrx
        {
            get
            {
                return _bzrx;
            }
            set
            {
                _bzrx=value;
            }
        }
        //保发动机
        public string Bfdj
        {
            get
            {
                return _bfdj;
            }
            set
            {
                _bfdj=value;
            }
        }
        //三者100万
        public string Sz100
        {
            get
            {
                return _sz100;
            }
            set
            {
                _sz100=value;
            }
        }
        //抢修
        public string Qx
        {
            get
            {
                return _qx;
            }
            set
            {
                _qx=value;
            }
        }
        //优质平安
        public string Uzpa
        {
            get
            {
                return _uzpa;
            }
            set
            {
                _uzpa=value;
            }
        }
        //手续费差异化
        public decimal Xxfcyh
        {
            get
            {
                return _xxfcyh;
            }
            set
            {
                _xxfcyh=value;
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
