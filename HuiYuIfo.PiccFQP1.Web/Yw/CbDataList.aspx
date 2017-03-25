<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CbDataList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CbDataList" %>
<%@ Register Assembly="HuiYuIfo.Framework.Web" Namespace="HuiYuIfo.Framework.Web" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>承保手续费管理</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="20%"><span class="navTitle">承保手续费管理</span></td> 
					<td align="right" width="80%"> 
                        <asp:LinkButton ID="butCreate" CommandName="cbCreate" runat="server" CssClass="combut" Text="新增" OnClick="Button_Click"><img src="../Content/Img/add.png" alt="create"/>新增</asp:LinkButton> 
                        |<asp:LinkButton ID="butExportPriNoEnd" CommandName="cbExportPriNoEnd" runat="server" CssClass="combut" Text="导出上期未处理数据" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出上期未处理数据</asp:LinkButton>
                        |<asp:LinkButton ID="butExportPriAll" CommandName="cbExportPriAll" runat="server" CssClass="combut" Text="导出上期所有数据" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出上期所有数据</asp:LinkButton>
						|<asp:LinkButton ID="butExportNowNoEnd" CommandName="cbExportNowNoend" runat="server" CssClass="combut" Text="导出本期未处理数据" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出本期未处理数据</asp:LinkButton>
                        |<asp:LinkButton ID="butExportNowAll" CommandName="cbExportNowAll" runat="server" CssClass="combut" Text="导出本期所有数据" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出本期所有数据</asp:LinkButton>
                        |<asp:LinkButton ID="butImport" CommandName="cbImport" runat="server" CssClass="combut" Text="导入" OnClick="Button_Click"><img src="../Content/Img/import.png" alt="create"/>导入</asp:LinkButton>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panQry" runat="server">
			<table class="tableQry">
				<tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>单证号</td>
					<td align="left"><asp:TextBox ID="Dzh" runat="server" CssClass="input"></asp:TextBox></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>被保险人</td>
					<td align="left"><asp:TextBox ID="Bbr" runat="server" CssClass="input"></asp:TextBox></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>车牌号</td>
					<td align="left"><asp:TextBox ID="Cph" runat="server" CssClass="input"></asp:TextBox></td>
					<td align="right"><asp:Button ID="butQry" runat="server" Text="查询" CommandName="query" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panList" runat="server">
			<asp:GridView ID="list"  CssClass="list" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
				<Columns>
					<asp:BoundField DataField="Bbr" HeaderText="被保险人" />
                    <asp:BoundField DataField="Dzh" HeaderText="单证号" />
                    <asp:BoundField DataField="Cph" HeaderText="车牌号" />
					<asp:TemplateField HeaderText="维护"  ItemStyle-Width="60px">
						<ItemTemplate>
							<asp:LinkButton ID="butEdit" CssClass="linkbut" runat="server" CommandName="cbEdit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="修改"><img src="../Content/Img/edit.gif" alt="edit"/></asp:LinkButton>
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
