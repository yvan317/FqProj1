using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwTxjs:BaseEntity
    {
        public YwTxjs():base("YwTxjs")
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
        private string _xlc = "";
        private string _zy = "";
        public string Xlc
        {
            get
            {
                return _xlc;
            }
            set
            {
                _xlc = value;
            }
        }
        public string Zy
        {
            get
            {
                return _zy;
            }
            set
            {
                _zy = value;
            }
        }
        //did
        private int _did;
        //推修码
        private string _Txm;
        //推修系数值
        private string _Xs;
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
        //推修码
        public string Txm
        {
            get
            {
                return _Txm;
            }
            set
            {
                _Txm=value;
            }
        }
        //推修系数值
        public string Xs
        {
            get
            {
                return _Xs;
            }
            set
            {
                _Xs=value;
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
