using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwData:BaseEntity
    {
        public YwData():base("YwData")
        {
        }
        private string _Sxflx = "";
        private string _Cx = "";
        private string _Sfgh = "";
        private string _Wfglcx = "";
        private string _Cx3c = "";
        private string _Txm = "";
        private decimal _Zj = 0;
        private string _qzbz = "";
        public string qzbz
        {
            get
            {
                return _qzbz;
            }
            set
            {
                _qzbz = value;
            }
        }
        public string Sxflx
        {
            get { return _Sxflx; }
            set { _Sxflx = value; }
        }
        public string Cx
        {
            get { return _Cx; }
            set { _Cx = value; }
        }
        public string Sfgh
        {
            get { return _Sfgh; }
            set { _Sfgh = value; }
        }
        public string Wfglcx
        {
            get { return _Wfglcx; }
            set { _Wfglcx = value; }
        }
        public string Cx3c
        {
            get { return _Cx3c; }
            set { _Cx3c = value; }
        }
        public string Txm
        {
            get { return _Txm; }
            set { _Txm = value; }
        }
        public decimal Zj
        {
            get { return _Zj; }
            set { _Zj = value; }
        }












        private string _cwBack = "";
        private string _cbBack = "";
        public string Cwback
        {
            get
            {
                return _cwBack;
            }
            set
            {
                _cwBack = value;
            }
        }
        public string Cbback
        {
            get
            {
                return _cbBack;
            }
            set
            {
                _cbBack = value;
            }
        }
        private DateTime _cbSubmit = DateTime.Parse("1900-1-1");
        public DateTime CbSubmit
        {
            get
            {
                return _cbSubmit;
            }
            set
            {
                _cbSubmit = value;
            }
        }
        private DateTime _ywySubmit = DateTime.Parse("1900-1-1");
        public DateTime YwySubmit
        {
            get
            {
                return _ywySubmit;
            }
            set
            {
                _ywySubmit = value;
            }
        }
        private DateTime _cbConfirm = DateTime.Parse("1900-1-1");
        public DateTime CbConfirm
        {
            get
            {
                return _cbConfirm;
            }
            set
            {
                _cbConfirm = value;
            }
        }
        private DateTime _cwConfirm = DateTime.Parse("1900-1-1");
        public DateTime CwConfirm
        {
            get
            {
                return _cwConfirm;
            }
            set
            {
                _cwConfirm = value;
            }
        }
        private string _cbOpinion = "";
        public string CbOpinion
        {
            get
            {
                return _cbOpinion;
            }
            set
            {
                _cbOpinion = value;
            }
        }
        private string _cwOpinion = "";
        public string CwOpinion
        {
            get
            {
                return _cwOpinion;
            }
            set
            {
                _cwOpinion = value;
            }
        }
        //是否过帐期
        private bool _jz = false;
        public bool Jz
        {
            get
            {
                return _jz;
            }
            set
            {
                _jz = value;
            }
        }
        private string _xz = "";
        public string Xz
        {
            get
            {
                return _xz;
            }
            set
            {
                _xz = value;
            }
        }
        private byte[] _lastUpdate;
        public byte[] LastUpdate
        {
            get
            {
                return _lastUpdate;
            }
            set
            {
                _lastUpdate = value;
            }
        }
        private decimal _Szxbf = 0;
        public decimal Szxbf
        {
            get
            {
                return _Szxbf;
            }
            set
            {
                _Szxbf = value;
            }
        }
        private string _Process = "";
        public string Process
        {
            get
            {
                return _Process;
            }
            set
            {
                _Process = value;
            }
        }
        public string CalculateName
        {
            get
            {
                switch (this.CalculateType)
                {
                    case "1":
                        return "第一特例";
                    case "2":
                        return "第二特例";
                    case "3":
                        return "取手续费差异化计算";
                    default:
                        return "";
                }
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
        private string _ywyName = "";
        private string _departName = "";
        public string YwyName
        {
            get
            {
                return _ywyName;
            }
            set
            {
                _ywyName = value;
            }
        }
        public string DepartName
        {
            get
            {
                return _departName;
            }
            set
            {
                _departName = value;
            }
        }
        public DateTime EndD = DateTime.Parse("1900-01-01");
        public  DateTime BegD = DateTime.Parse("1900-01-01");

        private string _getType = "";
        public string GetOpType
        {
            get
            {
                return _getType;
            }
            set
            {
                _getType = value;
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
        //统计年份
        private int _year=0;
        //统计月份
        private int _month=0;
        //附件数量
        private int _attachmentCount=0;
        //附件状态
        private string _attachment="";
        //计算类型
        private string _calculateType = "";
        //状态
        private string _status = "";
        //部门
        private string _depart = "";
        //业务员
        private string _ywy="";
        //经办人
        private string _jbr="";
        //归属人
        private string _gsr="";
        //渠道
        private string _qd="";
        //渠道码
        private string _qdm="";
        //条款
        private string _tk="";
        //车辆类型性质
        private string _clxs="";
        //被保险人
        private string _bbr="";
        //单证号
        private string _dzh="";
        //车牌号
        private string _cph="";
        //单位性质
        private string _dwxz="";
        //座位数
        private string _zwh="";
        //吨位数
        private string _dws="";
        //是否新保、过户
        private string _sfxb="";
        //是否保盗抢
        private string _sfbbd="";
        //是否保车上人员
        private string _sfbcsry="";
        //是否保自燃
        private string _sfbzr="";
        //是否保车损
        private string _sfbcs="";
        //是否保发动机险
        private string _sfbfdj="";
        //单保三者
        private string _dbdsz="";
        //单保交强
        private string _dbjq="";
        //是否录维修码
        private string _sflwxm="";
        //使用年限
        private string _synx="";
        //银行卡号
        private string _yhkh="";
        //是否工行刷卡
        private string _ghsk="";
        //业务来源
        private string _ywly="";
        //客户群
        private string _khq="";
        //签单日期
        private DateTime _qdrq = DateTime.Parse("1900-01-01");
        //起保日期
        private DateTime _qbrq = DateTime.Parse("1900-01-01");
        //终保日期
        private DateTime _zbrq = DateTime.Parse("1900-01-01");
        //总保费/变动保费
        private decimal _zbf = 0;
        //商业保费
        private decimal _sybf = 0;
        //交强保费
        private decimal _jqbf = 0;
        //车船税
        private decimal _cqs = 0;
        //上年出险总次数
        private string _cxcs = "";
        //上年承保公司
        private string _sncbgs="";
        //是否平安
        private string _sfpa="";
        //是否优质
        private string _sfyz="";
        //出险2次，是否赔付100%
        private string _cx2c="";
        //是否采购办
        private string _sfcgb="";
        //报批
        private decimal _bp = 0;
        //备注
        private string _bz="";
        //特殊类型（第一优先）
        private string _tslx="";
        //追加费用
        private decimal _zjfy = 0;
        //是否有凭证
        private string _sfypz="";
        //实际支付市场费用（凭证金额）
        private decimal _sjscfy = 0;
        //手续费差异化%
        private decimal _sxfcyh = 0;
        //手续费金额
        private decimal _sxfje = 0;
        //实际支付报批费用
        private decimal _sjzfbpfy = 0;
        //税收
        private decimal _sh = 0;
        //自行掌握费用
        private decimal _zxzwfy = 0;
        //自行掌握费用结余
        private decimal _zxzwfyjy = 0;
        //自行掌握费用结余奖励70%
        private decimal _zxzwfyjyjl = 0;
        //补提供凭证差额
        private decimal _btgpzce = 0;
        //兑现金额
        private decimal _dxje = 0;
        //交通通讯费宣传品
        private decimal _jttxf = 0;
        //车险月度固定奖励
        private decimal _cxydjl = 0;
        //工行刷卡奖励
        private decimal _ghskjl = 0;
        //附件文件名
        private string _attrs="";
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
        //统计年份
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
        //统计月份
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
        //附件数量
        public int AttachmentCount
        {
            get
            {
                return _attachmentCount;
            }
            set
            {
                _attachmentCount=value;
            }
        }
        //附件状态
        public string Attachment
        {
            get
            {
                return _attachment;
            }
            set
            {
                _attachment=value;
            }
        }
        //计算类型
        public string CalculateType
        {
            get
            {
                return _calculateType;
            }
            set
            {
                _calculateType=value;
            }
        }
        //状态
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status=value;
            }
        }

        public string StatusName{
            get
            {
                switch (_status)
                {
                    case "1":
                        return "承保维护";
                    case "2":
                        return "业务员维护";
                    case "3":
                        return "承保审核";
                    case "4":
                        return "完成";
                    case "5":
                        return "系统结案";
                    default:
                        return "";
                }
            }
        }
        //部门
        public string Depart
        {
            get
            {
                return _depart;
            }
            set
            {
                _depart=value;
            }
        }
        //业务员
        public string Ywy
        {
            get
            {
                return _ywy;
            }
            set
            {
                _ywy=value;
            }
        }
        //经办人
        public string Jbr
        {
            get
            {
                return _jbr;
            }
            set
            {
                _jbr=value;
            }
        }
        //归属人
        public string Gsr
        {
            get
            {
                return _gsr;
            }
            set
            {
                _gsr=value;
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
        //渠道码
        public string Qdm
        {
            get
            {
                return _qdm;
            }
            set
            {
                _qdm=value;
            }
        }
        //条款
        public string Tk
        {
            get
            {
                return _tk;
            }
            set
            {
                _tk=value;
            }
        }
        //车辆类型性质
        public string Clxs
        {
            get
            {
                return _clxs;
            }
            set
            {
                _clxs=value;
            }
        }
        //被保险人
        public string Bbr
        {
            get
            {
                return _bbr;
            }
            set
            {
                _bbr=value;
            }
        }
        //单证号
        public string Dzh
        {
            get
            {
                return _dzh;
            }
            set
            {
                _dzh=value;
            }
        }
        //车牌号
        public string Cph
        {
            get
            {
                return _cph;
            }
            set
            {
                _cph=value;
            }
        }
        //单位性质
        public string Dwxz
        {
            get
            {
                return _dwxz;
            }
            set
            {
                _dwxz=value;
            }
        }
        //座位数
        public string Zwh
        {
            get
            {
                return _zwh;
            }
            set
            {
                _zwh=value;
            }
        }
        //吨位数
        public string Dws
        {
            get
            {
                return _dws;
            }
            set
            {
                _dws=value;
            }
        }
        //是否新保、过户
        public string Sfxb
        {
            get
            {
                return _sfxb;
            }
            set
            {
                _sfxb=value;
            }
        }
        //是否保盗抢
        public string Sfbbd
        {
            get
            {
                return _sfbbd;
            }
            set
            {
                _sfbbd=value;
            }
        }
        //是否保车上人员
        public string Sfbcsry
        {
            get
            {
                return _sfbcsry;
            }
            set
            {
                _sfbcsry=value;
            }
        }
        //是否保自燃
        public string Sfbzr
        {
            get
            {
                return _sfbzr;
            }
            set
            {
                _sfbzr=value;
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
        //是否保发动机险
        public string Sfbfdj
        {
            get
            {
                return _sfbfdj;
            }
            set
            {
                _sfbfdj=value;
            }
        }
        //单保三者
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
        //单保交强
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
        //是否录维修码
        public string Sflwxm
        {
            get
            {
                return _sflwxm;
            }
            set
            {
                _sflwxm=value;
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
        //银行卡号
        public string Yhkh
        {
            get
            {
                return _yhkh;
            }
            set
            {
                _yhkh=value;
            }
        }
        //是否工行刷卡
        public string Ghsk
        {
            get
            {
                return _ghsk;
            }
            set
            {
                _ghsk=value;
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
        //客户群
        public string Khq
        {
            get
            {
                return _khq;
            }
            set
            {
                _khq=value;
            }
        }
        //签单日期
        public DateTime Qdrq
        {
            get
            {
                return _qdrq;
            }
            set
            {
                _qdrq=value;
            }
        }
        //起保日期
        public DateTime Qbrq
        {
            get
            {
                return _qbrq;
            }
            set
            {
                _qbrq=value;
            }
        }
        //终保日期
        public DateTime Zbrq
        {
            get
            {
                return _zbrq;
            }
            set
            {
                _zbrq=value;
            }
        }
        //总保费/变动保费
        public decimal Zbf
        {
            get
            {
                return _zbf;
            }
            set
            {
                _zbf=value;
            }
        }
        //商业保费
        public decimal Sybf
        {
            get
            {
                return _sybf;
            }
            set
            {
                _sybf=value;
            }
        }
        //交强保费
        public decimal Jqbf
        {
            get
            {
                return _jqbf;
            }
            set
            {
                _jqbf=value;
            }
        }
        //车船税
        public decimal Cqs
        {
            get
            {
                return _cqs;
            }
            set
            {
                _cqs=value;
            }
        }
        //上年出险总次数
        public string Cxcs
        {
            get
            {
                return _cxcs;
            }
            set
            {
                _cxcs=value;
            }
        }
        //上年承保公司
        public string Sncbgs
        {
            get
            {
                return _sncbgs;
            }
            set
            {
                _sncbgs=value;
            }
        }
        //是否平安
        public string Sfpa
        {
            get
            {
                return _sfpa;
            }
            set
            {
                _sfpa=value;
            }
        }
        //是否优质
        public string Sfyz
        {
            get
            {
                return _sfyz;
            }
            set
            {
                _sfyz=value;
            }
        }
        //出险2次，是否赔付100%
        public string Cx2c
        {
            get
            {
                return _cx2c;
            }
            set
            {
                _cx2c=value;
            }
        }
        //是否采购办
        public string Sfcgb
        {
            get
            {
                return _sfcgb;
            }
            set
            {
                _sfcgb=value;
            }
        }
        //报批
        public decimal Bp
        {
            get
            {
                return _bp;
            }
            set
            {
                _bp=value;
            }
        }
        //备注
        public string Bz
        {
            get
            {
                return _bz;
            }
            set
            {
                _bz=value;
            }
        }
        //特殊类型（第一优先）
        public string Tslx
        {
            get
            {
                return _tslx;
            }
            set
            {
                _tslx=value;
            }
        }
        //追加费用
        public decimal Zjfy
        {
            get
            {
                return _zjfy;
            }
            set
            {
                _zjfy=value;
            }
        }
        //是否有凭证
        public string Sfypz
        {
            get
            {
                return _sfypz;
            }
            set
            {
                _sfypz=value;
            }
        }
        //实际支付市场费用（凭证金额）
        public decimal Sjscfy
        {
            get
            {
                return _sjscfy;
            }
            set
            {
                _sjscfy=value;
            }
        }
        //手续费差异化%
        public decimal Sxfcyh
        {
            get
            {
                return _sxfcyh;
            }
            set
            {
                _sxfcyh=value;
            }
        }
        //手续费金额
        public decimal Sxfje
        {
            get
            {
                return _sxfje;
            }
            set
            {
                _sxfje=value;
            }
        }
        //实际支付报批费用
        public decimal Sjzfbpfy
        {
            get
            {
                return _sjzfbpfy;
            }
            set
            {
                _sjzfbpfy=value;
            }
        }
        //税收
        public decimal Sh
        {
            get
            {
                return _sh;
            }
            set
            {
                _sh=value;
            }
        }
        //自行掌握费用
        public decimal Zxzwfy
        {
            get
            {
                return _zxzwfy;
            }
            set
            {
                _zxzwfy=value;
            }
        }
        //自行掌握费用结余
        public decimal Zxzwfyjy
        {
            get
            {
                return _zxzwfyjy;
            }
            set
            {
                _zxzwfyjy=value;
            }
        }
        //自行掌握费用结余奖励70%
        public decimal Zxzwfyjyjl
        {
            get
            {
                return _zxzwfyjyjl;
            }
            set
            {
                _zxzwfyjyjl=value;
            }
        }
        //补提供凭证差额
        public decimal Btgpzce
        {
            get
            {
                return _btgpzce;
            }
            set
            {
                _btgpzce=value;
            }
        }
        //兑现金额
        public decimal Dxje
        {
            get
            {
                return _dxje;
            }
            set
            {
                _dxje=value;
            }
        }
        //交通通讯费宣传品
        public decimal Jttxf
        {
            get
            {
                return _jttxf;
            }
            set
            {
                _jttxf=value;
            }
        }
        //车险月度固定奖励
        public decimal Cxydjl
        {
            get
            {
                return _cxydjl;
            }
            set
            {
                _cxydjl=value;
            }
        }
        //工行刷卡奖励
        public decimal Ghskjl
        {
            get
            {
                return _ghskjl;
            }
            set
            {
                _ghskjl=value;
            }
        }
        //附件文件名
        public string Attrs
        {
            get
            {
                return _attrs;
            }
            set
            {
                _attrs=value;
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
