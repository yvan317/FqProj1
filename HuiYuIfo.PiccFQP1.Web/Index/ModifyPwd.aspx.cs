using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.Framework.Library;

namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public partial class ModifyPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void butSave_Click(object sender, EventArgs e)
        {
            string errmsg = "";
            if (this.xmm.Text == "")
            {
                this.laberr.Text = "新密码不能为空";
                return;
            }
            if (this.qrmm.Text == "")
            {
                this.laberr.Text = "确认密码不能为空";
                return;
            }
            if (this.xmm.Text.Trim() != this.qrmm.Text.Trim())
            {
                this.laberr.Text = "新密码和确认密码不一致";
                return;
            }
            if (this.ymm.Text.Trim() == "")
            {
                this.laberr.Text = "原密码不能为空";
                return;
            }
            BaseDao baseDao=new BaseDao();

            XtmUser user = new XtmUser();
            user.Did = int.Parse(user.SysUserId);
            user = baseDao.Get(user);
           
            if (user != null)
            {
                string encryymm = Encry.Encode(this.ymm.Text.Trim());
                if (user.UserPwd != encryymm)
                {
                    this.laberr.Text = "原密码不正确";
                }
                else
                {
                    user.UserPwd=Encry.Encode(this.xmm.Text.Trim());
                    baseDao.Update(user);
                    Page.RegisterStartupScript("close", "<script language='javascript'>alert('修改成功');window.close();</script>");
                }
            }
            else
            {
                this.laberr.Text = "取用户资料出错";
            }
        }
    }
}