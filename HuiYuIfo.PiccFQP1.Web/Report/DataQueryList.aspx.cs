using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using NPOI.HSSF.UserModel;
using System.IO;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using NPOI.XSSF.UserModel;

namespace HuiYuIfo.PiccFQP1.Web.Report
{
    public partial class DataQueryList : BaseListWebFX<YwData, YwQueryDataController>
    {
        private YwQueryDataController controll = new YwQueryDataController();
        public override YwQueryDataController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override YwData GetEntity()
        {
            return new YwData();
        }
        #region extends method
        /// <summary>
        /// 创建实体后期动作
        /// </summary>
        public override void AfterCreateEntity()
        {
            base.AfterCreateEntity();
            if (!IsPostBack)
            {
                if (this.Entity.SysUserType == "ywy")
                {
                    this.Entity.Ywy = this.Entity.SysUserCode;
                    this.Entity.GetOpType = "YwyQuery";
                }
                else
                {
                    this.Entity.GetOpType = "DataQuery";
                }
            }
        }

        public override bool BeforeSubmit()
        {
            switch (Task.Command)
            {
                case "query":
                    GetControllValue(this.Entity, panQry);
                    return false;
            }
            return base.BeforeSubmit();
        }
        /// <summary>
        /// 按钮事件提交后
        /// </summary>
        public override void AfterSubmit()
        {
            switch (Task.Command)
            {
                case "queryExport":
                    XSSFWorkbook book1 = (XSSFWorkbook)Task.paralist[0];

                    //Response.ContentType = "application/vnd.ms-excel";
                    //设置下载的Excel文件名
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "dataExport.xlsx"));
                    //Clear方法删除所有缓存中的HTML输出。但此方法只删除Response显示输入信息，不删除Response头信息。以免影响导出数据的完整性。
                    Response.Clear();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        //将工作簿的内容放到内存流中
                        book1.Write(ms);
                        //将内存流转换成字节数组发送到客户端
                        // Response.BinaryWrite(ms.GetBuffer());
                        System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                        book1 = null;
                        ms.Close();
                        ms.Dispose();
                        Response.End();
                        break;
                    }

            }
            base.AfterSubmit();
        }

        public override void Rebind()
        {
            if (Task.Rebind == true)
            {
                GVNavigater1.Rebind = true;
            }
            else
            {
                GVNavigater1.Rebind = false;
            }
        }
        #endregion

        #region system method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
            GVNavigater1.Rebind = true;
            GVNavigater1.Gridview = this.list;
            GVNavigater1.Entity = this.Entity;
        }
        #endregion
    }
}

