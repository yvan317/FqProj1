using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using HuiYuIfo.PiccFQP1.Entity.Yw;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class SpecEdit : BaseEditWebFX<YwSpec, YwSpecController>
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

                if (Task.ParentCommand != "ucreate")
                {
                    this.SpecName.Enabled = false;
                }
                else
                {
                    this.SpecName.Attributes.Add("style", "background-color:#FFFFAA");
                }
            }
        }
        #endregion


    }
}

