using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Web
{
    public class Global : System.Web.HttpApplication
    {
        System.Timers.Timer WatchTimer = new System.Timers.Timer();
        private bool running = true;
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            HuiYuIfo.Framework.Core.AppCache.DealWebConfig(Server.MapPath("~/") + "/Content/Config");
            int waitTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["waitTime"].ToString());
            WatchTimer.Interval = 1000 * 60 * waitTime;
            WatchTimer.Elapsed += new System.Timers.ElapsedEventHandler(WatchTimer_Elapsed);
            WatchTimer.Start();
            running = true;
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }
        void WatchTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (running == true)
            {
                try
                {
                    WatchTimer.Enabled = false;
                    running = false;
                    int startTime = int.Parse(System.Configuration.ConfigurationManager.AppSettings["startTime"].ToString());
                    if (DateTime.Now.Hour > startTime)
                    {
                        BaseDao baseDao = new BaseDao();
                        XtmConfig config = new XtmConfig();
                        config = baseDao.Get(config);
                        bool result = false;

                        if (DateTime.Now.Day >= int.Parse(config.Config1))
                        {
                            if (config.Config3 == "")
                            {
                                result = true;
                            }
                            else
                            {
                                DateTime st1 = DateTime.Parse(config.Config3);
                                DateTime st2 = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01").AddMonths(-1);
                                if (st1.CompareTo(st2)==0)
                                {
                                    result=false;
                                }
                                else
                                {
                                    result = true;
                                }
                            }
                        }
                        if (result == true)
                        {
                            DealJZ();
                        }
                    }

                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }
                finally
                {
                    WatchTimer.Enabled = true;
                    running = true;
                }
            }
        }
        private void DealJZ()
        {
            string errmsg = "";
            YwDataController controller = new YwDataController();
            Framework.Task.Task task = new Framework.Task.Task();
            task.Command = "jz";
            controller.Execute(task,ref errmsg);
        }
    }
}
