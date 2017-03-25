<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CwAnalyEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CwAnalyEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>财务支付</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">财务支付</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> <a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
                <tr>
                    <td colspan="4" style="color:Red;font-size:14px;">收入数据</td>
                </tr>
				<tr>
					<td style="text-align:left;border-right:none;">车险浮动绩效</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Cxfdjx" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
					<td style="text-align:left;border-right:none;">应付工资</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Sryfgz" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" style="color:Red;font-size:14px;">支出数据</td>
                </tr>
				<tr>
					<td style="text-align:left;border-right:none;">手续费</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Sxf" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
					<td style="text-align:left;border-right:none;">费用报销</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Fybx" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
                </tr>
                <tr>
					<td style="text-align:left;border-right:none;">应付工资</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Zcyfgz" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
					<td style="text-align:left;border-right:none;">宣传品</td>
					<td style="text-align:left;border-left:none;"><asp:TextBox ID="Xcp" runat="server" CssClass="input" style="background-color:#FFFFAA"></asp:TextBox></td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>
