using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuiYuIfo.Framework.Core;
using System.Collections;
using HuiYuIfo.Framework.UiProcess;
using HuiYuIfo.PiccFQP1.Entity.Xtm;
namespace HuiYuIfo.PiccFQP1.Web.Index
{
    public partial class Menu : System.Web.UI.Page
    {
        private string errmsg = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CoreCache.GetCache("SysUserCode") == null)
            {
                TimeOut.ExecTimeOut(this);
                return;
            }
            if (!IsPostBack)
            {
                InitTree();
            }
        }
        private void InitTree()
        {
            string usertype = CoreCache.GetCache("SysUserType").ToString();
            switch (usertype)
            {
                case "man":
                    InitSMTree();
                    break;
                default:
                    InitPTTree();
                    break;
            }
        }
        private void InitSMTree()
        {
            XtmMenu menu = new XtmMenu();
            XtmMenu oldMenu = null;
            TreeNode oldNode = null;
            IList<XtmMenu> list = WebUiProcess.List(menu);

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XtmMenu temp = list[i];
                    TreeNode item = new TreeNode();
                    if (oldMenu != null && oldMenu.MenuLayer < temp.MenuLayer)
                    {
                        i = InitTreeT(oldNode, list, i);
                    }
                    else
                    {
                        item.Text = temp.MenuName;
                        item.Value = temp.SysKey;
                        tvMenuList.Nodes.Add(item);
                        oldMenu = temp;
                        oldNode = item;
                    }
                }
            }
        }
        private void InitPTTree()
        {
            XtmMenu menu = new XtmMenu();
            XtmMenu oldMenu = null;
            TreeNode oldNode = null;
            menu.Type = "1";
            IList<XtmMenu> list = WebUiProcess.ListUdf("XtmMenuLoad",menu);

            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XtmMenu temp = list[i];
                    if (temp.Pri != "y")
                    {
                        continue;
                    }
                    TreeNode item = new TreeNode();
                    if (oldMenu != null && oldMenu.MenuLayer < temp.MenuLayer)
                    {
                        i = InitTreeT(oldNode, list, i);
                    }
                    else
                    {
                        item.Text = temp.MenuName;
                        item.Value = temp.SysKey;
                        tvMenuList.Nodes.Add(item);
                        oldMenu = temp;
                        oldNode = item;
                    }
                }
            }
        }
        /// <summary>
        /// 处理子节点绑定
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <returns>返回当前处理到的节点序号</returns>
        private int InitTreeT(TreeNode parentNode, IList<XtmMenu> list, int index)
        {
            XtmMenu oldMenu = null;
            TreeNode oldNode = null;
            for (; index < list.Count; index++)
            {
                XtmMenu temp = list[index];
                TreeNode item = new TreeNode();
                if (oldMenu != null && oldMenu.MenuLayer < temp.MenuLayer)
                {
                    index = InitTreeT(oldNode, list, index);
                }
                else
                {
                    if (oldMenu != null && oldMenu.MenuLayer > temp.MenuLayer)
                    {
                        return index - 1;
                    }
                    item.Text = temp.MenuName;
                    item.Value = temp.SysKey;
                    parentNode.ChildNodes.Add(item);
                    oldMenu = temp;
                    oldNode = item;
                }
            }
            return index - 1;
        }
        protected void tvMenuList_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode tv = ((TreeView)sender).SelectedNode;
            if (tv.ChildNodes.Count > 0)
            {
                if (tv.Expanded == true)
                {
                    tv.Collapse();
                }
                else
                {
                    tv.Expand();
                }
                return;
            }
            else
            {
                string selectValue = ((TreeView)sender).SelectedNode.Value;
                
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>parent.content.location.href='Transfer.aspx?Action=" + selectValue + "';</script>");
            }
        }
    }
}