<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage< List<VSMS.Models.Model.Enterprise>>" %>
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>中山安健蔬菜流通中心检货单</title>
    <link rel="stylesheet" type="text/css" href="../../Content/main.css"/>
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../Scripts/main.js"></script>
</head>
<body>
<br/><br/>
    <h1  align="center">中山安健蔬菜流通中心拣货单</h1><br/><br/>
     <img src="../../../Content/Image/pagesImg/print.png" title='打印'  alt="" class="print" id="printis" onclick="printOrder('printis');"/>
    <div align="center">
     <%
       Dictionary<string, string> valueDic = ViewData["InspectionSheetDetail"] as Dictionary<string, string>;
       List<Vegetable> vegetabls = ViewData["Vegetables"] as List<Vegetable>;
       if(valueDic!=null){%>
          <table align="center" class="gray_border1_table" width="60%">
              <tr >
                 <td>企业</td>
                 <%foreach(Enterprise ep in Model){ %>
                 <td colspan="<%=ep.DepList.Count %>" style="white-space:nowrap;"><%=ep.EName %></td>
                 <%} %>
              </tr>
              <tr ><!--style= "writing-mode:tb-rl ; height:80px;" layout-flow: vertical-ideographic; 或者 writing-mode:tb-rl ;-->
                  <td>品名</td>
                  <%foreach (Enterprise ep in Model)
                    {%>
                       <%foreach (Department dp in ep.DepList)
                         {%>
                              <td ><%=dp.DName %></td>
                     <%} %>
               <%} %>
              </tr>
              <%foreach (Vegetable vt in vegetabls)
                {%>
              <tr style="white-space:nowrap;">
                   <td><%=vt.VName %></td>
                        <%foreach (Enterprise ep in Model)
                    {%>
                       <%foreach (Department dp in ep.DepList)
                         {%>
                              <%if (valueDic.ContainsKey(ep.EName + dp.DName + vt.VName))
                                {%>
                              <td><%=valueDic[ep.EName + dp.DName + vt.VName]%></td>
                              <%}
                                else
                                { %>
                              <td></td>
                              <%} %>
                     <%} %>
               <%} %>
              </tr>
              <%} %>
          </table>
          <%} %>
    </div>
      <br/><br/><br/>
</body>
</html>
