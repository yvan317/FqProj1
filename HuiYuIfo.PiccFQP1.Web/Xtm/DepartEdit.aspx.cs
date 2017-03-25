using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.PiccFQP1.Controller.Xtm;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.Framework.UiProcess;

namespace HuiYuIfo.PiccFQP1.Web.Xtm
{
    public partial class DepartEdit : BaseEditWebFX<XtmDepart, XtmDepartController>
    {
        private XtmDepartController controll = new XtmDepartController();
        public override XtmDepartController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override XtmDepart GetEntity()
        {
            return new XtmDepart();
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
                case "save":
                    this.GetControllValue(Entity, panCon);
                    Entity.Status = "x";
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
                WebUiProcess.InitDropDownList(this.ParentId, "ddlDepart", null, ref errmsg);
                if (Task.ParentCommand != "ucreate")
                {
                    this.DepartCode.Enabled = false;
                }
                else
                {
                    this.DepartCode.Attributes.Add("style", "background-color:#FFFFAA");
                }
            }
        }
        #endregion


    }
}

