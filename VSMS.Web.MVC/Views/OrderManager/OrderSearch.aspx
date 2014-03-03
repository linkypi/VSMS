<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/OrderDealCenter.Master" 
Inherits="System.Web.Mvc.ViewPage<VSMS.Models.MVCModels.OrderSearchModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	订单查询
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
     <script type="text/javascript" src="../../Scripts/main.js"></script>
    
    <div class="orderWholesaler">
                <b>我的订单</b>
                <hr />
                <form  method="get" id="OrderSearch" name="OrderSearch">
                <!--订单搜索框-->
                <div class="orderSearchWholesaler">
                    <font>客户：</font>
                    <select id="Enterprise" name="Enterprise">
                        <option value="-1" 
                            <%if("-1"==Model.CurrentEnterprise) Response.Write("selected=\"selected\"");%> 
                        >全部</option>
                        <% foreach (VSMS.Models.Model.Enterprise enterprise in Model.EnterpriseList)
                       {%>
                        <option value="<%=enterprise.EID %>"
                                <%if(enterprise.EID.ToString()==Model.CurrentEnterprise) Response.Write("selected=\"selected\"");%> 
                        > 
                            <%=enterprise.EName %>
                        </option>
                        <%} %>
                    </select>
                    <font>部门：</font>
                    <select id="Department" name="Department" action="1">
                        <option value="-1" 
                            <%if("-1"==Model.CurrentDepartment) Response.Write("selected=\"selected\"");%> 
                        >全部</option>
                        <%
                            if (Model.CurrentDepartmentList != null)
                            {
                                foreach (VSMS.Models.Model.Department department in Model.CurrentDepartmentList)
                                {%>
                        <option value="<%=department.DID %>"
                                <%if(department.DID.ToString()==Model.CurrentDepartment) Response.Write("selected=\"selected\"");%> 
                        > 
                            <%=department.DName%>
                        </option>
                        <%      }
                            } %>
                    </select>
                    <font>订单时间：</font>
                    <select name="OrderTime">
                        <option value="all" 
                        <%if("all"==Model.CurrentOrderTime) Response.Write("selected=\"selected\"");%>
                        >全部订单</option>
                        <option value="30"
                        <%if("30"==Model.CurrentOrderTime) Response.Write("selected=\"selected\"");%>
                        >近一个月</option>
                        <option value="7"
                        <%if("7"==Model.CurrentOrderTime) Response.Write("selected=\"selected\"");%>
                        >近一个星期</option>
                        <option value="1"
                        <%if("1"==Model.CurrentOrderTime) Response.Write("selected=\"selected\"");%>
                        >当天</option>
                    </select>
                    <font>订单状态：</font>
                    <select name="OrderState">
                        <option value="all" 
                        <%if("all"==Model.CurrentOrderState) Response.Write("selected=\"selected\"");%>
                        >全部</option>
                        <option value="0"
                        <%if("0"==Model.CurrentOrderState) Response.Write("selected=\"selected\"");%>
                        >初始状态</option>
                        <option value="1"
                        <%if("1"==Model.CurrentOrderState) Response.Write("selected=\"selected\"");%>
                        >待录入售价</option>
                        <option value="2"
                        <%if("2"==Model.CurrentOrderState) Response.Write("selected=\"selected\"");%>
                        >发货状态</option>
                        <option value="3"
                        <%if("3"==Model.CurrentOrderState) Response.Write("selected=\"selected\"");%>
                        >完成状态</option>
                    </select>
                    <input class="btnSearch" type="submit" value="查&nbsp;询" />
                    
                </div>
                </form>

                <script type="text/javascript">
                    function ToOrderDetail(oid) {
                        window.open("OrderDetail?orderid="+oid);
                    }
                 </script>

                <!--订单列表-->
                <div class="orderTable">
                    <table class="gray_border_table hover_gray" width="670" border="1">
                      <tr class="tableTop">
                        <td>订单编号</td>
                        <td>订购时间</td>
                        <td>企业</td>
                        <td>部门</td>
                        <td>订单状态</td>
                        <td>订单总金额</td>
                        <td>实际金额</td>
                      </tr>
                      <%if (Model.OrdersList != null)
                        {
                            foreach (VSMS.Models.Model.Orders order in Model.OrdersList)
                            {
                      %>
                      <tr ondblclick='ToOrderDetail(<%=order.OID %>)'>
                        <td><%=order.OID %></td>
                        <td><%=order.OrderTime %></td>
                        <td><%=order.EName %></td>
                        <td><%=order.DName %></td>
                        <td>
                            <%if (order.OrderState == VSMS.Models.Model.OrderState.Init) Response.Write("初始状态"); %>
                            <%if (order.OrderState == VSMS.Models.Model.OrderState.HadPrice) Response.Write("待录入售价"); %>
                            <%if(order.OrderState==VSMS.Models.Model.OrderState.HadDelivery)Response.Write("发货状态"); %>
                            <%if (order.OrderState == VSMS.Models.Model.OrderState.Finished) Response.Write("完成状态"); %>
                        </td>
                        <td>&yen;<%=order.TotalCost%></td>
                        <%string inputRealCount = "<a class='inputRealCount'target='_blank' href='InputRealCount?oid="+order.OID+"'>录入实收量</a>";%>
                        <td><%=order.OrderState == VSMS.Models.Model.OrderState.HadDelivery ? inputRealCount :(" &yen;"+ order.Amount.ToString())%></td>
                      </tr>
                      <%    }
                        }%>
                      
                    </table>

    
        </div>
        <%
            string url = "OrderSearch?Enterprise="+Model.CurrentEnterprise
                        +"&Department="+Model.CurrentDepartment
                        +"&OrderTime="+Model.CurrentOrderTime
                        +"&OrderState="+Model.CurrentOrderState;
         %>
        <!--nextPage下一页-->
        <div class="nextPage">
            <a href="<%=url %>">首页</a>
            <a href="<%=url %>&Page=<%=(Model.CurrentPage==1?1:Model.CurrentPage-1) %>">上一页</a>
            <%
                foreach (int i in Model.PageList)
                {
                    if (i == Model.CurrentPage)
                    {
             %>
                        <a <%="class='currentPage'" %> href="<%=url %>&Page=<%=i%>"><%=i%></a>
            <%      }
                    else
                    {
            %>
                        <a  href="<%=url %>&Page=<%=i%>"><%=i%></a>
            <%      }
                }%>
            <a href="<%=url %>&Page=<%=(Model.CurrentPage==Model.TotalPage?Model.TotalPage:Model.CurrentPage+1) %>">下一页</a>
            <a href="<%=url %>&Page=<%=Model.TotalPage %>">末页</a>
            <font>共有</font>
            <font class="allCount"><%=Model.TotalPage %></font>
            <font>页</font>
            <font class="allCount"><%=Model.Count %></font>
            <font>条记录</font>
        </div>
    </div>

</asp:Content>
