<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>采购单打印</title>
     <link rel="stylesheet" type="text/css" href="../../Content/main.css"/>
     <script type="text/javascript" src="../../Scripts/main.js"></script>
     <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
</head>
<body >
    <br/><br/> <h2 align="center">中山安健蔬菜流通中心采购单</h2><br/>
   <img src="../../../Content/Image/pagesImg/print.png" title='打印' id="printpn" class="print"  onclick="printOrder('printpn');"/>
   <br/><br/>
    <div align="center">
        <% List<PurchaseNote> models = ViewData["PurchaseNote"] as List<PurchaseNote>;  %>
        <%if(models!=null){ %>
        <table align="center" class="gray_border1_table" width="60%">
           <tr align="center"  >
                <td>品名</td>
                <td>采购数量</td>
                <td>单价</td>
                <td>金额</td>
                <td>备注</td>
           </tr>
           <%foreach(PurchaseNote pn in models) {%>
           <tr align="center" >
                <td><%=pn.VName %></td>
                <td><%=pn.OrderCount %></td>
                <td><!--<%=pn.ActualPrice %>--></td>
                <td><!--<%=pn.ActualPrice*pn.OrderCount %>--></td>
                <td><%=pn.Remarks %></td>
           </tr>
           <%} %>
        </table>
        <%} %>
    </div>
    <br />
   <br/><br/><br/>
</body>
</html>
