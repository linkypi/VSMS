<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/OrderDealCenter.Master" 
 Inherits="System.Web.Mvc.ViewPage<VSMS.Models.MVCModels.OrderDetailModels>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	订单明细
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="orderMap">
            <a>Home&nbsp;>&nbsp;</a>
            <font>订单详细</font>
        </div>
    <div class="orderWholesaler">
        <b>订单详细</b>
        <hr />
        <%
            int count = this.Model.OrderDetailList.Count;
            int rightCount = count / 2;
            int leftCount = count - rightCount;
        %>
        <!--订单明细表-->
        <div class="twoTable"> 
            <table class="gray_border_table hover_gray leftTable" width="280">
                    <tr class="tableTop">
                    <td>商品名</td>
                    <td>数量</td>
                    <td>实际数量</td>
                    <td>售价</td>
                    </tr>
                    <%
                        for (int i = 0; i < leftCount;i++ )
                        {%>
                    <tr>
                    <td><%=Model.OrderDetailList[i].VName %></td>
                    <td><%=Model.OrderDetailList[i].OrderCount %></td>
                    <td><%=Model.OrderDetailList[i].RealCount %></td>
                    <td><%=Model.OrderDetailList[i].ActualPrice %></td>
                    </tr>
                        
                    <%    }
                    %>
                </table>
                <table class="gray_border_table hover_gray rightTable" width="280">
                    <tr class="tableTop">
                    <td>商品名</td>
                    <td>数量</td>
                    <td>实际数量</td>
                    <td>售价</td>
                    </tr>
                    <%
                        for (int i = leftCount; i < count; i++)
                    {%>
                    <tr>
                    <td><%=Model.OrderDetailList[i].VName %></td>
                    <td><%=Model.OrderDetailList[i].OrderCount %></td>
                    <td><%=Model.OrderDetailList[i].RealCount %></td>
                    <td><%=Model.OrderDetailList[i].ActualPrice %></td>
                    </tr>
                        
                    <%    }
                    %>
                </table>
        </div>
        <div class="clear"></div>
        <!--订单信息-->
        <b>订单信息</b>
        <div class=" clear"></div>
        <div class="orderMsg">
            <font>订单号：</font><font><%=Model.Order.OID %></font><br />
            <font>订单状态：</font><font>
            <%if (Model.Order.OrderState == VSMS.Models.Model.OrderState.Init) Response.Write("初始状态"); %>
            <%if (Model.Order.OrderState == VSMS.Models.Model.OrderState.HadDelivery) Response.Write("发货状态"); %>
            <%if (Model.Order.OrderState == VSMS.Models.Model.OrderState.Finished) Response.Write("完成状态"); %>
            </font><br />
            <font>下单日期：</font><font><%=Model.Order.OrderTime %></font><br />
            <font>实际配送金额：（元）</font><font><%=Model.Order.RealPrices %></font><br />
            <font class="remarkFont">备注：</font>
            <!--备注，向备注填充数据的时候，如果有多条数据可用<br />过行-->
            <div class="remark">
                <%
                    foreach (VSMS.Models.Model.OrderDetail od in Model.OrderDetailList)
                    {
                        string vname = od.VName;
                        string remarks = od.Remarks;
                        if (!String.IsNullOrEmpty(remarks)) { 
                %>
                            <%=vname %>:<%=remarks %><br />
                <%
                        }     
                    }
                %>
            </div>
        </div>
        <div class="orderMsg">
            <font>部门名称：</font><font><%=Model.Department.DName %></font><br />
            <font>企业(酒店)名称：</font><font><%=Model.Enterprise.EName %></font><br />
            <font>地址：</font><font><%=Model.Enterprise.Addr %></font><br />
        </div>
        <div class=" clear"></div>
    </div>

</asp:Content>
