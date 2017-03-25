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
using System.Collections;
using HuiYuIfo.Framework.UiProcess;

namespace HuiYuIfo.PiccFQP1.Web.Report
{
    public partial class HistoryQueryList : BaseListWebFX<YwData, YwQueryDataController>
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
                //BaseDao baseDao = new BaseDao();
                //XtmConfig config = new XtmConfig();
                //config = baseDao.Get(config);
                //int jzr = int.Parse(config.Config1);
                //if (DateTime.Now.Day > jzr)
                //{
                //    this.Entity.BegD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");

                //}
                //else
                //{
                //    DateTime dtt = DateTime.Now.AddMonths(-1);
                //    this.Entity.BegD = DateTime.Parse("" + dtt.Year + "-" + dtt.Month + "-01");
                //}
                this.Entity.Ywy = this.Entity.SysUserCode;
                this.Entity.GetOpType = "YwyQuery";
            }
        }

        public override bool BeforeSubmit()
        {
            switch (Task.Command)
            {
                case "historyExport":
                    GetControllValue(this.Entity, panQry);
                    break;
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
                case "historyExport":
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
            
        }
        #endregion

        #region system method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 统计区间段
                string yearT = "";
                int nowYear = DateTime.Now.Year;
                for (int i = 0; i < 10; i++)
                {
                    string temp = (nowYear - i).ToString();
                    if (i == 9)
                    {
                        yearT += temp + "," + temp ;
                    }
                    else
                    {
                        yearT += temp + "," + temp + "|";
                    }
                }
                WebUiProcess.InitDropDownList(this.Year, yearT, ref errmsg);
                this.Year.SelectedValue = DateTime.Now.Year.ToString();
                string monthT = "";
                for (int i = 1; i < 13; i++)
                {
                    string temp = i.ToString();
                    if (i == 12)
                    {
                        monthT += temp + "," + temp;
                    }
                    else
                    {
                        monthT += temp + "," + temp + "|";
                    }
                }
                WebUiProcess.InitDropDownList(this.Month, monthT, ref errmsg);
                this.Month.SelectedValue = DateTime.Now.Month.ToString();
                #endregion

                #region 部门、业务员
                if (this.Entity.SysUserType == "ywy")
                {

                    this.Depart.Enabled = false;

               
                    this.Ywy.Enabled = false;
                }
                else
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("userId", this.Entity.SysUserId);
                    WebUiProcess.InitDropDownList(this.Depart, "ddlCbDepartByPri", ht, ref errmsg);
                }

                #endregion 

            }
            
        }
        #endregion

        protected void Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Depart.SelectedValue == "")
            {
                this.Ywy.Items.Clear();
                this.Ywy.SelectedValue = "";
            }
            else
            {
                BaseDao baseDao = new BaseDao();
                Hashtable ht = new Hashtable();
                XtmDepart de = new XtmDepart();
                de.DepartCode = Depart.SelectedValue;
                IList<XtmDepart> depL = baseDao.List(de);
                if (depL != null && depL.Count > 0)
                {
                    ht.Add("depart", depL[0].Did);
                    WebUiProcess.InitDropDownList(this.Ywy, "ddlCbYwy", ht, ref errmsg);
                }
            }
        }
    }
}