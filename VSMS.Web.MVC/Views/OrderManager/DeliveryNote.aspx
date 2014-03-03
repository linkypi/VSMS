<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>发货单打印</title>
     <link rel="stylesheet" type="text/css" href="../../Content/main.css"/>
     <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
      <script type="text/javascript" src="../../Scripts/jquery-form-plugin.js"></script>
    <script type="text/javascript" src="../../Scripts/main.js"></script>

</head>
<body >
     <br/><br/>
    <h1 align="center">安健蔬菜流通中心送货单</h1><br/><!--printOrder-->
     <img src="../../../Content/Image/pagesImg/print.png" title="打印" alt=""  class="print" id="printdn" onclick=" printDN('printdn');"/>
     <img src="../../../Content/Image/pagesImg/modifydn.png" title="修改" alt=""   class="modifydn" id="modifydn" onclick="mofigydn()"/>
       <%   List<DeliveryNote> models =ViewData["DeliveryNote"] as List<DeliveryNote>; %>
       <% if (models != null)
          { %>
          <div align="center">
          <form id="dnForm" name="dnForm" action="/OrderManager/UpdateDeliveryNote/?oid=<%=models[0].OID %>"  method="post">
           <table  width="800px"> 
              <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
              <tr align="left">
                   <td> 
                       <span>订单编号：<%=models[0].OID%> </span>
                       <input type="hidden" id="oid" value="<%=models[0].OID%>" />
                   </td>
                   <td></td> <td></td> <td></td>
              </tr>
              <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
              <tr align="left">
                   <td> <span>客户：<%=models[0].EName %>&nbsp;-----&nbsp;<%=models[0].DName %></span></td>
                   <td></td> 
                   <td><span>日期：<%=models[0].OrderTime %></span></td>
                    <td></td>
              </tr>
              <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
           <tr><td colspan="4" align="center">
            <table class="gray_border1_table" width="100%">
                  <tr align="center">
                      <td>类</td>
                      <td>代码</td>
                      <td>品名</td>
                      <td>数量</td>
                      <td>单价</td>
                      <td>总金额 (￥)</td>
                      <td>实收量</td>
                      <td>实收金额 (￥)</td>
                </tr>
                  <%foreach (DeliveryNote dn in models)
                    { %>
                       <tr align="center">
                              <td><%=dn.Keys %></td>
                              <td><%=dn.VCode %></td>
                              <td><%=dn.VName %></td>
                              <td><span id="span<%=dn.VID %>"><%=dn.OrderCount %></span></td>
                              <td style=" width:80px;" id="td<%=dn.VID %>">
                                 <span id="sp<%=dn.VID %>"><%=dn.ActualPrice %></span>
                              </td>
                              <td id="total<%=dn.VID %>"><%=dn.OrderCount*dn.ActualPrice %></td>
                              <td></td>
                              <td></td>
                      </tr>
                  <%} %>
            </table> </td></tr>
            <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
               <tr align="left">
                 <td> <span>签收人：<%=models[0].Recipient%></span></td>
                 <td></td>
                 <td><span>经手人：<%=models[0].HandledBy%></span></td>
                 <td></td>
             </tr>
             <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
               <tr align="left">
                 <td><span>地址：<%=models[0].Addr%></span></td>
                 <td></td>
                 <td><span>手机：<%=models[0].MobilePhone%></span></td>
                 <td></td>
             </tr>
             <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
               <tr align="left">
                 <td><span>传真：<%=models[0].Fax %></span> </td>
                 <td></td>
                 <td><span>电话：<%=models[0].Phone%></span></td>
                 <td></td>
             </tr>
             <tr> <td>&nbsp;</td> <td></td> <td></td><td></td></tr>
               <tr align="left">
                 <td colspan="4">
                      <span>第一联会计（<font color="silver">白</font>）</span>
                     <span>第二联存根（<font color="red"">红</font>）</span>
                     <span>第三联会计（<font color="blue">蓝</font>）</span>
                     <span>第四联客户（<font color="#E5EE08">黄</font>）</span>
                 </td>
             </tr>
    </table></form></div>
    <%} %>
    <br/><br/><br/>
</body>
</html>
