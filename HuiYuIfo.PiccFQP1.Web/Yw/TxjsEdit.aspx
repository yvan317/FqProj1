<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TxjsEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.TxjsEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑推修系数</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">编辑推修系数</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> <a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">推修码</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Txm" runat="server" CssClass="input"></asp:TextBox>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
                    </td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">修理厂</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Xlc" runat="server" CssClass="input"></asp:TextBox>
                    </td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">专员</td>
					<td style="text-align:left;border-left:none;">
                    <asp:DropDownList ID="Zy" runat="server" CssClass="input">
                        <asp:ListItem Value="N">无</asp:ListItem>
                        <asp:ListItem Value="Y">有</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">推修系数值</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Xs" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox>%<span style="color:Red">&nbsp;&nbsp;*</span>
                    </td>
                </tr>
              
			</table>
		</asp:Panel>
	</form>
</body>
</html>
