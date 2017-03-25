using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using System.IO;
using NPOI.SS.UserModel;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class CbImport : BaseEditWebFX<YwData, YwCbDataController>
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
        }
        /// <summary>
        /// 实例化实体前期动作
        /// </summary>
        /// <returns></returns>
        public override bool BeforeInitEntity()
        {
            return base.BeforeInitEntity();
        }
        /// <summary>
        /// 实例化实体后期动作
        /// </summary>
        public override void AfterInitEntity()
        {
            base.AfterInitEntity();
        }
        /// <summary>
        /// 初始化页面时候初始化控件
        /// </summary>
        public override void InitController()
        {
            this.InitPanController(panCon);
            base.InitController();
        }

        public override bool BeforeSubmit()
        {

            switch (Task.Command)
            {
                case "cbImportSave":
                    string fullPath = "";
                    string upload = "/dataUpload/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
                    string fileName = "";
                    if (cyhFile.HasFile == false)
                    {
                        errmsg = "请选择文件";
                        return false;
                    }
                    string fileTrie = System.IO.Path.GetExtension(cyhFile.PostedFile.FileName).ToLower();
                    if (fileTrie != ".xls" && fileTrie != ".xlsx")
                    {
                        this.errmsg = "上传的文件类型不符合！";
                        return false;
                    }

                    string destDir = Server.MapPath(Request.ApplicationPath.ToString()) + upload;
                    if (!Directory.Exists(destDir))
                        Directory.CreateDirectory(destDir);
                    try
                    {
                        //保存到指定目录

                        fileName = Path.GetFileName(cyhFile.PostedFile.FileName);
                        System.Guid guid = Guid.NewGuid();
                        fileName = guid.ToString() + ".xls";
                        fullPath = Path.Combine(destDir, fileName);
                        cyhFile.PostedFile.SaveAs(fullPath);
                    }
                    catch (Exception)
                    {
                        this.errmsg = "保存文件出错!";
                        return false;
                    }
                    if (Task.paralist == null)
                    {
                        Task.paralist = new System.Collections.ArrayList();
                    }
                    Task.paralist.Add(fullPath);
                    break;

            }
            return base.BeforeSubmit();
        }
        /// <summary>
        /// 按钮事件提交后
        /// </summary>
        public override void AfterSubmit()
        {
                    if (Task.paralist != null && Task.paralist.Count > 0)
                    {
                        IWorkbook errorBook = (IWorkbook)Task.paralist[0];

                        //Response.ContentType = "application/vnd.ms-excel";
                        //设置下载的Excel文件名
                        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "dataExport.xlsx"));
                        //Clear方法删除所有缓存中的HTML输出。但此方法只删除Response显示输入信息，不删除Response头信息。以免影响导出数据的完整性。
                        Response.Clear();

                        using (MemoryStream ms = new MemoryStream())
                        {
                            //将工作簿的内容放到内存流中
                            errorBook.Write(ms);
                            //将内存流转换成字节数组发送到客户端
                            // Response.BinaryWrite(ms.GetBuffer());
                            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                            errorBook = null;
                            ms.Close();
                            ms.Dispose();
                            Response.End();
                        }
                    }
               
            base.AfterSubmit();
        }
        /// <summary>
        /// 刷新页面
        /// </summary>
        public override void Rebind()
        {
            if (Task.Rebind == true)
            {
                this.InitPanController(panCon);
            }
            base.Rebind();
        }

        #endregion

        #region system method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        #endregion
    }
}

