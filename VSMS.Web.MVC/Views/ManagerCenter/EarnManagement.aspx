<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.MVCModels" %>
<%@ Import Namespace="VSMS.Models.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	利润管理
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
     <script type="text/javascript" src="../../Scripts/main.js"></script>
<% EarnManagementModels MVCModel = ViewData["MvcModel"] as EarnManagementModels;
   List<ProfitMessageModels> profitMessage = ViewData["ProfitMessage"] as List<ProfitMessageModels>; %>
    <div class="vegetableManagePanel">
            <!--头部菜单导航ABC,DEF...-->
            <form method="get" action="/ManagerCenter/EarnManagement/">
            <p class="departmentSelect">
                <b>企业：</b>
                <select id="Enterprise" name="eid">
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
                <select id="Department" action="3" name="did">
                    <%foreach (Department department in MVCModel.CurrentDepartmentList)
                    { %>
                        <option value="<%=department.DID%>" 
                            <%if(department.DID == MVCModel.CurrentDepartmentID) Response.Write("selected=\"selected\"");%>>
                            <%=department.DName%>
                        </option>
                    <%} %>
                </select>
                <input class="btnSearch" type="submit"value="查询" />
            </p>
            </form>
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
            <ul class="menuContentEarnManagement" id="menu-1"><!--菜单详细内容-->
                <li>
                    <h3>A</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "A") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>B</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "B") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>C</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "C") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                    
                </ul>
                <!--DEF菜单-->
                <ul class="menuContentEarnManagement" id="menu-2" style="display:none;">
                <li>
                    <h3>D</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "D") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>E</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "E") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>F</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "F") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--GHI菜单-->
                <ul class="menuContentEarnManagement" id="menu-3" style="display:none;">
                <li>
                    <h3>G</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "G") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>H</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "H") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>I</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "I") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--JKL菜单-->
                <ul class="menuContentEarnManagement" id="menu-4" style="display:none;">
                <li>
                    <h3>J</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "J") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>K</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "K") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>L</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "L") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--MNO菜单-->
                <ul class="menuContentEarnManagement" id="menu-5" style="display:none;">
                <li>
                    <h3>M</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "M") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>N</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "N") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>O</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "O") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--PQR菜单-->
                <ul class="menuContentEarnManagement" id="menu-6" style="display:none;">
                <li>
                    <h3>P</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "P") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>Q</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "Q") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>R</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "R") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--STU菜单-->
                <ul class="menuContentEarnManagement" id="menu-7" style="display:none;">
                <li>
                    <h3>S</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "S") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>T</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "T") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>U</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "U") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--VWS菜单-->
                <ul class="menuContentEarnManagement" id="menu-8" style="display:none;">
                <li>
                    <h3>V</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "V") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>W</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "W") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>X</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "X") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
                <!--YZ菜单-->
                <ul class="menuContentEarnManagement" id="menu-9" style="display:none;">
                <li>
                    <h3>Y</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "Y") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                <li>
                    <h3>Z</h3>
                    
                    <ul class="vegetableManageItem"><!--字母分类子列表-->
                        <%foreach (ProfitMessageModels profitMsg in profitMessage)
                          {
                              if (profitMsg.Keys != "Z") continue;
                              {%>
                              
                        <li>
                            <span><%=profitMsg.VName%></span>
                            <input class="inputText" type="text" pid="<%=profitMsg.PID %>" value="<%=profitMsg.Profit %>"/>
                            <span id="saveProfit" class="saveProfit">保存</span>
                        </li>
                        <%}
                          }%>
                    </ul><br />
                    
                    
                </li>
                </ul>
    </div>

</asp:Content>
