<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.SpecList" %>
<%@ Register Assembly="HuiYuIfo.Framework.Web" Namespace="HuiYuIfo.Framework.Web" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>特殊情况管理</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
    
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">特殊情况管理</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butCreate" CommandName="ucreate" runat="server" CssClass="combut" Text="新增" OnClick="Button_Click"><img src="../Content/Img/add.png" alt="create"/>新增</asp:LinkButton> 
                        |<asp:LinkButton ID="butExportExample" CommandName="exportExample" runat="server" CssClass="combut" Text="导出范本" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="exportExample"/>导出范本</asp:LinkButton>
                        |<asp:LinkButton ID="butExport" CommandName="export" runat="server" CssClass="combut" Text="导出" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出</asp:LinkButton>
                        |<asp:LinkButton ID="butImport" CommandName="import" runat="server" CssClass="combut" Text="导入" OnClick="Button_Click"><img src="../Content/Img/import.png" alt="create"/>导入</asp:LinkButton>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panQry" runat="server">
			<table class="tableQry">
				<tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>特殊类型</td>
					<td align="left"><asp:TextBox ID="SpecName" runat="server" CssClass="input"></asp:TextBox></td>
                    
					<td align="right"><asp:Button ID="butQry" runat="server" Text="查询" CommandName="query" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panList" runat="server">
			<asp:GridView ID="list"  CssClass="list" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
				<Columns>
					<asp:BoundField DataField="SpecName" HeaderText="特殊类型" />
                    <asp:BoundField DataField="Syxfv" HeaderText="商业险费率%" />
                    <asp:BoundField DataField="Jqxfv" HeaderText="交强险费率%" />
                
              
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
