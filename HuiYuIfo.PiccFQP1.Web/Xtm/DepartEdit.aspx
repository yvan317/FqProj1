﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Xtm.DepartEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑机构</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">编辑机构</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> <a onclick="javascript:window.close();"  class="combut" style="cursor:pointer"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">机构编码</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="DepartCode" runat="server" CssClass="input"></asp:TextBox><span style="color:Red">&nbsp;&nbsp;*</span></td>
					<td style="text-align:left;border-right:none;">机构名称</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="DepartName" runat="server" CssClass="input" Width="200px" style="background-color:#FFFFAA"></asp:TextBox><span style="color:Red">&nbsp;&nbsp;*</span></td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">隶属机构</td>
					<td style="text-align:left;border-left:none;"><asp:DropDownList ID="ParentId"  runat="server" style="background-color:#FFFFAA"></asp:DropDownList></td>
                    <td style="text-align:left;border-right:none;color:red" colspan="2"> 带 * 为必填项</td>
				
                </tr>

			</table>
		</asp:Panel>
	</form>
</body>
</html>
