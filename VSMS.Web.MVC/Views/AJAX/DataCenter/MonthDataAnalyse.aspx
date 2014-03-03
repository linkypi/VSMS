<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/DataCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	月数据统计
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dataCenterDiv">
        <b>月数据统计</b>
        <hr />
        <!--订单搜索框-->
        <div class="dataCenterTop">
            <font>选择客户：</font>
            <select>
                <option id="Option1" selected="selected">中山学院</option>
                <option id="Option2">阜沙国贸逸豪酒店</option>
                <option id="Option3">国宴酒店</option>
                <option id="Option4">国税局</option>
            </select>
            <font>选择日期</font>
            <select>
                <option id="week" selected="selected">2011</option>
                <option id="month">2012</option>
                <option id="year">2013</option>
            </select>
            <font>年</font> 
             <select>
                <option id="Option8" selected="selected">11</option>
                <option id="Option9">12</option>
                <option id="Option10">11</option>
            </select>
            <font>月</font>                   
            <input class="btnSearch" type="button" value="查&nbsp;询" />
        </div>
        <!--订单列表-->
        <div class="orderTable">
            <table class="gray_border_table hover_gray" width="670" border="1">
                <tr class="tableTop">
                    <td>客户名称</td>
                    <td>总成本</td>
                    <td>实收金额</td>
                    <td>利润</td>
                    <td></td>
                </tr>
                <tr>
                    <td>中厨</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td><a href="#">展开</a></td>
                </tr>
                <tr>
                    <td>6月1号</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td></td>
                </tr>
                <tr>
                    <td>6月2号</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td></td>
                </tr>
                <tr>
                    <td>6月3号</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td></td>
                </tr>
                <tr>
                    <td>6月4号</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td></td>
                </tr>
                <tr>
                    <td>鲍鱼档</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td><a href="#">展开</a></td>
                </tr>
                <tr>
                    <td>点心</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td><a href="#">展开</a></td>
                </tr>
                <tr>
                    <td>丽都会</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td><a href="#">展开</a></td>
                </tr>
                <tr>
                    <td>饭堂</td>
                    <td>1234</td>
                    <td>234</td>
                    <td>123</td>
                    <td><a href="#">展开</a></td>
                </tr>
                
            </table>
        </div>
    </div>

</asp:Content>
