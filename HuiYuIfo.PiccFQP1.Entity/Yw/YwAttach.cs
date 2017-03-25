using System;
using System.Collections.Generic;
using System.Text;
using HuiYuIfo.Framework.Entity;
namespace HuiYuIfo.PiccFQP1.Entity.Yw
{
    [Serializable]
    public class YwAttach:BaseEntity
    {
        public YwAttach():base("YwAttach")
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
        private string _realName = "";
        public string RealName
        {
            get
            {
                return _realName;
            }
            set
            {
                _realName = value;
            }
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
        //did
        private int _did=0;
        //文件夹
        private string _dic="";
        //文件名
        private string _fileN="";
        //对应数据
        private int _dataid=0;
        
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
        //文件夹
        public string Dic
        {
            get
            {
                return _dic;
            }
            set
            {
                _dic=value;
            }
        }
        //文件名
        public string FileN
        {
            get
            {
                return _fileN;
            }
            set
            {
                _fileN=value;
            }
        }
        //对应数据
        public int Dataid
        {
            get
            {
                return _dataid;
            }
            set
            {
                _dataid=value;
            }
        }
       
    }
}
