<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Xtm.ConfigEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>系统配置数据</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">系统配置数据</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> 
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">结账日[1到28号]之间</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Config1" runat="server" CssClass="input" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">工行卡号前缀</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Config2" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">当前结帐到</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Config3" runat="server" CssClass="input" Width="300px" ReadOnly="true"></asp:TextBox></td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>
