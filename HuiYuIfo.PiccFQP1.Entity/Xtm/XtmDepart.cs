using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmDepart:BaseEntity
    {

        public XtmDepart():base("XtmDepart")
        {
        }
        private string _parentName = "";
        public string ParentName
        {
            get
            {
                return _parentName;
            }
            set
            {
                _parentName = value;
            }
        }
        private string _complexName = "";
        public string ComplexName
        {
            get
            {
                return _complexName;
            }
            set
            {
                _complexName = value;
            }
        }

        private int _userid = 0;
        public int UserId
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }
        private string _pri = "";
        public string Pri
        {
            get
            {
                return _pri;
            }
            set
            {
                _pri = value;
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
        private string _departCode="";
        //部门名称
        private string _departName="";
        //隶属部门
        private int _parentId=0;
        //部门层级
        private int _departLayer = 0;
        //部门状态
        private string _status = "";
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
        public string DepartCode
        {
            get
            {
                return _departCode;
            }
            set
            {
                _departCode=value;
            }
        }
        //部门名称
        public string DepartName
        {
            get
            {
                return _departName;
            }
            set
            {
                _departName=value;
            }
        }
        //隶属部门
        public int ParentId
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId=value;
            }
        }
        //部门层级
        public int DepartLayer
        {
            get
            {
                return _departLayer;
            }
            set
            {
                _departLayer=value;
            }
        }
        //部门状态
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
