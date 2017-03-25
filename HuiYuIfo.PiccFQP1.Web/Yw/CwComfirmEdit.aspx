<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CwComfirmEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Yw.CwComfirmEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑费用数据</title>
    <link href="../Content/Css/edit.css?v=100" rel="stylesheet" type="text/css" />
    <link href="../Content/Css/uploadify.css" rel="stylesheet" type="text/css" />
</head>
<body>
	<form id="form1" runat="server">
		<asp:Panel ID="panCom" CssClass="panCom" runat="server">
			<table width="99%">
				<tr>
					<td align="left" width="50%"><span class="navTitle">编辑费用数据</span></td> 
					<td align="right" width="50%"> 
                        
                        <asp:LinkButton ID="LinkButton2" CommandName="downAtt" runat="server" CssClass="combut" Text="下载附件" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="save"/>下载附件</asp:LinkButton>
                        |<asp:LinkButton ID="showAtt" CommandName="showAtt" runat="server" CssClass="combut" Text="查看附件" OnClick="Button_Click"><img src="../Content/Img/export.png" alt="save"/>查看附件</asp:LinkButton>
                         |<asp:LinkButton ID="LinkButton3" CommandName="cwUnComfirm" runat="server" CssClass="combut" Text="审核不通过" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>审核不通过</asp:LinkButton>
                        |<asp:LinkButton ID="LinkButton1" CommandName="cwSave" runat="server" CssClass="combut" Text="保存修改" OnClick="Button_Click"><img src="../Content/Img/save.png" alt="save"/>保存修改</asp:LinkButton>
                        |<a onclick="javascript:window.close();"  class="combut"><img src="../Content/Img/close.png" alt="close"/>关闭</a>
					</td> 
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="panCon" CssClass="panCon" runat="server">
            <asp:HiddenField ID="Did" runat="server" />
            <table class="tableCon"  cellspacing="0">
            <tr><td colspan="8" style="color:Red;font-size:14px;font-weight:bold">承保填写[财务可修改]</td></tr>
				<tr>
                    <td style="text-align:left;border-right:none;">部门</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="DepartName" runat="server"  ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">业务员</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="YwyName" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">上年出险总次数 <span style="color:Red">*</span></td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Cxcs" runat="server" CssClass="input"  style="background-color:#FFFFAA" />
					</td>

                    <td style="text-align:left;border-right:none;">&nbsp;</td>
					<td style="text-align:left;border-left:none;color:Red">
                       带 * 为必填项
                    </td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">是否平安<span style="color:Red">*</span></td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfpa" runat="server" CssClass="input"  style="background-color:#FFFFAA">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">是否优质<span style="color:Red">*</span></td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfyz" runat="server" CssClass="input"  style="background-color:#FFFFAA">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">出险2次，是否赔付100%<span style="color:Red">*</span></td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Cx2c" runat="server" CssClass="input" style="background-color:#FFFFAA">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">是否采购办</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfcgb" runat="server" CssClass="input"  style="background-color:#FFFFAA">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>
                </tr>

                <tr>
                  

                    <td style="text-align:left;border-right:none;">特殊类型</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Tslx" runat="server" CssClass="input" style="background-color:#FFFFAA"/>
					</td>

                    <td style="text-align:left;border-right:none;">出险3次，是否赔付200%</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Cx3c" runat="server" CssClass="input" style="background-color:#FFFFAA">
                           
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">上年承保公司</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sncbgs" runat="server" CssClass="input"   style="background-color:#FFFFAA"/>
					</td>
                    <td style="text-align:left;border-right:none;">是否无法关联出险次数</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Wfglcx" runat="server" CssClass="input" style="background-color:#FFFFAA">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>
                </tr>
                <tr>
                    
					<td style="text-align: left; border-right: none;">备注</td>
					<td style="text-align: left; border-left: none;" colspan="7">
						<asp:TextBox ID="Bz" runat="server" CssClass="input" Width="500px" style="background-color:#FFFFAA"/>
					</td>
				</tr>
                <tr><td colspan="8" style="color:Red;font-size:14px;font-weight:bold">承保、财务意见</td></tr>
                <tr>
                    <td style="text-align:left;border-right:none;">承保意见</td>
					<td style="text-align:left;border-left:none;" colspan="3">
                        <asp:TextBox runat="server" ID="CbOpinion" Width="300px" Height="93px" 
                            TextMode="MultiLine"   ReadOnly="true"/>
                    </td>
                    <td style="text-align:left;border-right:none;">财务意见</td>
					<td style="text-align:left;border-left:none;" colspan="3">
                        <asp:TextBox runat="server" ID="CwOpinion" Width="300px" Height="93px" 
                            TextMode="MultiLine"  style="background-color:#FFFFAA"/>
                    </td>
                </tr>



                <tr><td colspan="8" style="color:Red;font-size:14px;font-weight:bold">业务员数据</td></tr>
                <tr>
                    <td style="text-align:left;border-right:none;" >是否有凭证</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfypz" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>
                      <td style="text-align:left;border-right:none;">报批</td>
					<td style="text-align:left;border-left:none;">
                       <asp:TextBox ID="Bp" runat="server" CssClass="input" ReadOnly="true" />
					</td>
                    <td style="text-align:left;border-right:none;">实际支付市场费用（凭证金额）</td>
					<td style="text-align:left;border-left:none;" colspan="6">
                        <asp:TextBox ID="Sjscfy" runat="server" CssClass="input" ReadOnly="true" />
					</td>
         
					
                </tr>
               
            
                <tr><td colspan="8" style="color:Red;font-size:14px;font-weight:bold">系统计算数据</td></tr>
                <tr>
                    <td style="text-align:left;border-right:none;">是否工行刷卡</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Ghsk" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">手续费差异化%</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sxfcyh" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">手续费金额</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sxfje" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>
                    <td style="text-align:left;border-right:none;">实际支付报批费用</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sjzfbpfy" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>
                   
                </tr>

                

                <tr>
                    <td style="text-align:left;border-right:none;">总计 </td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Zj" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">兑现金额</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Dxje" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">交通通讯费宣传品</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Jttxf" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">车险月度固定奖励%</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Cxydjl" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">工行刷卡奖励 </td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Ghskjl" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">总兑现金额</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Zdxje" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">计算类型</td>
                        
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="CalculateName" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">附件数量</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="AttachmentCount" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">税收 </td>
					<td style="text-align:left;border-left:none;" colspan="7">
                        <asp:TextBox ID="Sh" runat="server" CssClass="input"   ReadOnly="true"/>
					</td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">手续费类型</td>
					<td style="text-align:left;border-left:none;" colspan="3">
                        <asp:TextBox ID="Sxflx" runat="server"  CssClass="input" width="500px" ReadOnly="true"/>
					</td>
                    <td style="text-align:left;border-right:none;">计算规则</td>
					<td style="text-align:left;border-left:none;" colspan="3">
                        <asp:TextBox ID="qzbz" runat="server"  CssClass="input" width="500px" ReadOnly="true"/>
					</td>
                </tr>

                <tr><td colspan="8" style="color:Red;font-size:14px;font-weight:bold">系统数据</td></tr>
                <tr>
                    <td style="text-align:left;border-right:none;">经办人</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Jbr" runat="server" CssClass="input" ReadOnly="true" />
					</td>

                    <td style="text-align:left;border-right:none;">归属人</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Gsr" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                   <td style="text-align:left;border-right:none;">车型</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Cx" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">渠道码</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Qdm" runat="server" CssClass="input" ReadOnly="true"/>
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">车辆类型</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Clxs" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">被保险人</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Bbr" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">单证号</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Dzh" runat="server" CssClass="input" ReadOnly="true" Width="180px"/>
					</td>

                    <td style="text-align:left;border-right:none;">车牌号</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Cph" runat="server" CssClass="input" ReadOnly="true" />
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">单位性质</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Dwxz" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">座位数</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Zwh" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">吨位数</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Dws" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">是否新保、过户</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfxb" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">是否保盗抢</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbbd" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">是否保车上人员</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbcsry" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                   <td style="text-align:left;border-right:none;">是否保自燃</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbzr" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">是否保车损</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbcs" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">是否保发动机险</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Sfbfdj" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">单保三者</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Dbdsz" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                   <td style="text-align:left;border-right:none;">单保交强</td>
					<td style="text-align:left;border-left:none;">
                        <asp:DropDownList ID="Dbjq" runat="server" CssClass="input" Enabled="false">
                            <asp:ListItem Value="否" Text="否"></asp:ListItem>
                            <asp:ListItem Value="是" Text="是"></asp:ListItem>
                        </asp:DropDownList>
					</td>

                    <td style="text-align:left;border-right:none;">推修码</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sflwxm" runat="server" ReadOnly="true" CssClass="input" />
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">使用年限</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Synx" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">银行卡号</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Yhkh" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">业务来源</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Ywly" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">客户群</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Khq" runat="server" CssClass="input" ReadOnly="true" />
					</td>
                </tr>

                <tr>
                    <td style="text-align:left;border-right:none;">签单日期</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Qdrq" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">起保日期</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Qbrq" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">终保日期</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Zbrq" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                     <td style="text-align:left;border-right:none;">条款</td>
					<td style="text-align:left;border-left:none;">
                         <asp:TextBox ID="Tk" runat="server" CssClass="input" ReadOnly="true" />
					</td>
                </tr>
                <tr>
                    <td style="text-align:left;border-right:none;">商业保费</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Sybf" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">交强保费</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Jqbf" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">车船税</td>
					<td style="text-align:left;border-left:none;">
                        <asp:TextBox ID="Cqs" runat="server" CssClass="input" ReadOnly="true"/>
					</td>

                    <td style="text-align:left;border-right:none;">总保费/变动保费</td>
					<td style="text-align:left;border-left:none;">
                         <asp:TextBox ID="Zbf" runat="server" CssClass="input" ReadOnly="true"/>
					</td>
                </tr>
               
			</table>
		</asp:Panel>
	</form>
</body>

</html>

