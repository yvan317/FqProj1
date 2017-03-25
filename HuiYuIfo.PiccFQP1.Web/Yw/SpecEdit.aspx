<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.SpecEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑特殊情况</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">编辑特殊情况</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> <a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">特殊类型</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="SpecName" runat="server" CssClass="input"></asp:TextBox>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
                    </td>
					<td style="text-align:left;border-right:none;"></td>
					<td style="text-align:left;border-left:none;"></td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">商业险费率%</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Syxfv" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox>%<span style="color:Red">&nbsp;&nbsp;*</span></td>
                    <td style="text-align:left;border-right:none;">交强险费率%</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Jqxfv" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox>%<span style="color:Red">&nbsp;&nbsp;*</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:right;color:Red">带 * 为必填项</td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>
