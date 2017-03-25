using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Library;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.Framework.Core;

namespace HuiYuIfo.PiccFQP1.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            XtmUser userM = new XtmUser();
            userM.UserCode = this.txtUsername.Text.Trim();
            userM.UserPwd = Encry.Encode(this.txtUserpwd.Text.Trim());
            BaseDao baseDao = new BaseDao();
            IList<XtmUser> userL = baseDao.List<XtmUser>(userM);
            if (userL != null && userL.Count > 0)
            {
                userM = userL[0];
                if (userM.Status != "x")
                {
                    Page.RegisterStartupScript("onclick", "<script>alert('账号已停用')</script>");
                }
                else
                {
                    CoreCache.SetCache("SysDepartId", userM.DepartId);
                    CoreCache.SetCache("SysUserType", userM.UserType);
                    CoreCache.SetCache("SysUserId", userM.Did);
                    CoreCache.SetCache("SysUserCode", userM.UserCode);
                    CoreCache.SetCache("SysUserName", userM.UserName);
                    Response.Redirect("Index/content.htm");
                }
            }
            else
            {
                Page.RegisterStartupScript("onclick", "<script>alert('账号或密码错误')</script>");
            }

        }

    }
}