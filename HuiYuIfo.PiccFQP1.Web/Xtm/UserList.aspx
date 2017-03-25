<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Xtm.UserList" %>

<%@ Register Assembly="HuiYuIfo.Framework.Web" Namespace="HuiYuIfo.Framework.Web" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>用户管理</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
    
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">用户管理</span></td> 
					<td align="right" width="50%"> 
						 <asp:LinkButton ID="LinkButton1" CommandName="export" runat="server" CssClass="combut" Text="导出" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出</asp:LinkButton> 
						|<asp:LinkButton ID="butCreate" CommandName="ucreate" runat="server" CssClass="combut" Text="新增" OnClick="Button_Click"><img src="../Content/Img/add.png" alt="create"/>新增</asp:LinkButton> 
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panQry" runat="server">
			<table class="tableQry">
				<tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>人员代码</td>
					<td align="left"><asp:TextBox ID="UserCode" runat="server" CssClass="input"></asp:TextBox></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>人员名称</td>
					<td align="left"><asp:TextBox ID="UserName" runat="server" CssClass="input"></asp:TextBox></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>隶属机构</td>
					<td align="left"><asp:DropDownList ID="DepartId" CssClass="input" runat="server"></asp:DropDownList></td>
					<td align="right"><asp:Button ID="butQry" runat="server" Text="查询" CommandName="query" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panList" runat="server">
			<asp:GridView ID="list"  CssClass="list" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
				<Columns>
					<asp:BoundField DataField="UserCode" HeaderText="人员代码" />
                    <asp:BoundField DataField="UserName" HeaderText="人员名称" />
                    <asp:BoundField DataField="UserTypeName" HeaderText="隶属机构" />
                    <asp:BoundField DataField="DepartName" HeaderText="用户身份" />
                    <asp:BoundField DataField="StatusName" HeaderText="状态" />
                    <asp:TemplateField HeaderText="业务权限"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butYri" CssClass="linkbut" runat="server" CommandName="uywpri" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="业务权限"><img src="../Content/Img/maintenance.png" alt="uywpri"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
                    <asp:TemplateField HeaderText="菜单权限"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butPri" CssClass="linkbut" runat="server" CommandName="upri" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="菜单权限"><img src="../Content/Img/maintenance.png" alt="pri"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="修改"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butEdit" CssClass="linkbut" runat="server" CommandName="uedit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="修改"><img src="../Content/Img/edit.gif" alt="edit"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="删除"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butDelete" CssClass="linkbut" runat="server" CommandName="udelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="删除" OnClientClick="javascript:return confirm('确定删除？');"><img src="../Content/Img/delete.gif" alt="delete"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
                    <asp:TemplateField HeaderText="重置密码"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butResetPwd" CssClass="linkbut" runat="server" CommandName="resetPwd" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="重置密码" ><img src="../Content/Img/select.gif" alt="delete"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
			</asp:GridView>
			 <cc1:GVNavigater ID="GVNavigater1" runat="server" CssClass="udfNav"></cc1:GVNavigater>
		</asp:Panel>
	</form>
</body>
<script src="../Content/Js/jquery.js?v=100" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $(".list tr").click(function () {
                $(".click").removeClass("click");
                $(this).addClass("click");
            });
            $(".list tr:even").addClass("alt");
        });
    </script>
</html>
