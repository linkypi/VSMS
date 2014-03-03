<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master"
 Inherits="System.Web.Mvc.ViewPage<List<VSMS.Models.Model.Category>>" %>
 <%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	添加商品
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/jquery-form-plugin.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
    <div class="varietyMsg">
        <!--品种信息-->
        <div class="varietyMsgBox">                	
            <!--添加新品种-->
            <div class="varietyMsg ">
                <b>品种管理</b><br /><br />
                <hr />
                <form id="addGoodsForm" name="addGoodsForm" action="/ManagerCenter/AddVegtb" method="post">
                <table class="personMsgTable gray_border_table paddingStyle" width="670">
                    <tr>
                    <td>商品名：</td>
                    <td>
                        <input class="personMsgText" type="text" id="goods" name="goods" onblur="exist();"/>
                        <font color="red" id="error"></font><br/>
                         规范:名称/别名(规格).例如:豆仔/四季豆(400g/包)
                    </td>
                    </tr>
                    <tr>
                    <td>商品类别：</td>
                    <td>
                        <select id="category" name="category" class="select" >
                            <%if (Model != null)
                              { foreach (Category c in Model)
                                  {%>
                                 <option value="<%=c.CID %>"><%=c.CName%></option>
                            <%}
                              } %>
                        </select>
                    </td>
                    </tr>
                    <tr>
                    <td>拼音首字母：</td>
                    <td>
                        <!--<select id="keys" name="keys" class="select">-->
                        <%-- byte[] array = new byte[1];
                          for (byte i = 65; i < 91; i++)
                          { array[0]=(byte)(Convert.ToInt32(i)); --%>
                          <option value="<%--=Convert.ToString(System.Text.Encoding.ASCII.GetString(array))--%>"><%--=Convert.ToString(System.Text.Encoding.ASCII.GetString(array))--%></option>
                        <%--} --%>
                        <!--</select>-->
                        <select id="Select1" name="keys" class="select">
                        
                          <option value="A">A</option>
                        
                          <option value="B">B</option>
                        
                          <option value="C">C</option>
                        
                          <option value="D">D</option>
                        
                          <option value="E">E</option>
                        
                          <option value="F">F</option>
                        
                          <option value="G">G</option>
                        
                          <option value="H">H</option>
                        
                          <option value="I">I</option>
                        
                          <option value="J">J</option>
                        
                          <option value="K">K</option>
                        
                          <option value="L">L</option>
                        
                          <option value="M">M</option>
                        
                          <option value="N">N</option>
                        
                          <option value="O">O</option>
                        
                          <option value="P">P</option>
                        
                          <option value="Q">Q</option>
                        
                          <option value="R">R</option>
                        
                          <option value="S">S</option>
                        
                          <option value="T">T</option>
                        
                          <option value="U">U</option>
                        
                          <option value="V">V</option>
                        
                          <option value="W">W</option>
                        
                          <option value="X">X</option>
                        
                          <option value="Y">Y</option>
                        
                          <option value="Z">Z</option>
                        
                        </select>
                    </td>
                    </tr>
                    <tr>
                    <td>规格：</td>
                    <td><input class="personMsgText" type="text" id="specification" name="specification" value="1"/>说明：规格填10，即表示一箱10斤。默认为1</td>
                    </tr>
                    </table></form>
                    <div class="varietySecondP">
                        <input class="btnStyle" type="button" value="添加"  onclick="addVegtb();" />
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
