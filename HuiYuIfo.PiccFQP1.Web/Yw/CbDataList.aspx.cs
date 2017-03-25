using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using NPOI.SS.UserModel;
using System.IO;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class CbDataList : BaseListWebFX<YwData, YwCbDataController>
    {
        private YwCbDataController controll = new YwCbDataController();
        public override YwCbDataController WebCon
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
                BaseDao baseDao = new BaseDao();
                XtmConfig config = new XtmConfig();
                config = baseDao.Get(config);
                int jzr = int.Parse(config.Config1);
                if (DateTime.Now.Day > jzr)
                {
                    this.Entity.BegD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");
                    this.Entity.Jz = true;
                }
                else
                {
                    this.Entity.Jz = false;
                    DateTime dtt = DateTime.Now.AddMonths(-1);
                    this.Entity.BegD = DateTime.Parse("" + dtt.Year + "-" + dtt.Month + "-01");
                }
                this.Entity.GetOpType = "CbList";
            }
        }

        public override bool BeforeSubmit()
        {
            switch (Task.Command)
            {
                case "cbExportPriNoEnd":
                    //导出上期未处理数据
                    if (this.Entity.Jz == true)
                    {
                        errmsg = "上月帐期已经过了，不能导出数据";
                        Task.Submit = false;
                    }
                    break;
                case "cbExportPriAll":
                    //导出上期所有数据
                    if (this.Entity.Jz == true)
                    {
                        errmsg = "上月帐期已经过了，不能导出数据";
                        Task.Submit = false;
                    }
                    break;
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
                
                case "cbExportPriNoEnd":
                case "cbExportPriAll":
                case "cbExportNowNoend":
                case "cbExportNowAll":
                    IWorkbook book1 = (IWorkbook)Task.paralist[0];

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

