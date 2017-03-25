using System;
using System.Web;
using System.Web.UI;

namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public class TimeOut
    {
        public static void ExecTimeOut(Page apage)
        {
            apage.Response.Write("<script type=\"text/javascript\" language=\"javascript\"> window.alert('用户登录时间失效，请重新登陆！');top.location.href='../Login.aspx'; </script>");
            return;
        }
    }
}