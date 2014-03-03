<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" 
Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.Model.Enterprise>>" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	酒店管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-form-plugin.js"></script>

    <div class="varietyMsg">
        <!--用户信息-->
        <div class="varietyMsgBox">
            <b>客户管理</b><br /><br />
                <hr />
            <!--用户列表-->
            <div class="varietyList">
                <table class="gray_border1_table hover_gray tableCenter paddingStyle" width="250" id="tabeplist">
                    <tr class="tableTop" >
                    <td>酒店名称</td>
                    <td>操作</td>
                    </tr>
                    <%if (Model != null)
                      {
                          foreach (Enterprise ep in Model)
                          { %>
                            <tr id="row<%=ep.EID %>">
                            <td><%=ep.EName%></td>
                            <td>
                                       <img src="../../../Content/Image/pagesImg/edit.png" style="cursor:pointer;"
                                              onclick="update(<%=ep.EID %>)" title="修改" />&nbsp;&nbsp;
                                     <%if (ep.Deleted)
                                           { %>
                                           <img src="../../../Content/Image/pagesImg/forbidden.png" id="banep<%=ep.EID %>" style="cursor:pointer;"
                                              onclick="setDelState(<%=ep.EID %>)" title="禁用" />
                                         <%}
                                           else
                                           { %>
                                            <img src="../../../Content/Image/pagesImg/activate.png"  id="banep<%=ep.EID %>" style="cursor:pointer;"
                                              onclick="setDelState(<%=ep.EID %>)" title="激活" />
                                         <%} %>
                                         &nbsp;
                                       <img src="../../../Content/Image/pagesImg/del.png" style=" cursor:pointer; " onclick="delEp('<%=ep.EID %>')" title="删除"/>  
                            </td>
                            </tr>
                    <%}
                      }%>
                </table>
            </div>
            <!--用户详细信息添加/修改-->
            <div class="varietyDetail"> 
              <input class="btnStyle" type="button" value="添加新企业" onclick="btnAddEp();"/>
              <form id="addEpForm"  action="/ManagerCenter/AddHotel" method="post">
                <input type="hidden" id="operate" name="operate" value="add" />
                <input type="hidden" id="eid" name="eid" />
                <table class="personMsgTable gray_border_table " width="340">
                    <tr>
                    <td>酒店名称：</td>
                    <td><input class="personMsgText" id="ename"  name="ename" type="text" /><font color="red" id="err"></font></td>
                    </tr>
                    <tr>
                    <td>地址：</td>
                    <td><input class="personMsgTextLong" id="addr" name="addr" type="text" /></td>
                    </tr>
                    <tr>
                    <td>联系电话：</td>
                    <td><input class="personMsgText" id="phone" name="phone" type="text" /> <font id="pherr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>传真：</td>
                    <td><input class="personMsgText" id="fax" name="fax" type="text" /><font id="faxerr" color="red"></font></td>
                    </tr>
                    <tr>
                    <td>E-mail：</td>
                    <td><input class="personMsgText" id="email" name="email" type="text" /> <font id="emerr" color="red"></font></td>
                    </tr>
                    <!--<tr>
                    <td>返点：</td>
                    <td><input class="personMsgText" id="discount" name="discount" type="text" value="0" /><!--&nbsp;&nbsp;默认：0
                     <font id="dcerr" color="red"></font></td>
                    </tr>-->
                    </table>
                    </form>
                    <div class="btnDivSytle">
                        <input class="btnStyle" id="btnOpr" type="button" value="确认添加" onclick="btnOperate();"  />
                    </div>
            </div>
        </div>
    </div>  

</asp:Content>
