using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.PiccFQP1.Controller.Xtm;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Web;

namespace HuiYuIfo.PiccFQP1.Web.Xtm
{
    public partial class MenuPriEdit : BaseEditWebFX<XtmUser,XtmUserController>
    {
        private XtmUserController controll = new XtmUserController();
        public override XtmUserController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override XtmUser GetEntity()
        {
            return new XtmUser();
        }
        #region system method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Did.Value = this.Entity.Did.ToString();
            }
        }
        #endregion
    }
}

