<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Index.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    
    <style type="text/css">
        html,body{font-size:12px;font-family:"Microsoft Yahei", Tahoma, "SimSun" ;padding:0px;margin:0px;width:100%;height:100%;}
        .title{background-color:#5993b1;border:1px solid Black;padding:0px;margin:0px;height:30px;color:White;}
        a:link {  text-decoration:none;color:White} 
        a:hover { text-decoration: none;cursor:pointer;color:White} 
        a:active { text-decoration: none;color:White} 
        a:visited {text-decoration: none;color:White} 
    </style>
    <script language="javascript" type="text/javascript">
        function closefun() {
            window.top.close();
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" class="title" >
    <div>
    <table width="100%">
        <tr>
            <td align="left" valign="middle" style="font-size:13px;padding:0px;margin:0px; font-weight:bold">
                &nbsp;PICC福清车险手续费核算
            </td>
            
            <td  align="right" valign="middle">
            <table>
                <tr>
                    <td  align="right" valign="middle">
                        &nbsp;&nbsp;|&nbsp;&nbsp;
                    </td>
                    <td valign="middle" align="left">
                        当前用户：<asp:Label ID="labUserName" runat="server"></asp:Label>
                    </td>
                    <td  align="right" valign="middle">
                        &nbsp;&nbsp;|&nbsp;&nbsp;
                    </td> 
                    <td valign="middle" align="left">
                        用户身份：<asp:Label ID="labUserType" runat="server"></asp:Label>
                    </td>
                    <td  align="right" valign="middle">
                        &nbsp;&nbsp;|&nbsp;&nbsp;
                    </td> 
                    <td align="right">
                        <asp:LinkButton ID="butModifyPwd" runat="server" Text="修改密码" onclick="butModifyPwd_Click" />
                    </td>
                    <td  align="right" valign="middle">
                        &nbsp;&nbsp;|&nbsp;&nbsp;
                    </td> 
                    <td align="right">
                        <asp:LinkButton ID="logout" runat="server" Text="注销" onclick="logout_Click"></asp:LinkButton> 
                    </td>
                     <td  align="right" valign="middle">
                        &nbsp;&nbsp;|&nbsp;&nbsp;
                    </td> 
                  
                </tr>
            </table>
            </td> 
        </tr>
    </table>
    </div>
    </form>
</body>

</html>

