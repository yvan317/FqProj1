using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Web;
using HuiYuIfo.PiccFQP1.Controller.Yw;
using HuiYuIfo.PiccFQP1.Entity.Yw;
using HuiYuIfo.Framework.UiProcess;
using System.Collections;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class CbCreate : BaseEditWebFX<YwData, YwCbDataController>
    {
        private YwCbDataController controll = new YwCbDataController();
        public override YwCbDataController WebCon
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
                case "cbCreateSave":
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
                this.Entity.Year = DateTime.Now.Year;
                this.Entity.Month = DateTime.Now.Month;

                string cllx = System.Configuration.ConfigurationManager.AppSettings["Cllx"].Trim();
                WebUiProcess.InitDropDownList(this.Clxs, cllx, ref errmsg);

                string ywly = System.Configuration.ConfigurationManager.AppSettings["Ywly"].Trim();
                WebUiProcess.InitDropDownList(this.Ywly, ywly, ref errmsg);

                string szxbf = System.Configuration.ConfigurationManager.AppSettings["Szxbf"].Trim();
                WebUiProcess.InitDropDownList(this.Szxbf, szxbf, ref errmsg);

                string nxConfig = System.Configuration.ConfigurationManager.AppSettings["NxConfig"].Trim();
                WebUiProcess.InitDropDownList(this.Synx, nxConfig, ref errmsg);

                string Cxcs = System.Configuration.ConfigurationManager.AppSettings["Cxcs"].Trim();
                WebUiProcess.InitDropDownList(this.Cxcs, Cxcs, ref errmsg);

                WebUiProcess.InitDropDownList(this.Depart, "ddlCbDepart", null, ref errmsg);
            }
        }
        #endregion
        protected void Depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Depart.SelectedValue == "")
            {
                this.Ywy.Items.Clear();
                this.Ywy.SelectedValue = "";
            }
            else
            {
                BaseDao baseDao = new BaseDao();
                Hashtable ht = new Hashtable();
                XtmDepart de = new XtmDepart();
                de.DepartCode = Depart.SelectedValue;
                IList<XtmDepart> depL = baseDao.List(de);
                if (depL != null && depL.Count > 0)
                {
                    ht.Add("depart", depL[0].Did);
                    WebUiProcess.InitDropDownList(this.Ywy, "ddlCbYwy", ht, ref errmsg);
                }
                //Hashtable ht = new Hashtable();
                //ht.Add("depart", Depart.SelectedValue);
                //WebUiProcess.InitDropDownList(this.Ywy, "ddlCbYwy", ht, ref errmsg);
            }
        }

    }


}

