<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/TakeOrder.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	下订单主页
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% TakeOrderModles MVCModel =  ViewData["MvcModel"] as TakeOrderModles; %>
<!--购物车BOX-->
    	<!--侧边栏-->
    	<div class="contentWholesalerLeft"> 
            <div class=" cartBox">
                <div class="cartMsg">
                <ul>
                <%foreach(ShopingCart sc in MVCModel.ShopingCartItems) {%>
                 <li vid="<%=sc.VID %>" did="<%=sc.DID %>">
                    <div class="cartDetails">
                        <font class="nameVege"><%=sc.VName %></font>
                        <font>X</font><font type="text" class="txtCartD"><%=sc.VCount %></font>
                        <a class="delCartItem">删除</a>
                        <a class="alterCartItem">修改</a>
                    </div>
                   </li>
                   <%} %>
                </ul> 
                </div>
                <div class="submitCart">
                    <input type="button" value="提交订单" class="btnSubmit" id="submitShopingCart" />
               </div>
            </div>

         </div>
<!--购物车BOX End-->
<!--contentRight内容页-->
<div class="contentWholesalerRight">
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
     <script type="text/javascript" src="../../Scripts/main.js"></script>
    <!--选择企业、部门--->
          <p class="departmentSelect">
                <b>企业：</b>
                <select id="Enterprise">
                        <% foreach (Enterprise enterprise in MVCModel.EnterpriseList)
                       {%>
                    <option value="<%=enterprise.EID %>"
                        <%if(enterprise.EID==MVCModel.CurrentEnterprisesID) Response.Write("selected=\"selected\"");%> > 
                        <%=enterprise.EName %>
                    </option>
                    <%} %>
                </select>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <b>部门：</b>
                <select id="Department" action="2">
                    <%foreach (Department department in MVCModel.CurrentDepartmentList)
                    { %>
                        <option value="<%=department.DID%>"
                            <%if(department.DID == MVCModel.CurrentDepartmentID) Response.Write("selected=\"selected\"");%>>
                            <%=department.DName%>
                        </option>
                    <%} %>
                </select>
              </p>

        		 <!--头部菜单导航ABC,DEF...-->
      <div id="abc">
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
                 <%int p = 0; %>
                 <%if (MVCModel.Vges.FindAll(v => v.Keys == "A").Count!=0){%>
                    <li><!--字母分类列表-->
                        <h3>A<!--还没有改好，交给你了。栩谦<br />Re:改好之后我会打屎你<img src="http://img.t.sinajs.cn/t35/style/images/common/face/ext/normal/49/hatea_thumb.gif"/>--></h3>
                         <ul><!--字母分类子列表-->
                         <%p = 0; %>
                         <%foreach (Vegetable Vge in MVCModel.Vges)
                           {
                               if (Vge.Keys != "A")continue;%>
                              <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                                    <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                                    <span class="addRemarks">备注</span>
                                    <span class="addToCart">加入购物车</span>
                                    <input type="text" class="goodsCountInput" maxlength="5"/>
                                    <input type="hidden" id="remark" value="" />
                                    <font class="mulSymbol">X</font>
                                </li>
                             <%p++;
                           } %> <%-- foreach end --%>
                              <!--备注：-->
                                <!--<div class="remarksBox clear">备注：<input type="text" /><span class="remarkBoxOKBtn" >完成</span><span class="CloseRemarkBoxBtn">X</span></div>-->
                            </ul>
                    </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "B").Count!=0){%>       
                    <li><!--字母分类列表B-->
                        <h3>B</h3>
                        <ul><!--字母分类子列表-->
                         <%p = 0; %>
                         <%foreach (Vegetable Vge in MVCModel.Vges)
                           {
                               if (Vge.Keys != "B") continue;%>
                              <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                                    <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                                    <span class="addRemarks">备注</span>
                                    <span class="addToCart">加入购物车</span>
                                    <input type="text" class="goodsCountInput" maxlength="5"/>
                                    <input type="hidden" id="remark" value="" />
                                    <font class="mulSymbol">X</font>
                                </li>
                             <%p++;
                           } %> <%-- foreach end --%>
                        </ul>
                    </li>
             <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "C").Count!=0){%>   
                    <li><!--字母分类列表B-->
                        <h3>C</h3>
                        <ul><!--字母分类子列表-->
                        <%p = 0; %>
                         <%foreach (Vegetable Vge in MVCModel.Vges)
                           {
                               if (Vge.Keys != "C") continue;%>
                              <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                                    <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                                    <span class="addRemarks">备注</span>
                                    <span class="addToCart">加入购物车</span>
                                    <input type="text" class="goodsCountInput" maxlength="5"/>
                                    <input type="hidden" id="remark" value="" />
                                    <font class="mulSymbol">X</font>
                                </li>
                             <%p++;
                           } %> <%-- foreach end --%>
                        </ul>
                    </li>
                <%} %>
                </ul>
        <!--DEF菜单-->
        <ul class="menuContent" id="menu-2" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "D").Count!=0){%>   
        <li>
            <h3>D</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "D") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "E").Count!=0){%>
        <li>
            <h3>E</h3>
            <ul>
             <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "E") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "F").Count!=0){%>
        <li>
            <h3>F</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "F") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--GHI菜单-->
        <ul class="menuContent" id="menu-3" style="display:none;">
         <%if (MVCModel.Vges.FindAll(v => v.Keys == "G").Count!=0){%>
        <li>
            <h3>G</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "G") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "H").Count!=0){%>
        <li>
            <h3>H</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "H") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "I").Count!=0){%>
        <li>
            <h3>I</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "I") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--JKL菜单-->
        <ul class="menuContent" id="menu-4" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "J").Count!=0){%>
        <li>
            <h3>J</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "J") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "K").Count!=0){%>
        <li>
            <h3>K</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "K") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "L").Count!=0){%>
        <li>
            <h3>L</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "L") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--MNO菜单-->
        <ul class="menuContent" id="menu-5" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "M").Count!=0){%>
        <li>
            <h3>M</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "M") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "N").Count!=0){%>
        <li>
            <h3>N</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "N") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "O").Count!=0){%>
        <li>
            <h3>O</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "O") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value=""/>
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--PQR菜单-->
        <ul class="menuContent" id="menu-6" style="display:none;">
           
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "P").Count!=0){%>
        <li>
            <h3>P</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "P") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "Q").Count!=0){%>
        <li>
            <h3>Q</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "Q") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "R").Count!=0){%>
        <li>
            <h3>R</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "R") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--STU菜单-->
        <ul class="menuContent" id="menu-7" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "S").Count!=0){%>
        <li>
            <h3>S</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "S") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "T").Count!=0){%>
        <li>
            <h3>T</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "T") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "U").Count!=0){%>
        <li>
            <h3>U</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "U") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
        <!--VWS菜单-->
        <ul class="menuContent" id="menu-8" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "V").Count!=0){%>
        <li>
            <h3>V</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "V") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "W").Count!=0){%>
        <li>
            <h3>W</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "W") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "X").Count!=0){%>
        <li>
            <h3>X</h3>
            <ul>
            <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "X") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
           </ul>
        </li>
        <%} %>
        </ul>
        <!--YZ菜单-->
        <ul class="menuContent" id="menu-9" style="display:none;">
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "Y").Count!=0){%>
        <li>
            <h3>Y</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "Y") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
            <%} %>
            <%if (MVCModel.Vges.FindAll(v => v.Keys == "Z").Count!=0){%>
        <li>
            <h3>Z</h3>
            <ul>
                <%p = 0; %>
                <%foreach (Vegetable Vge in MVCModel.Vges)
                {
                    if (Vge.Keys != "Z") continue;%>
                    <li position="<%=(p%2) %>"><!--商品详情，如果position="0"，则备注框、趋势图在下一个"li"后边显示-->
                        <span class="vegetablesName" vid ="<%=Vge.VID %>"><%=Vge.VName%></span>                    
                        <span class="addRemarks">备注</span>
                        <span class="addToCart">加入购物车</span>
                        <input type="text" class="goodsCountInput" maxlength="5"/>
                        <input type="hidden" id="remark" value="" />
                        <font class="mulSymbol">X</font>
                    </li>
                    <%p++;
                } %> <%-- foreach end --%>
            </ul>
        </li>
        <%} %>
        </ul>
      </div><!--ABC end-->
</div>
<div class="mtipsBox" style="display: none;">...我不是小菊花</div>
<img style="display:none;" src="../Content/Image/pagesImg/busy.gif" />
</asp:Content>
