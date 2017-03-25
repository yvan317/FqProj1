using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmMenuPri:BaseEntity
    {
        public XtmMenuPri():base("XtmMenuPri")
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
        //用户Id
        private int _userId = 0;
        //菜单Id
        private int _menuId = 0;
        //菜单编码
        private string _menuCode = "";
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
        //用户Id
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId=value;
            }
        }
        //菜单Id
        public int MenuId
        {
            get
            {
                return _menuId;
            }
            set
            {
                _menuId=value;
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
    }
}
