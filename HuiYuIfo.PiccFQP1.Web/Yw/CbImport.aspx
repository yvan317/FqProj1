<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CbImport.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CbImport" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>导入手续费数据</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server" enctype="multipart/form-data">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">导入手续费数据</span></td> 
					<td align="right" width="50%"> 
						 <a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-left:none;">
                        <asp:FileUpload ID="cyhFile" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="butImport" CommandName="cbImportSave" runat="server" CssClass="combut" Text="上传" OnClick="Button_Click">上传</asp:LinkButton></td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>

