<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/OrderDealCenter.Master"
 Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.MVCModels.PurchaseNote>>" %>
 <%@ Import Namespace="VSMS.Models.MVCModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	录入成本价
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
<div class="orderMap">
    <a>Home&nbsp;>&nbsp;</a>
    <a>订单处理&nbsp;>&nbsp;</a>
    <font>录入成本价</font>
</div>
<div class="orderWholesaler">
    <h3 align="center">订单详细</h3>
    <hr />
    <!--订单明细表-->
    <form id="InputPriceForm" name="InputPriceForm" action="/OrderManager/TypeInWholesalePrice" method="post">
        <table class="gray_border1_table hover_gray" width="650px;" border="1">
                <tr class="tableTop">
	            <td style="width:130px;">品名</td>
	            <td style="width:100px;">采购数量</td>
	            <td style="width:100px;">单位(进货价)</td>
	            <td style="width:150px;">单价最后更新时间</td>
	            <td style="width:120px;">金额(￥)</td>
                </tr>
        </table>
    <div class="orderTable" id="orderTable"> 
            <table class="gray_border1_table hover_gray" width="650px;" border="1">
            <tbody>
            <%if (Model!= null)
	        {
                foreach (PurchaseNote pn in Model )
		        {%>
	            <tr>
		        <td style="width:130px;"><%=pn.VName%></td>
		        <td style="width:100px;"><span id="<%="span"+pn.VID %>"><%=pn.OrderCount%></span></td>
		        <td style="width:99px;"><input id="<%="input"+pn.VID %>" name="<%="input"+pn.VID %>"  type="text" onblur="calcCost('<%=pn.VID %>')" 
                 onkeyup=" calcCost('<%=pn.VID %>')"  style="width:80px;"/></td>
		        <td style="width:150px;"><%=pn.UpdateTime%></td>
		        <td style="width:120px;"><span id="<%="total"+pn.VID %>"></span></td>
	            </tr>
            <%}
	        }%>
        </tbody></table> 
    </div>
    <!--审核通过-->
    <div class="orderExamine">
      <%if (Model != null)
        { %>
          <input class="btnOrder" type="button" value="录入成本价" onclick="inputPrice();" />
   <%}%>
    </div>
    </form>
</div>
    <div class="clear"></div>
</asp:Content>