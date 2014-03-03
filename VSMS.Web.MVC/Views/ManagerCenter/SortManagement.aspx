<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master"
 Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.Model.Category>>" %>
 <%@ Import Namespace="VSMS.Models.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	分类管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-form-plugin.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
<script type="text/javascript">

</script>
    <div class="varietyMsg">
        <div class="varietyMsgBox">
            <b>分类管理</b><br /><br />
                <hr />
            <!--蔬菜列表-->
            <div class="varietyList" id="ctglist" style=" border:1px solid #ccc; width:200px;">
             <%foreach (Category cg in Model)
               {%>
               <div style=" margin-bottom:5px;">
                 <div class="fontStyle" id="parentDiv<%=cg.CID %>" 
                 onmouseout="hideImg(<%=cg.PCID%>)" onmouseover="showImg(<%=cg.PCID %>)">
                    <b id="b<%=cg.PCID %>">   
                      <%if (cg.Children.Count == 0)
                      { %> [-] <%}else { %>[+]<%} %>
                    </b>
                    <span id="parent<%=cg.PCID %>"
                     onclick="showOrHideDp(<%=cg.PCID %>)" ><%=cg.CName%></span> &nbsp;&nbsp; 
                    <img src="../../../Content/Image/pagesImg/edit.png" id="editimg<%=cg.CID %>" 
                              class="img"  onclick="getCtg(<%=cg.CID %>)"  title="修改"/>  &nbsp;
                    <img src="../../../Content/Image/pagesImg/add.png" id="add<%=cg.CID %>" 
                      class="img" onclick="addCtg(<%=cg.PCID %>)" title="添加"/>    &nbsp;
                    <img src="../../../Content/Image/pagesImg/del.png" id="delimg<%=cg.CID %>" 
                  class="img"  onclick="delCtg(<%=cg.CID %>,<%=cg.PCID %>)" title="删除"/>  
             </div> 
			     <div class="fontStyleChild" id="childDiv<%=cg.PCID %>">
                <ul id="ul<%=cg.PCID %>"><%int index = 0; %>
                    <%foreach (Category child in cg.Children)
                        { %>
                            <li id="ctg<%=child.CID %>" onmouseout="hideImg(<%=child.CID%>)" onmouseover="showImg(<%=child.CID %>)"> 
                                <%index++; if (index == cg.Children.Count)
                            {%>└ ┄[-]<%}
                            else
                            { %>├ ┄[-]<%} %> &nbsp;
                            <span style="width:10px;"><%=child.COrder %></span>&nbsp;
                                <a  id="a<%=child.CID %>"><%=child.CName%></a>&nbsp;
                                <img src="../../../Content/Image/pagesImg/edit.png" id="editimg<%=child.CID %>" 
                                 class="img"  onclick="getCtg(<%=child.CID %>)" title="修改"/>   &nbsp; 
                                <img src="../../../Content/Image/pagesImg/del.png" id="delimg<%=child.CID %>" 
                                class="img"  onclick="delCtg(<%=child.CID %>,<%=child.PCID %>)" title="删除"/>  
                           </li>
                    <%} %>
                </ul>
            </div>
               </div>
           <%} %>
            </div>
            <!--蔬菜详细信息修改-->
            <div class="varietyDetail">
               <form id="ctgForm" action="" method="post">
               <input type="hidden" name="ctgOpr" id="ctgOpr" value="add" />
               <input type="hidden" name="cid" id="cid"  />
                <table class="personMsgTable gray_border_table paddingStyle" width="440">
                    <tr>
                    <td>上级分类：</td>
                    <td>
                        <select id="pcid" name="pcid">
                        <%foreach (Category ctg in ViewData["Parents"] as List<Category>)
                          { %>
                            <option value="<%=ctg.PCID %>"><%=ctg.CName %></option>
                      <%} %>
                        </select>
                    </td>
                    </tr>
                    <tr>
                    <td>分类名称：</td>
                    <td><input class="personMsgText" type="text" id="cname" name="cname"/>
                     <font id="cnerr" color="red"></font>
                    </td>
                    </tr>
                      <tr>
                    <td>排序：</td>
                    <td><input class="personMsgText" type="text" id="corder" name="corder"/>
                         <font id="coerr" color="red"></font>
                    </td>
                    </tr>
                    </table></form>
                    <div class="btnDivSytle">
                        <input class="btnStyle" id="btnCtgConf" onclick="ctgConf()" type="button" value="确认添加"/>
                    </div>
            </div>
            <div class="clear"></div>
        </div>
    </div>

</asp:Content>
