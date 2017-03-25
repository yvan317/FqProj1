<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChargeEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.ChargeEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑差异化数据</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">编辑差异化数据</span></td> 
					<td align="right" width="50%"> 
						<asp:LinkButton ID="butSave" CommandName="save" runat="server" 

CssClass="combut" Text="保存" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存</asp:LinkButton> 

<a onclick="javascript:window.close();"  class="combut" style="cursor:pointer"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
			<table class="tableCon"  cellspacing="0">
				<tr>
					<td style="text-align:left;border-right:none;">险种</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Xz" runat="server" CssClass="input"> </asp:DropDownList>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
					<td style="text-align:left;border-right:none;">是否单保第三者</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Dbdsz" runat="server" CssClass="input">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                    <td style="text-align:left;border-right:none;">是否单保交强</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Dbjq" runat="server" CssClass="input">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
						<span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
				</tr>
                <tr>
					
                    <td style="text-align:left;border-right:none;">手续费类型</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sxflx" runat="server" CssClass="input"></asp:DropDownList>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
					<td style="text-align:left;border-right:none;">业务来源</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Ywly" runat="server" CssClass="input"></asp:DropDownList>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                    <td style="text-align:left;border-right:none;">是否无法关联出险次数</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Wfglcxcs" runat="server" CssClass="input" >
                            <asp:ListItem value="否" Text="否"></asp:ListItem>
                            <asp:ListItem value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
						<span style="color:Red">&nbsp;&nbsp;*</span>
					</td>

				</tr>
                <tr>
					
					<td style="text-align:left;border-right:none;">综合出险次数</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Zhcxcs" runat="server" CssClass="input" />
						<span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                
					<td style="text-align:left;border-right:none;">使用年限</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Synx" runat="server" CssClass="input" />
						<span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                    <td style="text-align:left;border-right:none;">是否保车损</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbcs" runat="server" CssClass="input">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
                        <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
				</tr>
                <tr>
					
					<td style="text-align:left;border-right:none;">赔付率是否超100%</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Pfvsfc100" runat="server" CssClass="input">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>

                    <td style="text-align:left;border-right:none;">出险3次，是否赔付200%</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Cx3c" runat="server" CssClass="input">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>


					<td style="text-align:left;border-right:none;">基础手续费</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Jcsxf" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">保车上人员</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Bcsry" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>

                    <td style="text-align:left;border-right:none;">保盗抢险</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Bdqx" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>

                    <td style="text-align:left;border-right:none;">保自燃险</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Bzrx" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">保发动机</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Bfdj" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                    <td style="text-align:left;border-right:none;">三者100万</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sz100" runat="server" CssClass="input"  style="background-color:#FFFFAA"/>
					    <span style="color:Red">&nbsp;&nbsp;*</span>
					</td>
                    <td style="text-align:left;border-right:none;">&nbsp;</td><td style="text-align:left;border-left:none;">&nbsp;</td>
                </tr>
			</table>
		</asp:Panel>
	</form>
</body>
</html>

