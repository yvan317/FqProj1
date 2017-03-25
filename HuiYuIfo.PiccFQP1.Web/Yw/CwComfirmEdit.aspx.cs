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

namespace HuiYuIfo.PiccFQP1.Web.Yw
{
    public partial class CwComfirmEdit : BaseEditWebFX<YwData, YwCwDataController>
    {
        private YwCwDataController controll = new YwCwDataController();
        public override YwCwDataController WebCon
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
                case "cwUnComfirm":
                case "cwSave":
                    this.GetControllValue(Entity, panCon);
                    break;
                case "downAtt":
                    DealDownAtt();
                    break;

            }
            return base.BeforeSubmit();
        }
        private void DealDownAtt()
        {
            YwAttach att = new YwAttach();
            att.Dataid = Entity.Did;
            att.Type = "2";
            BaseDao baseDao = new BaseDao();
            IList<YwAttach> list = baseDao.List(att);
            if (list.Count > 0)
            {
                YwAttach temp = list[0];
                string path = temp.Dic + temp.FileN;
                Response.ContentType = "application/x-zip-compressed";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + temp.FileN);
                string filename = path;
                Response.TransmitFile(filename);
            }
            else
            {
                errmsg = "没有附件";
            }
            Task.Submit = false;
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

            }
        }
        #endregion


    }
}

