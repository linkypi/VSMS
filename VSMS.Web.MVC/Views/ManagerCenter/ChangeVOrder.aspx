<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	更改蔬菜排序
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="vegetableManagePanel">
            <!--头部菜单导航ABC,DEF...-->
            <ul class="menuNav">
                <li id="tab-1" style="background-color:#FFF;">
                    <ul><li>A</li><li>B</li><li>C</li></ul>
                </li>
                <li id="tab-2">
                    <ul><li>D</li><li>E</li><li>F</li></ul>
                </li>
                <li id="tab-3">
                    <ul><li>G</li><li>H</li><li>I</li></ul>
                </li>
                <li id="tab-4">
                    <ul><li>J</li><li>K</li><li>L</li></ul>
                </li>
                <li id="tab-5">
                    <ul><li>M</li><li>N</li><li>O</li></ul>
                </li>
                <li id="tab-6">
                    <ul><li>P</li><li>Q</li><li>R</li></ul>
                </li>
                <li id="tab-7">
                    <ul><li>S</li><li>T</li><li>U</li></ul>
                </li>
                <li id="tab-8">
                    <ul><li>V</li><li>W</li><li>X</li></ul>
                </li>
                <li id="tab-9">
                    <ul><li>Y</li><li>Z</li></ul>
                </li>
            </ul>
            <ul class="menuContent" id="menu-1"><!--菜单详细内容-->
            <% List<Vegetable> vorder = ViewData["VOrderList"] as List<Vegetable>;%>
                <li><!--字母分类列表A-->
                    <h3>A<br/>
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%foreach(Vegetable veg in vorder)
                    {%>
                        <li>
                            <span><%=veg.VName %></span>&nbsp;&nbsp;&nbsp;
                            <input class="inputText" name="vOrder[<%=veg.VID %>]" type="text" value="<%=veg.VOrder %>"/>
                        </li>
                    <%} %>
                    </ul>
                </li>
                <li><!--字母分类列表B-->
                    <h3>B<br/>
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <li><span>冬瓜</span>&nbsp;&nbsp;&nbsp;<input class="inputText" type="text"/></li>
                    </ul>
                </li> 
                <li><!--字母分类列表C-->
                    <h3>C<br/>
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <li><span>冬瓜</span>&nbsp;&nbsp;&nbsp;<input class="inputText" type="text"/></li>
                    </ul>
                </li>
                    
                </ul>
                <!--DEF菜单-->
                <ul class="menuContent" id="menu-2" style="display:none;">
                <li>
                    <h3>D</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>F</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>G</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--GHI菜单-->
                <ul class="menuContent" id="menu-3" style="display:none;">
                <li>
                    <h3>G</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>H</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>I</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--JKL菜单-->
                <ul class="menuContent" id="menu-4" style="display:none;">
                <li>
                    <h3>J</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>K</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>L</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--MNO菜单-->
                <ul class="menuContent" id="menu-5" style="display:none;">
                <li>
                    <h3>M</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>N</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>O</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--PQR菜单-->
                <ul class="menuContent" id="menu-6" style="display:none;">
                <li>
                    <h3>P</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>Q</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>R</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--STU菜单-->
                <ul class="menuContent" id="menu-7" style="display:none;">
                <li>
                    <h3>S</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>T</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>U</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--VWS菜单-->
                <ul class="menuContent" id="menu-8" style="display:none;">
                <li>
                    <h3>V</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>W</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>S</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
                <!--YZ菜单-->
                <ul class="menuContent" id="menu-9" style="display:none;">
                <li>
                    <h3>Y</h3>
                    <ul><li>1</li></ul>
                </li>
                <li>
                    <h3>Z</h3>
                    <ul><li>1</li></ul>
                </li>
                </ul>
            <input class="bottomBtnStyle" type="button" value="提交修改" /> 
    </div>

</asp:Content>
