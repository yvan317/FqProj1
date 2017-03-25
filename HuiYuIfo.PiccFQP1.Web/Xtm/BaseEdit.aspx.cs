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
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Web.Xtm
{
    public partial class BaseEdit : BaseEditWebFX<XtmConfig, XtmConfigController>
    {
        private XtmConfigController controll = new XtmConfigController();
        public override XtmConfigController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override XtmConfig GetEntity()
        {
            return new XtmConfig();
        }


        #region extends method

        /// <summary>
        /// 创建实体后期动作
        /// </summary>
        public override void AfterCreateEntity()
        {
            base.AfterCreateEntity();
            if (!IsPostBack)
            {
                BaseDao baseDao = new BaseDao();
                XtmConfig config = new XtmConfig();
                IList<XtmConfig> list = baseDao.List(config);
                if (list != null && list.Count > 0)
                {
                    this.Entity = list[0];
                }
            }
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
                    return Check();
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

            }
        }
        #endregion

        private bool Check()
        {
            int temp = 0;
            if (Entity.Bcsry != null && Entity.Bcsry != "")
            {
                try
                {
                    temp = int.Parse(Entity.Bcsry);
                    if (temp < 0||temp>100)
                    {
                        errmsg = "保车上人员基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "保车上人员基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Bcsry = "0";
            }

            if (Entity.Bdqx != null && Entity.Bdqx != "")
            {
                try
                {
                    temp = int.Parse(Entity.Bdqx);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "保盗抢险基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "保盗抢险基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Bdqx = "0";
            }

            if (Entity.Bzrx != null && Entity.Bzrx != "")
            {
                try
                {
                    temp = int.Parse(Entity.Bzrx);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "保自燃险基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "保自燃险基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Bzrx = "0";
            }

            if (Entity.Bfdj != null && Entity.Bfdj != "")
            {
                try
                {
                    temp = int.Parse(Entity.Bfdj);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "保发动机基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "保发动机基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Bfdj = "0";
            }


            if (Entity.Sz100 != null && Entity.Sz100 != "")
            {
                try
                {
                    temp = int.Parse(Entity.Sz100);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "三者100万基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "三者100万基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Sz100 = "0";
            }

            if (Entity.Tx != null && Entity.Tx != "")
            {
                try
                {
                    temp = int.Parse(Entity.Tx);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "推修基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "推修基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Tx = "0";
            }

            if (Entity.Tx != null && Entity.Tx != "")
            {
                try
                {
                    temp = int.Parse(Entity.Tx);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "推修基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "推修基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Tx = "0";
            }


            if (Entity.Yzpa != null && Entity.Yzpa != "")
            {
                try
                {
                    temp = int.Parse(Entity.Yzpa);
                    if (temp < 0 || temp > 100)
                    {
                        errmsg = "优质平安基数 应该为 0 到100 之间的整数";
                        return false;
                    }
                }
                catch
                {
                    errmsg = "优质平安基数 应该为 0 到100 之间的整数";
                    return false;
                }
            }
            else
            {
                Entity.Yzpa = "0";
            }

            return true;
        }

    }
}

