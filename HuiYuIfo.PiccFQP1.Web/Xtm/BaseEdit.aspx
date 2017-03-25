<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BaseEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Xtm.BaseEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>基数数据</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">基数数据</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> 
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">保车上人员基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Bcsry" runat="server" CssClass="input" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">保盗抢险基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Bdqx" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">保自燃险基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Bzrx" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">保发动机基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Bfdj" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">三者100万基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Sz100" runat="server" CssClass="input" Width="300px"></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">推修基数</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Tx" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">优质平安</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Yzpa" runat="server" CssClass="input" Width="300px" ></asp:TextBox></td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>
