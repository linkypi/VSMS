<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/OrderDealCenter.Master"
 Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.Model.Vegetable>>" %>
 <%@ Import Namespace="VSMS.Models.Model" %>
 <%@ Import Namespace="VSMS.Models.MVCModels" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	InputSellingPrice
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
    <h2>录入售价</h2>
    <form id="sellingpriceForm" name="sellingpriceForm" action="" method="post">
          <div class="orderTable" id="Div1"> 
         <table  class="gray_border1_table hover_gray" width="700px;" border="1"  >
             <tr>
                 <td  style="width:10%;">品名</td>
                 <td  style="width:10%;">成本价(￥)</td>
                 <% int count = 0;
                    if (Model != null)
                    {
                        if (ViewData["EnterpriseList"] != null)
                        { %>
                    <%  List<Enterprise> eplist = ViewData["EnterpriseList"] as List<Enterprise>;
                        count = eplist.Count;
                        foreach (Enterprise ep in eplist)
                        { %>
                           <td  style="width:10%;"><%=ep.EName%></td>
                   <%}
                        }
                    }%>
             </tr>
         </table>
         </div>
          <div class="orderTable" id="orderTable"> 
         <table  class="gray_border1_table hover_gray" style=" width:100%" >
            <%if (Model != null)
              {
                  Dictionary<string, object> dic = ViewData["VEMap"] as Dictionary<string, object>;
                  string key = "";
                  %>
              <%foreach (Vegetable vt in Model)
                {%>
             <tr>
                 <td  style="width:10%;"><%=vt.VName%></td>
                 <td  style="width:10%;"><%=vt.WholesalePrice%></td>
                  <%  foreach (Enterprise ep in ViewData["EnterpriseList"] as List<Enterprise>)
                    { %>
                     <td  style="width:10%;">
                        <% key = vt.VID.ToString() + "_" + ep.EID.ToString();
                          if (dic.ContainsKey(key))
                          { %>
                           <input style="width:100%; border:1px solid #53b046;" type="text" 
                           id="sp<%=key%>"  onkeyup="validateSP('sp<%=key %>')"
                           name="sp<%=key %>" />
                       <%} %>
                     </td>
                 <%} %>
             </tr>
            <%}
            }%>
         </table>
      </div>
        <div class="orderExamine">
      <%if (Model != null)
        { %>
          <input class="btnOrder" type="button" value="录入报价" onclick="inputSellingPrice();" />
   <%}%>
    </div>
    </form>
</asp:Content>
