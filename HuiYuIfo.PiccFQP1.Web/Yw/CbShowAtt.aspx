<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CbShowAtt.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CbShowAtt" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看附件</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/uploadify.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">查看附件</span></td> 
					<td align="right" width="50%"> 
                        <asp:LinkButton ID="LinkButton2" CommandName="downAtt" runat="server" CssClass="combut" Text="下载附件" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="save"/>下载附件</asp:LinkButton>
                        <a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
            
		</asp:Panel>
	</form>
</body>

</html>

