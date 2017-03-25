using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class YwyDataList : BaseListWebFX<YwData, YwYwyDataController>
    {
        private YwYwyDataController controll = new YwYwyDataController();
        public override YwYwyDataController WebCon
        {
            get
            {
                return controll;
            }
        }
        public override YwData GetEntity()
        {
            return new YwData();
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
                this.Entity.Ywy = this.Entity.SysUserCode;
                BaseDao baseDao = new BaseDao();
                XtmConfig config = new XtmConfig();
                config = baseDao.Get(config);
                int jzr = int.Parse(config.Config1);
                if (DateTime.Now.Day > jzr)
                {
                    this.Entity.BegD = DateTime.Parse("" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-01");

                }
                else
                {
                    DateTime dtt = DateTime.Now.AddMonths(-1);
                    this.Entity.BegD = DateTime.Parse("" + dtt.Year + "-" + dtt.Month + "-01");
                }
                this.Entity.GetOpType = "YwyList";
            }
        }

        public override bool BeforeSubmit()
        {
            switch (Task.Command)
            {
                case "query":
                    GetControllValue(this.Entity, panQry);
                    return false;
            }
            return base.BeforeSubmit();
        }
        /// <summary>
        /// 按钮事件提交后
        /// </summary>
        public override void AfterSubmit()
        {
            switch (Task.Command)
            {
                
            }
            base.AfterSubmit();
        }

        public override void Rebind()
        {
            if (Task.Rebind == true)
            {
                GVNavigater1.Rebind = true;
            }
            else
            {
                GVNavigater1.Rebind = false;
            }
        }
        #endregion

        #region system method
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


            }
            GVNavigater1.Rebind = true;
            GVNavigater1.Gridview = this.list;
            GVNavigater1.Entity = this.Entity;
        }
        #endregion
    }
}

