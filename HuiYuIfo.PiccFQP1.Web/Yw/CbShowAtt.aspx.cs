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
    public partial class CbShowAtt : BaseEditWebFX<YwData, YwCbDataController>
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
                YwAttach att = new YwAttach();
                att.Dataid = Entity.Did;
                att.Type = "1";
                BaseDao baseDao = new BaseDao();
                IList<YwAttach> list = baseDao.List(att);
                if (list.Count > 0)
                {
                    string pic = System.Configuration.ConfigurationManager.AppSettings["Pic"].Trim();
                    string[] picArr = pic.Split('|');
                    int index = 0;
                    foreach (YwAttach temp in list)
                    {
                        index++;
                        string title = "<hr/><h4>附件" + index + ":" + temp.RealName + "</h4>";
                        
                        string[] arr = temp.FileN.Split('.');
                        string tailT = arr[arr.Length - 1].Trim().ToUpper();
                        string[] pathArr = temp.Dic.Split('\\');
                        string relPath = "";
                        bool enter = false;
                        for (int i = 0; i < pathArr.Length; i++)
                        {
                            if (pathArr[i] == "")
                            {
                                continue;
                            }
                            if (pathArr[i] == "upload" || enter == true)
                            {
                                relPath += pathArr[i] + "\\";
                                enter = true;
                            }
                        }
                        bool isPic = false;
                        foreach (string picT in picArr)
                        {
                            if (tailT == picT)
                            {
                                Image img = new Image();
                                img.ImageUrl = relPath + temp.FileN;
                                title += "<a href='" + relPath + temp.FileN + "'>下载</a><hr/>";
                                this.panCon.Controls.Add(new LiteralControl(title));
                                this.panCon.Controls.Add(img);
                                isPic = true;
                                break;
                            }
                        }
                        if (isPic == true)
                        {
                            continue;
                        }
                        HyperLink link = new HyperLink();
                        link.NavigateUrl = relPath + temp.FileN;

                        link.Text = temp.RealName;
                        title += "<a href='" + relPath + temp.FileN + "'>下载</a><hr/>";
                        this.panCon.Controls.Add(new LiteralControl(title));
                        this.panCon.Controls.Add(link);
                    }
                }
                else
                {
                    Label lab = new Label();
                    lab.Text = "没有附件";
                    this.panCon.Controls.Add(lab);
                }
            }
        }
        #endregion


    }
}

