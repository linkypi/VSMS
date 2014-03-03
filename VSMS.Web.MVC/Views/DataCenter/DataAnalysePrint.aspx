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
    <%if (Model.AnalyseDatas.Count == 0)
    {%>
        <script type="text/javascript">alert("没有本月份的数据，请重新查询！");window.close();</script>
    <%}else
      {%>
        <h1 align="center">中山安健蔬菜流通中心<%=ViewData["time"].ToString().Substring(0, 4) + "年" + ViewData["time"].ToString().Substring(4, 2) + "月"%>对账单</h1><br /><br />
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
              
                <tr>
                    <td>总计</td>
                <%
                    foreach (Enterprise e in Model.Enterpreses)
                    {
                        int i;
                        bool isShow = false;
                        for (i = 0; i < Model.MonthData.Count;i++ )
                        {
                            if (e.EID == Model.MonthData[i].EID)
                            {
                                isShow = true;%>
                                <td><%=Model.MonthData[i].Amount%></td>
                                <td><%=Model.MonthData[i].TotalCost%></td>
                                <td><%=Model.MonthData[i].Amount - Model.MonthData[i].TotalCost%></td>
                            <%}
                                
                        }
                        if (isShow==false)
                        {%>
                            <td>0</td>
                            <td>0</td>
                            <td>0</td> 
                        <%}
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
                        foreach (Enterprise en in Model.Enterpreses)
                        {
                            int j;
                            bool isTd=false;
                            for (j = 0; j < Model.AnalyseDatas.Count;j++ )
                            {
                                if ((Model.AnalyseDatas[j].OID.Contains(day) && Model.AnalyseDatas[j].EID == en.EID))
                                {
                                    isTd=true;%>
                                    <td><%=Model.AnalyseDatas[j].Amount%></td>
                                    <td><%=Model.AnalyseDatas[j].TotalCost%></td>
                                    <td><%=Model.AnalyseDatas[j].Amount - Model.AnalyseDatas[j].TotalCost%></td>
                                <%     continue;
                                }
                            }

                            if (isTd==false)
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
             
        </table>
        <%}%>
    </div>
</body>
</html>
