<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/DataCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	订单数据统计
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script language="javascript" type="text/javascript" src="../../Scripts/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Scripts/main.js"></script>

    <div class="dataCenterDiv">
        <b>订单数据统计</b>
        <hr />
        <!--订单搜索框-->
        <div class="dataCenterTop">
            <form id="form1"  method="post" action="">
                <font>请选择要查询的月份：</font>
                <input class="Wdate" type="text" id="selectMonth" name="selectMonth" onclick="WdatePicker({dateFmt:'yyyy-MM'})"/>
                <input class="btnSearch" type="button" value="查&nbsp;询" onclick="validateMonth();"  />
            </form>
        </div>
    </div>
</asp:Content>
