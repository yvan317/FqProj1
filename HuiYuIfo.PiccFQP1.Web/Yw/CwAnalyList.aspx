<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CwAnalyList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CwAnalyList" %>
<%@ Register Assembly="HuiYuIfo.Framework.Web" Namespace="HuiYuIfo.Framework.Web" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>财务支付管理</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
    
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">财务支付管理</span></td> 
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
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>部门</td>
					<td align="left">
                        <asp:DropDownList ID="Depart" runat="server" CssClass="input"   AutoPostBack="True" onselectedindexchanged="Depart_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>业务员</td>
					<td align="left"><asp:DropDownList ID="YwyCode" CssClass="input" runat="server"></asp:DropDownList></td>
					<td align="right"><asp:Button ID="butQry" runat="server" Text="查询" CommandName="query" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panList" runat="server">
			<asp:GridView ID="list"  CssClass="list" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
				<Columns>
					<asp:BoundField DataField="Year" HeaderText="统计年" />
                    <asp:BoundField DataField="Month" HeaderText="统计月" />
                    <asp:BoundField DataField="YwyName" HeaderText="业务员名称" />
                    <asp:BoundField DataField="Syjy" HeaderText="上月结余" />
                    <asp:BoundField DataField="Cxzdxje" HeaderText="车险总兑现金额" />
                    <asp:BoundField DataField="Cxfdjx" HeaderText="车险浮动绩效" />
                    <asp:BoundField DataField="Sryfgz" HeaderText="应付工资" />
                    <asp:BoundField DataField="Srhj" HeaderText="收入合计" />
                    <asp:BoundField DataField="Sxf" HeaderText="手续费" />
                    <asp:BoundField DataField="Fybx" HeaderText="费用报销" />
                    <asp:BoundField DataField="Zcyfgz" HeaderText="应付工资" />
                    <asp:BoundField DataField="Xcp" HeaderText="宣传品" />
                    <asp:BoundField DataField="Zchj" HeaderText="支出合计" />
                    <asp:BoundField DataField="Byjy" HeaderText="本月结余" />
					<asp:TemplateField HeaderText="修改"  ItemStyle-Width="30px">
						<ItemTemplate>
							<asp:LinkButton ID="butEdit" CssClass="linkbut" runat="server" CommandName="uedit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="修改"><img src="../Content/Img/edit.gif" alt="edit"/></asp:LinkButton>
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
