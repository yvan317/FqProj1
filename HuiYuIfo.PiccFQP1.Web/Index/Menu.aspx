<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Index.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>菜单列表</title>
    <style type="text/css">
        form{background-color:#efefef;height:98%;}
        html,body{font-family:"Microsoft Yahei", Tahoma, "SimSun" ;padding:0px;margin:0px;width:100%;height:100%;}
        a:link {  text-decoration:none; color:Black;} 
        a:hover { text-decoration: none; color:Black; cursor:pointer;} 
        a:active { text-decoration: none; color:Black;} 
        a:visited {text-decoration: none; color:Black;} 
    </style>
</head>
<body>
    <form id="form1" runat="server" >
        <div style="width:99%;height:100%;margin:0px;padding:0px;border-right:1px solid Gray;">
        <asp:TreeView ID="tvMenuList" runat="server" BorderStyle="None" ExpandDepth="2"
                    ImageSet="Arrows" onselectednodechanged="tvMenuList_SelectedNodeChanged" 
                    Width="180px" Height="100%" Font-Size="14px" NodeIndent="10">
        <ParentNodeStyle Font-Bold="False" Font-Size="14px"/>
        <HoverNodeStyle Font-Underline="False"  Font-Size="14px" BackColor="#CCCCCC"  />
        <SelectedNodeStyle Font-Underline="False"  Font-Size="14px"  
                HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px" BackColor="#CCCCCC" />
        <NodeStyle Font-Underline="False" Font-Size="14px" ForeColor="Black"  
                HorizontalPadding="5px" NodeSpacing="1px" VerticalPadding="2px"  />
     </asp:TreeView>
     </div>
    </form>
</body>
</html>