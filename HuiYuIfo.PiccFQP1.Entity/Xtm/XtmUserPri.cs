using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Xtm
{
    [Serializable]
    public class XtmUserPri:BaseEntity
    {
        public XtmUserPri():base("XtmUserPri")
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
        //用户id
        private int _userId = 0;
        //权限类型
        private string _priType = "";
        //权限id
        private int _priId = 0;
        //权限值
        private string _priVal = "";
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
        //用户id
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
        //权限类型
        public string PriType
        {
            get
            {
                return _priType;
            }
            set
            {
                _priType=value;
            }
        }
        //权限id
        public int PriId
        {
            get
            {
                return _priId;
            }
            set
            {
                _priId=value;
            }
        }
        //权限值
        public string PriVal
        {
            get
            {
                return _priVal;
            }
            set
            {
                _priVal=value;
            }
        }
    }
}
