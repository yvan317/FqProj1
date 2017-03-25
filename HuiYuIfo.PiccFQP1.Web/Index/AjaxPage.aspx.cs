using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Dao;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
using System.Collections;

namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public partial class AjaxPage : System.Web.UI.Page
    {
        private string opType = "";
        private string errmsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                opType = Request.QueryString["optype"];
                switch (opType)
                {
                    #region 机构
                    case "departJson":
                        Response.Write(LoadDepartJson());
                        break;
                    case "savedepart":
                        Response.Write(SaveDepart());
                        break;
                    #endregion

                    #region 菜单
                    case "menuJson":
                        Response.Write(LoadMenuJson());
                        break;
                    case "saveMenu":
                        Response.Write(SaveMenu());
                        break;
                    #endregion
                }
            }
        }

        #region 处理机构权限
        private string SaveDepart()
        {
            BaseDao baseDao = new BaseDao();
            string para = Request.Form[0];
            string[] paras = para.Split('|');
            XtmUserPri priM = new XtmUserPri();
            priM.UserId = int.Parse(paras[0]);
            priM.PriType = "depart";
            baseDao.Delete(priM);
            for (int i = 1; i < paras.Length - 1; i++)
            {
                string[] temp = paras[i].Split('-');
                priM.PriId = int.Parse(temp[0]);
                priM.PriVal = temp[1];
                baseDao.Insert(priM);
            }
            return "y";
        }

        private string LoadDepartJson()
        {
            BaseDao baseDao = new BaseDao();
            XtmDepart modelT = new XtmDepart();
            modelT.UserId = int.Parse(Request.QueryString["id"]);
            IList<XtmDepart> list = baseDao.ListUdf("XtmDepartLoad", modelT);
            ArrayList jsonList = new System.Collections.ArrayList();
            string result = "[";
            for (int i = 0; i < list.Count; i++)
            {
                XtmDepart menuT = list[i];
                NodeData mt = new NodeData();
                mt.id = menuT.Did.ToString();
                mt.code = menuT.DepartCode;
                mt.pid = menuT.ParentId.ToString();
                mt.name = menuT.DepartName;
                mt.open = true;
                if (menuT.Pri == "y")
                {
                    mt.@checked = true;
                }
                else
                {
                    mt.@checked = false;
                }
                if (i == list.Count - 1)
                {
                    result += JsonHelper.JsonSerializer<NodeData>(mt);
                }
                else
                {
                    result += JsonHelper.JsonSerializer<NodeData>(mt) + ",";
                }
            }
            result += "]";
            return result;
        }
        #endregion


        #region 处理菜单权限
        private string SaveMenu()
        {
            string para = Request.Form[0];
            string[] paras = para.Split('|');
            XtmMenuPri priM = new XtmMenuPri();
            priM.UserId = int.Parse(paras[0]);
            BaseDao baseDao = new BaseDao();
            baseDao.Delete(priM);
            for (int i = 1; i < paras.Length - 1; i++)
            {
                string[] temp = paras[i].Split('-');
                priM.MenuId = int.Parse(temp[0]);
                priM.MenuCode = temp[1];
                baseDao.Insert(priM);
            }
            return "y";
        }

        private string LoadMenuJson()
        {
            BaseDao baseDao = new BaseDao();
            XtmMenu menuM = new XtmMenu();
            menuM.UserId = int.Parse(Request.QueryString["id"]);
            IList<XtmMenu> list = baseDao.List(menuM);
            
            ArrayList jsonList = new System.Collections.ArrayList();
            string result = "[";
            for (int i = 0; i < list.Count; i++)
            {
                XtmMenu menuT = list[i];
                NodeData mt = new NodeData();
                mt.id = menuT.Did.ToString();
                mt.code = menuT.MenuCode;
                mt.pid = menuT.ParentId.ToString();
                mt.name = menuT.MenuName ;
                mt.open = true;
                if (menuT.Pri == "y")
                {
                    mt.@checked = true;
                }
                else
                {
                    mt.@checked = false;
                }
                if (i == list.Count - 1)
                {
                    result += JsonHelper.JsonSerializer<NodeData>(mt);
                }
                else
                {
                    result += JsonHelper.JsonSerializer<NodeData>(mt) + ",";
                }
            }
            result += "]";
            return result;
        }
        #endregion
    }
}