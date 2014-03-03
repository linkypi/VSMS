<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<VSMS.Models.MVCModels.AnalyseDataModel>" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>订单数据统计</title>
    <link rel="stylesheet" type="text/css" href="../../Content/main.css"/>
    <script type="text/javascript" src="../../../Scripts/jquery-1.7.2.min.js"></script>
     <script type="text/javascript" src="../../../Scripts/main.js"></script>
</head>
<body>
    <img src="../../../Content/Image/pagesImg/print.png" id="printda"  class="print" alt="" align="right" onclick="printOrder('printda')"/>
    <div align="center" style="margin:40px 0;">
        <h1  align="center">中山安健蔬菜流通中心<%=ViewData["time"].ToString().Substring(0, 4) + "年" + ViewData["time"].ToString().Substring(4, 2) + "月"%>对账单</h1><br /><br />
        <table align="center" class="gray_border1_table" width="80%" >
              <tr >
                 <td rowspan="2">日期</td>
                 <%foreach(Enterprise e in Model.Enterpreses)
                    {%>
                        <td colspan="3" style="white-space:nowrap;"><%=e.EName %></td>
                  <%} %>
                 <td rowspan="2">总收入</td>
                 <td rowspan="2">总成本</td>
                 <td rowspan="2">利润</td>
              </tr>
              <tr >
                 <%for (int i = 0; i < Model.Enterpreses.Count;i++ )
                    {%>
                        <td>收入</td>
                        <td>成本</td>
                        <td>利润</td>
                  <%} %>
              </tr>
              <%if (Model.AnalyseDatas.Count != 0)
                {%>
                   <tr>
                        <td>总计</td>
                    <%
                        foreach(AnalyseData ad in Model.MonthData )
                        {
                            foreach (Enterprise e in Model.Enterpreses)
                            {
                              if(e.EID==ad.EID)
                              {%>
                                <td><%=ad.Amount %></td>
                                <td><%=ad.TotalCost %></td>
                                <td><%=ad.Amount-ad.TotalCost %></td>
                          <%  }
                            } 
                        }%>
                     <td><%=Model.TotolIncome %></td>
                     <td><%=Model.TotolCost %></td>
                     <td><%=Model.TotolProfit %></td>
                  </tr>
                   <%foreach (AnalyseData dayData in Model.DayData)
                    {
                        string day = dayData.OID.Substring(0, 8);%>
                        <tr>
                            <td><%=day.Substring(4,4) %></td>
                            <%
                            foreach (Enterprise e in Model.Enterpreses)
                            {
                                int i;
                                
                                for (i = 0; i < Model.AnalyseDatas.Count;i++ )
                                {
                                    if ((Model.AnalyseDatas[i].OID.Contains(day) && Model.AnalyseDatas[i].EID == e.EID))
                                    {%>
                                        <td><%=Model.AnalyseDatas[i].Amount%></td>
                                        <td><%=Model.AnalyseDatas[i].TotalCost%></td>
                                        <td><%=Model.AnalyseDatas[i].Amount - Model.AnalyseDatas[i].TotalCost%></td>
                                 <%     continue;
                                    }
                                }

                                if (i == Model.AnalyseDatas.Count)
                                {%>
                                    <td>0</td>
                                    <td>0</td>
                                    <td>0</td>
                                <%}
                            }
                            %>
                            <td><%=dayData.Amount %></td>
                            <td><%=dayData.TotalCost %></td>
                            <td><%=dayData.Amount-dayData.TotalCost %></td>
                        </tr>
                  <%}%>
              <%}%>
        </table>
        
    </div>
</body>
</html>
