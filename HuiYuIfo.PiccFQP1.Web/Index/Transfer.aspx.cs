using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Task;
using HuiYuIfo.Framework.Core;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.UiProcess;
namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public partial class Transfer : System.Web.UI.Page
    {
        protected Task task;
        private string errmsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CoreCache.GetCache("SysUserCode") == null)
            {
                TimeOut.ExecTimeOut(this);
                return;
            }
            string usertype = CoreCache.GetCache("SysUserType").ToString();

            XtmMenu menu = new XtmMenu();
            menu.SysKey = Request.QueryString["Action"].ToString();
            
            menu = WebUiProcess.Get(menu);
            if (errmsg != "")
            {
                Response.Write("加载页面出错：" + errmsg);
                Response.End();
                return;
            }
            if (menu.Pri == "n" && usertype != "man")
            {
                Response.Write("您没有操作该页面的权限，请和管理员联系！");
                Response.End();
            }
            else
            {
                string strurl = "../" + menu.MenuConfig;
                Navigate(strurl, menu.MenuCode);
            }
        }

        public void Navigate(string url, string menucode)
        {
            task = new Task();
            task.TaskId = Guid.NewGuid().ToString();
            Session[task.TaskId] = task;
            url += "?tid=" + task.TaskId;
            HttpContext.Current.Response.Redirect(url);
        }
    }
}
