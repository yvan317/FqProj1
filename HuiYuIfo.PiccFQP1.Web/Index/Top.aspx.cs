using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Core;
using System.Web.Security;

namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public partial class Top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CoreCache.GetCache("SysUserCode") == null)
            {
                TimeOut.ExecTimeOut(this);
                return;
            }
            this.labUserName.Text = CoreCache.GetCache("SysUserName").ToString();
            switch (CoreCache.GetCache("SysUserType").ToString())
            {
                case "man":
                    this.labUserType.Text = "管理员";
                    break;
                case "ywy":
                    this.labUserType.Text = "业务员";
                    break;
                case "yh":
                    this.labUserType.Text = "普通用户";
                    break;
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Write(" <script language=JavaScript>top.location.href= '../Login.aspx '; </script> ");
        }

        protected void butModifyPwd_Click(object sender, EventArgs e)
        {
            if (CoreCache.GetCache("SysUserCode") == null)
            {
                TimeOut.ExecTimeOut(this);
                return;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Close", "<script language=JavaScript>open('../Index/ModifyPwd.aspx','modifyPwd','height=200,width=300,top=0,left=0,toolbar=no,menubar=no,scrollbars=no, resizable=no,location=no, status=no'); </script>");
        }

    }
}
