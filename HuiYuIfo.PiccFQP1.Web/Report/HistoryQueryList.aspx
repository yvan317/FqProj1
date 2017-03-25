<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoryQueryList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Report.HistoryQueryList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>历史数据导出</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">历史数据导出</span></td> 
					<td align="right" width="50%"> 
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panQry" runat="server">
			<table class="tableQry">
				<tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>统计年份</td>
					<td align="left"><asp:DropDownList ID="Year" CssClass="input" runat="server"></asp:DropDownList></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>统计月份</td>
					<td align="left"><asp:DropDownList ID="Month" CssClass="input" runat="server"></asp:DropDownList></td>
                    <td></td>
                </tr>
                <tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>部门</td>
					<td align="left">
                        <asp:DropDownList ID="Depart" runat="server"  AutoPostBack="True" onselectedindexchanged="Depart_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>业务员</td>
					<td align="left"><asp:DropDownList ID="Ywy" CssClass="input" runat="server"></asp:DropDownList></td>
					<td align="right"><asp:Button ID="butQry" runat="server" Text="导出" CommandName="historyExport" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
    </form>
</body>
</html>
