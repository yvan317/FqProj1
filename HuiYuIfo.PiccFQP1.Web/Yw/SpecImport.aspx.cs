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

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class SpecImport : BaseEditWebFX<YwSpec, YwSpecController>
    {
        private YwSpecController controll = new YwSpecController();
        public override YwSpecController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override YwSpec GetEntity()
        {
            return new YwSpec();
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
                case "importSave":
                    string fullPath = "";
                    string upload = "/upload/" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day;
                    string fileName = "";
                    if (specFile.HasFile == false)
                    {
                        errmsg = "请选择文件";
                        return false;
                    }
                    string fileTrie = System.IO.Path.GetExtension(specFile.PostedFile.FileName).ToLower();
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

                            fileName = Path.GetFileName(specFile.PostedFile.FileName);
                            System.Guid guid = Guid.NewGuid();
                            fileName = guid.ToString() + ".xls";
                            fullPath = Path.Combine(destDir, fileName);
                            specFile.PostedFile.SaveAs(fullPath);
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

