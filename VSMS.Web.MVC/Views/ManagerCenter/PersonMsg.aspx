<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	个人信息管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%Admins admins = ViewData["Msg"] as Admins;%>
    <div class="personMsg">
                <b>修改个人信息</b>
                <hr />
                <form action="/ManagerCenter/Save" method="post" onsubmit="return validate();">
                    <table class="personMsgTable gray_border_table" width="600" border="1">
                          <tr>
                            <td>身份：</td>
                            <td>批发商管理员</td>
                            <td></td>
                          </tr>
                          <tr>
                            <td>用户名：</td>
                            <td><input type="text" value="<%=admins.LoginName %>" name="LoginName" id="LoginName"/></td>
                            <td id="validateUName"></td>
                          </tr>
                          <tr>
                            <td>所属公司：</td>
                            <td>中山市安健蔬菜流通中心</td>
                            <td></td>
                          </tr>
                          <tr>
                            <td>地址：</td>
                            <td><input class="personMsgTextLong" value="<%=admins.Addr %>" name="Address" type="text" id="Address"/></td>
                            <td id="validateAddr"></td>
                          </tr>
                          <tr>
                            <td>联系电话(固话)：</td>
                            <td><input class="personMsgText" value="<%=admins.Phone %>" name="PhoneNum" type="text" id="PhoneNum"/></td>
                            <td id="validatePhone"></td>
                          </tr>
                          <tr>
                            <td>联系电话（手机号码）：</td>
                            <td><input class="personMsgText" value="<%=admins.MobilePhone %>" name="MobilePhone" type="text" id="MobilePhone"/></td>
                            <td id="validateMobilePhone"></td>
                          </tr>
                          <tr>
                            <td>传真：</td>
                            <td><input class="personMsgText" value="<%=admins.Fax %>" name="Fax" type="text" id="Fax"/></td>
                            <td id="validateFax"></td>
                          </tr>
                          <tr>
                            <td>E-mail：</td>
                            <td><input class="personMsgText" value="<%=admins.Email %>" name="E-mail" type="text" id="Email"/></td>
                            <td id="validateEmail"></td>
                          </tr>
                          <tr>
                            <td>旧密码：</td>
                            <td><input class="personMsgText" name="OldPwd" type="password" id="OldPwd"/>(修改密码前，请输入旧密码)</td>
                            <td id="validateOldPwd"></td>
                          </tr>
                          <tr>
                            <td>新密码：</td>
                            <td><input class="personMsgText" name="NewPwd" type="password" id="NewPwd"/>(密码长度在6-12之间)</td>
                            <td id="validateNewPwd"></td>
                          </tr>
                          <tr>
                            <td>确认新密码：</td>
                            <td><input class="personMsgText" name="SureNewPwd" type="password" id="SureNewPwd"/>(确认你的新密码)</td>
                            <td id="validateNewSurePwd"></td>
                          </tr>
                     </table>
                     <div class="varietySecondP">
                            <input class="btnStyle" type="submit" value="保存修改"  />
                     </div>
                 </form>
            </div>
<script type="text/javascript" src="../../Scripts/main.js"></script>
</asp:Content>
