using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmUser:BaseEntity
    {
        public XtmUser():base("XtmUser")
        {
        }
        private string _departCode = "";
        public string DepartCode
        {
            get
            {
                return _departCode;
            }
            set
            {
                _departCode = value;
            }
        }
        private string _departName = "";
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
        //用户帐号
        private string _userCode="";
        //用户名称
        private string _userName="";
        //用户密码
        private string _userPwd="";
        //用户状态
        private string _status="";
        //用户类型
        private string _userType="";
        //隶属部门
        private int _departId = 0;
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
        //用户帐号
        public string UserCode
        {
            get
            {
                return _userCode;
            }
            set
            {
                _userCode=value;
            }
        }
        //用户名称
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName=value;
            }
        }
        //用户密码
        public string UserPwd
        {
            get
            {
                return _userPwd;
            }
            set
            {
                _userPwd=value;
            }
        }
        //用户状态
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
        public string StatusName
        {
            get
            {
                switch (_status)
                {
                    case "x":
                        return "正常";
                    case "z":
                        return "停用";
                    default:
                        return "";
                }
            }
        }
        //用户类型
        public string UserType
        {
            get
            {
                return _userType;
            }
            set
            {
                _userType=value;
            }
        }
        public string UserTypeName{
            get
            {
                switch (_userType)
                {
                    case "man":
                        return "管理员";
                    case "yh":
                        return "普通用户";
                    case "ywy":
                        return "业务员";
                    default:
                        return "";
                }
            }
        }
       
        //隶属部门
        public int DepartId
        {
            get
            {
                return _departId;
            }
            set
            {
                _departId=value;
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
