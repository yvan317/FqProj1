using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.UiProcess;
namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class ChargeEdit : BaseEditWebFX<YwCyh, YwCyhController>
    {
        private YwCyhController controll = new YwCyhController();
        public override YwCyhController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override YwCyh GetEntity()
        {
            return new YwCyh();
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
            if (Task.ParentCommand == "ucreate")
            {
                this.Zhcxcs.SelectedIndex = 0;
                this.Synx.SelectedIndex = 0;
            }
        }

        public override bool BeforeSubmit()
        {
            switch (Task.Command)
            {
                case "save":
                    this.GetControllValue(Entity, panCon);
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
                string Sxflx = System.Configuration.ConfigurationManager.AppSettings["Sxflx"].Trim();
                WebUiProcess.InitDropDownList(this.Sxflx, Sxflx, ref errmsg);

                string xz = System.Configuration.ConfigurationManager.AppSettings["Xz"].Trim();
                WebUiProcess.InitDropDownList(this.Xz, xz, ref errmsg);

                

                string ywly = System.Configuration.ConfigurationManager.AppSettings["Ywly"].Trim();
                WebUiProcess.InitDropDownList(this.Ywly, ywly, ref errmsg);

                string nxConfig = System.Configuration.ConfigurationManager.AppSettings["NxConfig"].Trim();
                WebUiProcess.InitDropDownList(this.Synx, nxConfig, ref errmsg);

                string Cxcs = System.Configuration.ConfigurationManager.AppSettings["Cxcs"].Trim();
                WebUiProcess.InitDropDownList(this.Zhcxcs, Cxcs, ref errmsg);


                if (Task.ParentCommand != "ucreate")
                {
                    this.Xz.Enabled = false;
                    this.Dbdsz.Enabled = false;
                    this.Dbjq.Enabled = false;
                    this.Sxflx.Enabled = false;
                    this.Ywly.Enabled = false;
                    this.Wfglcxcs.Enabled = false;
                    this.Zhcxcs.Enabled = false;
                    this.Synx.Enabled = false;
                    this.Sfbcs.Enabled = false;
                    this.Pfvsfc100.Enabled = false;
                    this.Cx3c.Enabled = false;
                    //this.Bcsry.Enabled = false;
                    //this.Bdqx.Enabled = false;
                    //this.Bzrx.Enabled = false;
                    //this.Bfdj.Enabled = false;
                    //this.Sz100.Enabled = false;
                    //this.Qx.Enabled = false;
                }
                else
                {
                    this.Xz.Attributes.Add("style","background-color:#FFFFAA");
                    this.Dbdsz.Attributes.Add("style","background-color:#FFFFAA");
                    this.Dbjq.Attributes.Add("style","background-color:#FFFFAA");
                    this.Sxflx.Attributes.Add("style", "background-color:#FFFFAA");

                    this.Ywly.Attributes.Add("style","background-color:#FFFFAA");
                    this.Wfglcxcs.Attributes.Add("style", "background-color:#FFFFAA");


                    this.Zhcxcs.Attributes.Add("style","background-color:#FFFFAA");
                    this.Synx.Attributes.Add("style","background-color:#FFFFAA");
                    this.Sfbcs.Attributes.Add("style","background-color:#FFFFAA");
                    this.Pfvsfc100.Attributes.Add("style","background-color:#FFFFAA");
                    this.Cx3c.Attributes.Add("style", "background-color:#FFFFAA");
                    this.Bcsry.Attributes.Add("style", "background-color:#FFFFAA");
                    this.Bdqx.Attributes.Add("style", "background-color:#FFFFAA");
                    this.Bzrx.Attributes.Add("style", "background-color:#FFFFAA");
                    this.Bfdj.Attributes.Add("style", "background-color:#FFFFAA");
                    this.Sz100.Attributes.Add("style", "background-color:#FFFFAA");
                   
                }
            }
        }
        #endregion
    }
}

