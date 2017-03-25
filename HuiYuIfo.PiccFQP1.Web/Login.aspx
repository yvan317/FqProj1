<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Login" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <style type="text/css">
        .lab { text-decoration:none; color:White;  font-size:small; font-weight:bold; font-family:@楷体_GB2312 } 
        .text{ width:120px;border-left-width:1px;border-right-width:1px;border-top-width:1px;border-bottom-width:1px;border-color:Black;font-size:small; font-weight:bold; } 
        a:link {  text-decoration:none; color:Black;  font-size:small; font-weight:bold; } 
        a:hover { text-decoration: none; color:Black;  font-size:small; font-weight:bold; } 
        a:active { text-decoration: none; color:Black;  font-size:small; font-weight:bold; } 
        a:visited {text-decoration: none; color:Black;   font-size:small; font-weight:bold; } 
    </style> 
    <script language="javascript" type="text/javascript">
        function reset() {
            document.getElementById("txtUserpwd").Value = "";
            document.getElementById("txtUsername").Value = "";
            return false;
        }
    </script>
    <style type="text/css">
        .test{ background-image: url("Content/Img/loadbg.jpg"); background-repeat:no-repeat; width:800px; height:600px; vertical-align:middle;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <center>
       <div class="test" >
            <table>
                <tr height="305px"><td colspan="2"></td></tr>
                <tr>
                    <td align="left"><asp:Label ID="labname" CssClass="lab" runat="server"  Width="250px"></asp:Label></td>
                        <td align="left"><asp:TextBox ID="txtUsername" CssClass="text" runat="server"></asp:TextBox></td>
                </tr>
                <tr height="10px"><td colspan="2"></td></tr>
                <tr>
                        <td align="left"><asp:Label ID="labpwd" CssClass="lab" runat="server" Width="250px"></asp:Label></td>
                        <td align="left"><asp:TextBox ID="txtUserpwd" CssClass="text" runat="server" TextMode="Password"></asp:TextBox></td>
                             
                </tr>
                <tr height="10px"><td colspan="2"></td></tr>
                <tr>
                        <td align="right" colspan="2"><asp:Button ID="Button1" Text="登录" runat="server" onclick="submit_Click" />
                     
                        </td>      
                </tr>
                <tr>       
            </table>
       </div>
        </center>
    </div>
    </form>
</body>
</html>


