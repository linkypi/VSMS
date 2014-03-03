<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/OrderDealCenter.Master"
Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.MVCModels.DeliveryNote>>" %>
 <%@ Import Namespace="VSMS.Models.MVCModels" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	录入实际收货量
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-position.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
 <div class="orderMap">
        <a>Home&nbsp;>&nbsp;</a>
        <a>订单管理&nbsp;>&nbsp;</a>
        <a>录入实收量&nbsp;>&nbsp;</a>
        <%if (Model != null && Model.Count!=0)
         {%>
                 <a><%=Model[0].EName%>&nbsp;>&nbsp;</a>
                <font><%=Model[0].DName%></font>
       <%} %>
    </div>
    <div class="orderWholesaler">
    <h3 align="center">录入实收量</h3><br/>
    <form id="InputRealCountForm" name="InputRealCountForm" action="/OrderManager/TypeInRealCount/?oid=<%=ViewData["OID"]%>" method="post">
     <table  class="gray_border1_table hover_gray" width="650px;" border="1">
            <tr align="center">
                    <td style=" width:5%;">类</td>
                    <td style=" width:15%;">代码</td>
                    <td style=" width:15%;">品名</td>
                    <td style=" width:10%;">数量</td>
                    <td style=" width:10%;">单价</td>
                    <td style=" width:15%;">总金额 (￥)</td>
                    <td style=" width:15%;">实收量</td>
                    <td style=" width:15%;">实收金额 (￥)</td>
            </tr>
     </table>
     <table  class="gray_border1_table hover_gray" width="650px;" border="1">
     <%if (Model != null && Model.Count != 0)
       { %>
                  <%foreach (DeliveryNote dn in Model)
                    { %>
                       <tr align="center">
                              <td style=" width:5%;"><%=dn.Keys%></td>
                              <td style=" width:15%;"><%=dn.VCode%></td>
                              <td style=" width:15%;"><%=dn.VName%></td>
                              <td style=" width:10%;"><span id="oc<%=dn.VID %>"><%=dn.OrderCount%></span></td>
                              <td style=" width:10%;"><span id="span<%=dn.VID %>"><%=dn.ActualPrice%></span></td>
                              <td style=" width:15%;"><%=dn.OrderCount * dn.ActualPrice%></td>
                              <td style="width:15%;">
                              <input type="text" id="input<%=dn.VID %>" name="input<%=dn.VID %>" 
                                onblur="calcTotal('<%=dn.VID %>')" 
                              onkeyup="calcTotal('<%=dn.VID %>')" style="width:80px;" />
                              </td>
                              <td style=" width:15%;"><span id="total<%=dn.VID %>" ></span></td>
                      </tr>
                  <%}
       } %> 
            </table> 
              <!--审核通过-->
        <div class="orderExamine">
        <%if (Model != null && Model.Count != 0)
          { %>
            <input class="btnOrder" type="button" value="录入实收量" onclick="inputReal();" />
            <%} %>
        </div>
        </form>
    </div>
</asp:Content>
