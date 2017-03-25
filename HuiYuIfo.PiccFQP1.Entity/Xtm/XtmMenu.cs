using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmMenu:BaseEntity
    {
        public XtmMenu():base("XtmMenu")
        {
        }
        private string _type = "";
        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
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
        //菜单编码
        private string _menuCode="";
        //菜单名称
        private string _menuName="";
        //菜单地址
        private string _menuConfig="";
        //父菜单编码
        private int _parentId = 0;
        //菜单层级
        private int _menuLayer = 0;
        //菜单状态
        private string _status="";
        //排序
        private string _sort="";
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
        //菜单编码
        public string MenuCode
        {
            get
            {
                return _menuCode;
            }
            set
            {
                _menuCode=value;
            }
        }
        //菜单名称
        public string MenuName
        {
            get
            {
                return _menuName;
            }
            set
            {
                _menuName=value;
            }
        }
        //菜单地址
        public string MenuConfig
        {
            get
            {
                return _menuConfig;
            }
            set
            {
                _menuConfig=value;
            }
        }
        //父菜单编码
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
        //菜单层级
        public int MenuLayer
        {
            get
            {
                return _menuLayer;
            }
            set
            {
                _menuLayer=value;
            }
        }
        //菜单状态
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
        public string StatusName(){
            switch (_status){
                case "x":
                    return "正常";
                case "z":
                    return "停用";
                default:
                    return "";
            }
        }
        //排序
        public string Sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort=value;
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
