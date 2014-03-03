<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.Model"%>
<% Vegetable vege = ViewData["vegetable"] as Vegetable;
   List<Category> categoriesList = ViewData["categoriesList"] as List<Category>;
    %>
<table class="vegetableManger" width="380">
                    <tr>
                    <td>商品名：</td>
                    <td>
                        <input class="personMsgText" type="text" id="goods" name="goods" vid="<%=vege.VID %>" value="<%=vege.VName %>" onblur="exist();"/>
                        <font color="red" id="error"></font><br/>
                         <p>规范:名称/别名(规格).例如:豆仔/四季豆(400g/包)</p><br />
                    </td>
                    </tr>
                    <tr>
                    <td>商品类别：</td>
                    <td>
                        <select id="category" name="category" class="select" >
                            <%if (categoriesList != null)
                              {
                                  foreach (Category c in categoriesList)
                                  {%>
                                 <option value="<%=c.CID %>" <%if(vege.CID == c.CID){ %>selected="selected"<%} %>><%=c.CName%></option>
                            <%}
                              } %>
                        </select>
                    </td>
                    </tr>
                    <tr>
                    <td>拼音首字母：</td>
                    <td>
                        <select id="keys" name="keys" class="select">
                        <% byte[] array = new byte[1];
                          for (byte i = 65; i < 91; i++)
                          { array[0]=(byte)(Convert.ToInt32(i)); %>
                          <option value="<%=Convert.ToString(System.Text.Encoding.ASCII.GetString(array))%>" <%if((new System.Text.ASCIIEncoding().GetBytes(vege.Keys)[0])==i){ %>selected="selected"<%} %>><%=Convert.ToString(System.Text.Encoding.ASCII.GetString(array))%></option>
                        <%} %>
                        </select>
                    </td>
                    </tr>
                    <tr>
                    <td>规格：</td>
                    <td><input class="personMsgText" type="text" id="specification" name="specification" value="<%=vege.Specification %>"/>
                            <br /><p>说明：规格填10，即表示一箱10斤。默认为1</p></td>
                    </tr>
                    </table>
                    <p style="text-align:right"><input class="btnStyle" id="submitAlterVegetable" type="button" value="提交" />&nbsp;&nbsp;&nbsp;</P>