<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChargeList.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.ChargeList" %>
<%@ Register Assembly="HuiYuIfo.Framework.Web" Namespace="HuiYuIfo.Framework.Web" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>差异化数据管理</title>
    <link href="../Content/Css/list.css?v=100" rel="stylesheet" type="text/css" />
    
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">差异化数据管理</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butCreate" CommandName="ucreate" runat="server" CssClass="combut" Text="新增" OnClick="Button_Click"><img src="../Content/Img/add.png" alt="create"/>新增</asp:LinkButton> 
                        |<asp:LinkButton ID="butExportExample" CommandName="exportExample" runat="server" CssClass="combut" Text="导出范本" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="exportExample"/>导出范本</asp:LinkButton>
                        |<asp:LinkButton ID="butExport" CommandName="export" runat="server" CssClass="combut" Text="导出" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="create"/>导出</asp:LinkButton>
                        |<asp:LinkButton ID="butImport" CommandName="import" runat="server" CssClass="combut" Text="导入" OnClick="Button_Click"><img src="../Content/Img/import.png" alt="create"/>导入</asp:LinkButton>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panQry" runat="server">
			<table class="tableQry">
				<tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>手续费类型</td>
					<td align="left">
                        <asp:DropDownList ID="Sxflx" runat="server"> </asp:DropDownList>
                    </td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>险种</td>
					<td align="left"><asp:DropDownList ID="Xz" runat="server"> </asp:DropDownList></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>单保第三者</td>
					<td align="left"><asp:DropDownList ID="Dbdsz" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>单保交强</td>
					<td align="left"><asp:DropDownList ID="Dbjq" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>
                </tr>
                <tr>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>无法关联出险次数</td>
					<td align="left"><asp:DropDownList ID="Wfglcxcs" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>
                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>业务来源</td>
					<td align="left"><asp:DropDownList ID="Ywly" runat="server">
                       
                    </asp:DropDownList></td>

                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>出险次数</td>
					<td align="left"><asp:DropDownList ID="Zhcxcs" runat="server">
                      
                    </asp:DropDownList></td>

                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>使用年限</td>
					<td align="left"><asp:DropDownList ID="Synx" runat="server">
                      
                    </asp:DropDownList></td>
                </tr>
                <tr>


                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>是否保车损</td>
					<td align="left"><asp:DropDownList ID="Sfbcs" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>

                    <td align="left"><img src="../Content/Img/grip.gif" alt="grip"/>赔付率是否超100%</td>
					<td align="left"><asp:DropDownList ID="Pfvsfc100" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>
                    <td>出险3次，是否赔付200%</td>
                    <td align="left"><asp:DropDownList ID="Cx3c" runat="server">
                        <asp:ListItem Value="" Text="--请选择--"></asp:ListItem>
                        <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        <asp:ListItem Value="否" Text="否"></asp:ListItem>
                    </asp:DropDownList></td>
					<td align="right"><asp:Button ID="butQry" runat="server" Text="查询" CommandName="query" CssClass="but" OnClick="Button_Click"/></td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panList" runat="server">
			<asp:GridView ID="list"  CssClass="list" runat="server" AutoGenerateColumns="false" OnRowCommand="GridView_RowCommand">
				<Columns>
                    <asp:BoundField DataField="Xz" HeaderText="险种" />
                    <asp:BoundField DataField="Dbdsz" HeaderText="单保第三者" />
                    <asp:BoundField DataField="Dbjq" HeaderText="单保交强" />
                    <asp:BoundField DataField="Sxflx" HeaderText="手续费类型" />
                    <asp:BoundField DataField="Ywly" HeaderText="业务来源" />
                    <asp:BoundField DataField="Wfglcxcs" HeaderText="是否无法关联出险次数" />
                    <asp:BoundField DataField="Zhcxcs" HeaderText="综合出险次数" />
                    <asp:BoundField DataField="Synx" HeaderText="使用年限" />
                    <asp:BoundField DataField="Sfbcs" HeaderText="是否保车损" />
                    <asp:BoundField DataField="Pfvsfc100" HeaderText="赔付率超100%" />
                    <asp:BoundField DataField="Cx3c" HeaderText="出险3次，是否赔付200%" />
                    <asp:BoundField DataField="Jcsxf" HeaderText="基础手续费" />
                    <asp:BoundField DataField="Bcsry" HeaderText="保车上人员" />
                    <asp:BoundField DataField="Bdqx" HeaderText="保盗抢险" />
                    <asp:BoundField DataField="Bzrx" HeaderText="保自燃险" />
                    <asp:BoundField DataField="Bfdj" HeaderText="保发动机" />
                  
                    <asp:BoundField DataField="Sz100" HeaderText="三者100万" />
					<asp:TemplateField HeaderText="修改"  ItemStyle-Width="30px">
						<ItemTemplate>
							<asp:LinkButton ID="butEdit" CssClass="linkbut" runat="server" CommandName="uedit" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="修改"><img src="../Content/Img/edit.gif" alt="edit"/></asp:LinkButton>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="删除"  ItemStyle-Width="30px">
						<ItemTemplate>
							<asp:LinkButton ID="butDelete" CssClass="linkbut" runat="server" CommandName="udelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.SysKey") %>' Text="删除" OnClientClick="javascript:return confirm('确定删除？');"><img src="../Content/Img/delete.gif" alt="delete"/></asp:LinkButton>
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
