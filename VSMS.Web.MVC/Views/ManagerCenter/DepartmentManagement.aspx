<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" 
Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.Model.Enterprise>>" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	部门管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-form-plugin.js"></script>
    <div class="varietyMsg">
        <!--用户信息-->
        <div class="varietyMsgBox">
            <b>部门管理</b><br /><br />
                <hr />
            <!--用户列表-->
            <div class="varietyList" style=" width:30%; border:1px solid #ccc; padding:10px">
               <!-- <p>客户列表</p>-->
                <!--<table class="gray_border1_table hover_gray tableCenter" width="200">-->
                <%if (Model != null)
                  {
                      foreach (Enterprise ep in Model)
                      { %>
                       <div style=" margin-bottom:5px;">
                        <div class="fontStyle" id="div1" onclick="showOrHideDp(<%=ep.EID %>)">
                            <b id="b<%=ep.EID %>">[+]</b><!--<hr style="border:1px dashed  #036;width:20px;" />-->
                            <font ><%=ep.EName%></font>
                        </div>
					    <div class="fontStyleChild" id="childDiv<%=ep.EID %>">
                            <ul id="ul<%=ep.EID %>"><%int index = 0; %>
                                <%foreach (Department dp in ep.DepList)
                                  { %>
                                        <li id="dp<%=dp.DID %>" onmouseout="hideImg(<%=dp.DID%>)" onmouseover="showImg(<%=dp.DID%>)">  
                                          <%index++;
                                            if (index == ep.DepList.Count)
                                            {%>└ ┄[-]<%}
                                            else
                                            { %>├ ┄[-]<%} %>
                                         <%if (dp.Deleted)
                                           { %>
                                                <a  id="a<%=dp.DID %>" style=" color:#ccc;"><%=dp.DName%></a>&nbsp;&nbsp;
                                            <img src="../../../Content/Image/pagesImg/edit.png" id="editimg<%=dp.DID %>" class="img"
                                              onclick="getDpInfo(<%=dp.DID %>,<%=ep.EID %>)" title="修改"/>&nbsp;&nbsp;
                                           <img src="../../../Content/Image/pagesImg/forbidden.png" id="faimg<%=dp.DID %>" class="img"
                                               onclick="forbiddenOrActivate(<%=dp.DID %>)" title="激活"/>
                                         <%}
                                           else
                                           { %>
                                                <a  id="a<%=dp.DID %>"><%=dp.DName%></a>&nbsp;&nbsp;
                                            <img src="../../../Content/Image/pagesImg/edit.png" id="editimg<%=dp.DID %>" class="img"
                                              onclick="getDpInfo(<%=dp.DID %>,<%=ep.EID %>)" title="修改"/>&nbsp;&nbsp;
                                            <img src="../../../Content/Image/pagesImg/activate.png" id="faimg<%=dp.DID %>" class="img"
                                               onclick="forbiddenOrActivate(<%=dp.DID %>,<%=ep.EID %>)" title="屏蔽"/>
                                         <%} %>
                                         &nbsp;
                                           <img src="../../../Content/Image/pagesImg/del.png" id="delimg<%=dp.DID %>" class="img" onclick="delDep(<%=dp.DID %>)" title="删除"/>  
                                         </li>
                                <%} %>
                            </ul>
                        </div> 
                      </div>
                    <%}
                  }%>
            </div>
            <!--用户详细信息修改-->
            <div class="varietyDetail">
                <form id="addDpForm" name="addDpForm" method="post" action="/ManagerCenter/AddOrUpdateDepartment">
                <input type="hidden" name="dmoperate" id="dmoperate" value="add"/>
                <input  type="hidden" name="did" id="did" />
                 <input class="btnOrder" type="button" id="btnopr" onclick="btnAdd();" value="添加部门"  />
                <table class="personMsgTable gray_border_table" width="440">
                    <tr>
                    <td>所属企业：</td>
                    <td>
                        <select id="ename" name="ename">
                            <%foreach (Enterprise ep in Model)
                              { %>
                            <option value="<%=ep.EID %>"><%=ep.EName %></option>
                          <%} %>
                        </select>
                    </td>
                    </tr>
                      <tr>
                    <td>部门名称：</td>
                    <td><input class="personMsgText" id="dname" name="dname" type="text" /><font id="dnerr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>地址：</td>
                    <td><input class="personMsgTextLong" id="daddr"  name="daddr" type="text"/><font id="dperr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>联系电话：</td>
                    <td><input class="personMsgText" id="dmbp"  name="dmbp" type="text"/><font id="mbperr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>传真：</td>
                    <td><input class="personMsgText" id="dfax"  name="dfax" type="text"/><font id="dferr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>E-mail：</td>
                    <td><input class="personMsgText" id="demail" name="demail" type="text"/><font id="demerr" color="red"></font></td>
                    </tr>
                     <!--<tr>
                   <td>返点：</td>
                    <td><input class="personMsgText" id="ddiscount" name="ddiscount" type="text" value="0" />&nbsp;&nbsp;默认：0
                     <font id="ddcerr" color="red"></font></td>
                    </tr>
                      <tr>
                    <td>人工车费：</td>
                    <td><input class="personMsgText" id="dlbc" name="dlbc" type="text" value="0" />
                     <font id="dlbcerr" color="red"></font></td>
                    </tr>-->
                    </table></form>
                    <div class="orderExamine">
                        <input class="btnOrder" type="button" id="btnConf" value="确认添加"  onclick="dpConf();" />
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
