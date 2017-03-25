<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Index.ModifyPwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改密码</title>
    <style type="text/css">
        a:link {  text-decoration:none; color:Black;} 
        a:hover { text-decoration: none; color:Black; cursor:pointer;} 
        a:active { text-decoration: none; color:Black;} 
        a:visited {text-decoration: none; color:Black;}
        .linkbut{border:none;padding:3px;}
        .panCon{margin:10px 0px 10px 0px;padding:0px}
        .tableCon{width:99%;border-top:1px solid black;border-right:1px solid black;background-color:#E6ECFA;padding:0px;margin:0px;}
        .tableCon tr{vertical-align:middle;padding:0px;margin:0px;}
        .tableCon td{padding:5px;border-bottom:1px solid black;border-bottom:1px solid black;border-left:1px solid black;}
        .input{border:1px solid gray;line-height:18px;height:20px;padding-left:3px;width:150px;}
        .lab{font-size:12px;color:Red}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table class="tableCon">
        <tr><td colspan="2" style="text-align:right"><asp:LinkButton ID="butSave" 
                runat="server" Text="保存" CssClass="linkbut" onclick="butSave_Click"></asp:LinkButton></td></tr>
        <tr>
            <td>原密码</td><td><asp:TextBox ID="ymm" runat="server" TextMode="Password" CssClass="input" /></td>
        </tr>
        <tr>
            <td>新密码</td><td><asp:TextBox ID="xmm" runat="server" TextMode="Password" CssClass="input" /></td>
        </tr>
        <tr>
            <td>确认密码</td><td><asp:TextBox ID="qrmm" runat="server" TextMode="Password" CssClass="input" /></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="laberr" CssClass="lab" runat="server"></asp:Label></td>
        </tr>
    </table>
    </form>
</body>
</html>

