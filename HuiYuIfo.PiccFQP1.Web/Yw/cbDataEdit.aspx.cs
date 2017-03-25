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
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using HuiYuIfo.Framework.Dao;

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class cbDataEdit : BaseEditWebFX<YwData, YwCbDataController>
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
                case "cbSave":
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
                string Cxcs = System.Configuration.ConfigurationManager.AppSettings["Cxcs"].Trim();
                WebUiProcess.InitDropDownList(this.Cxcs, Cxcs, ref errmsg);

                WebUiProcess.InitDropDownList(this.Depart, "ddlCbDepart", null, ref errmsg);
                if (Entity.Depart!=null&&Entity.Depart != "")
                {
                    BaseDao baseDao=new BaseDao();
                    Hashtable ht = new Hashtable();
                    XtmDepart de = new XtmDepart();
                    de.DepartCode = Entity.Depart;
                    IList<XtmDepart> depL = baseDao.List(de);
                    if (depL != null && depL.Count > 0)
                    {
                        ht.Add("depart", depL[0].Did);
                        WebUiProcess.InitDropDownList(this.Ywy, "ddlCbYwy", ht, ref errmsg);
                    }
                }
                
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
            }
        }
    }
}

