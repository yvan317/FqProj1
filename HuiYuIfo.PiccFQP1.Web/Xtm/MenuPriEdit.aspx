<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPriEdit.aspx.cs" Inherits="HuiYuIfo.PiccFQP1.Web.Xtm.MenuPriEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Content/Css/edit.css" rel="stylesheet" type="text/css" />
    
    <link href="../Content/Css/zTreeStyle.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="Did" runat="server" />
    <div style="width:90%;margin-left:40px;margin-right:40px;margin-top:20px; text-align:right;">
        <input type="button" onclick="but_save()" value="保存" class="but" />
    </div>
    <div style="border:1px gray solid;padding:10px;margin-top:30px;width:80%;margin-left:40px;margin-right:40px;">
        <ul id="menutree" class="ztree"></ul>
    </div>
    </form>
</body>
    <script src="../Content/Js/jquery.js" type="text/javascript"></script>
    <script src="../Content/Js/jquery.ztree.all.min.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var setting = {
            check: {
                chkboxType: { "Y": "ps", "N": "ps" },
                enable: true
            },
            data: {
                simpleData: {
                    enable: true,
                    idKey: "id",
                    pIdKey: "pid",
                    rootPId: null
                }
            }
        };
        $(document).ready(function () {
            var myDate = new Date();
            var sec = myDate.getMilliseconds();
            $.getJSON("../Index/AjaxPage.aspx?optype=menuJson&id=" + $("#Did").val() + "&t=" + sec, function (data) {
                $.fn.zTree.init($("#menutree"), setting, data);
                var treeObj = $.fn.zTree.getZTreeObj("menutree");
                treeObj.expandAll(true);
            });
        });
        function but_save() {
            var list = $.fn.zTree.getZTreeObj("menutree").getCheckedNodes(true);
            var tempStr = $("#Did").val() + "|";
            for (var i = 0; i < list.length; i++) {
                tempStr += list[i].id + "-" + list[i].code + "|";
            }
            if (tempStr != "") {
                var data = { data: tempStr };
                saveajax(data);
            }
        }
        function saveajax(menustr) {
            var myDate = new Date();
            var sec = myDate.getMilliseconds();
            $.post("../Index/AjaxPage.aspx?optype=saveMenu&t=" + sec, menustr,
          function (data) {
              if (data == "y") {
                  alert("保存完成");
                  window.close();
              } else {
                  alert("保存出错");
              }
          });
        }
    </script>
</html>

