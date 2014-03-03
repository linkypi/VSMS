<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Masters/ManagerCenter.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="VSMS.Models.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	添加&删除蔬菜
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery-1.7.2.min.js"></script>
<script type="text/javascript" src="../../Scripts/main.js"></script>
        <% Dictionary<string, object> vdic = ViewData["Vegetable"] as Dictionary<string, object>;
           string MenuTab = ViewData["MenuTab"].ToString();
        %>
    <div class="vegetableManagePanel">
        <!--头部菜单导航ABC,DEF...-->
        
        <ul class="menuNav">
            <li id="tab-1" <%if(MenuTab=="1"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>A</li><li>B</li><li>C</li></ul>
            </li>
            <li id="tab-2" <%if(MenuTab=="2"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>D</li><li>E</li><li>F</li></ul>
            </li>
            <li id="tab-3" <%if(MenuTab=="3"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>G</li><li>H</li><li>I</li></ul>
            </li>
            <li id="tab-4" <%if(MenuTab=="4"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>J</li><li>K</li><li>L</li></ul>
            </li>
            <li id="tab-5" <%if(MenuTab=="5"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>M</li><li>N</li><li>O</li></ul>
            </li>
            <li id="tab-6" <%if(MenuTab=="6"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>P</li><li>Q</li><li>R</li></ul>
            </li>
            <li id="tab-7" <%if(MenuTab=="7"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>S</li><li>T</li><li>U</li></ul>
            </li>
            <li id="tab-8" <%if(MenuTab=="8"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>V</li><li>W</li><li>X</li></ul>
            </li>
            <li id="tab-9" <%if(MenuTab=="9"){%> style="background-color:#FFF;"<%} %>>
                <ul><li>Y</li><li>Z</li></ul>
            </li>
        </ul>
        <ul class="menuContentDeleteAndRestore" id="menu-1" <%if(MenuTab=="1"){%>style="display:block;" <%}else{%> style="display:none;"<%} %>><!--菜单详细内容-->
        <% if (vdic.ContainsKey("A"))
           {
               List<Vegetable> listA = vdic["A"] as List<Vegetable>;
               int countA = listA.FindAll(v => v.Keys == "A").Count;
               int countDelA = listA.FindAll(v => v.Deleted == true).Count;
               int countUnDelA = listA.FindAll(v => v.Deleted == false).Count;
               if (countA != 0)
               {
        %>
            <li><!--字母分类列表A-->
                <h3>A&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3>
                <% if (countUnDelA != 0)
                   { %>
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <% 
                    foreach (Vegetable veg in listA)
                    {
                        if ((veg.Deleted) == false)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=1">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1">修改</a>
                            </li>
                        <%}
                    }%>
                        
                </ul>
                <%}%>
                <%if (countDelA != 0)
                    {%>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <% 
                    foreach (Vegetable veg in listA)
                    {
                        if ((veg.Deleted) == true)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=1">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1" >修改</a>
                            </li>
                        <%}
                    }
                    %>
                        
                </ul>
                <%} %>
            </li>
            <%}
            }%>
            <%
            if (vdic.ContainsKey("B"))
            {
                List<Vegetable> listB = vdic["B"] as List<Vegetable>;
                int countB = listB.FindAll(v => v.Keys == "B").Count;
                int countDelB = listB.FindAll(v => v.Deleted == true).Count;
                int countUnDelB = listB.FindAll(v => v.Deleted == false).Count;
                if (countB != 0)
                {
           %>
            <li><!--字母分类列表B-->
                <h3>B&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelB != 0)
                   { %>       
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listB)
                    {
                        if((veg.Deleted) == false)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=1">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelB != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listB)
                    {
                        if ((veg.Deleted) == true)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=1">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul> 
                <%} %>       
            </li> 
            <%}
            }%>
            <%
            if (vdic.ContainsKey("C"))
            {
                List<Vegetable> listC = vdic["C"] as List<Vegetable>;
                int countC = listC.FindAll(v => v.Keys == "C").Count;
                int countDelC = listC.FindAll(v => v.Deleted == true).Count;
                int countUnDelC = listC.FindAll(v => v.Deleted == false).Count;
                if (countC != 0)
                {
           %>
            <li><!--字母分类列表C-->
                <h3>C&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelC != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listC)
                    {
                        if ((veg.Deleted) == false)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=1">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelC != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listC)
                    {
                        if ((veg.Deleted) == true)
                        {%>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=1">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="1">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            }%>
            </ul>
            <!--DEF菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-2" <%if(MenuTab!="2"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("D"))
            {
                List<Vegetable> listD = vdic["D"] as List<Vegetable>;
                int countD = listD.FindAll(v => v.Keys == "D").Count;
                int countDelD = listD.FindAll(v => v.Deleted == true).Count;
                int countUnDelD = listD.FindAll(v => v.Deleted == false).Count;
                if (countD != 0)
                { 
           %>
            <li><!--字母分类列表D-->
                <h3>D&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelD != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listD)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=2">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelD != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listD)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=2">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul> 
                <%} %>
            </li>
            <%}
            } %>
            <% 
            if (vdic.ContainsKey("E"))
            {
                List<Vegetable> listE = vdic["E"] as List<Vegetable>;
                int countE = listE.FindAll(v => v.Keys == "E").Count;
                int countDelE = listE.FindAll(v => v.Deleted == true).Count;
                int countUnDelE = listE.FindAll(v => v.Deleted == false).Count;
                if (countE != 0)
                {
           %>
            <li><!--字母分类列表E-->
                <h3>E&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelE != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子 列表-->
                <%
                    foreach (Vegetable veg in listE)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=2">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelE != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listE)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=2">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul> 
                <%} %>
            </li>
            <%}
            }%>
            <% if (vdic.ContainsKey("F"))
               {
                   List<Vegetable> listF = vdic["F"] as List<Vegetable>;
                   int countF = listF.FindAll(v => v.Keys == "F").Count;
                   int countDelF = listF.FindAll(v => v.Deleted == true).Count;
                   int countUnDelF = listF.FindAll(v => v.Deleted == false).Count;
                   if (countF != 0)
                   {
           %>
            <li><!--字母分类列表F-->
                <h3>F&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelF != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listF)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=2">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelF != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listF)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=2">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="2">修改</a>
                            </li>
                        <%}
                    }
                     %>
                </ul> 
                <%} %>
            </li>
            <%}
               } %>
            </ul>
            <!--GHI菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-3" <%if(MenuTab=="3"){%>style="display:block;" <%}else{%> style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("G"))
            {
                List<Vegetable> listG = vdic["G"] as List<Vegetable>;
                int countG = listG.FindAll(v => v.Keys == "G").Count;
                int countDelG = listG.FindAll(v => v.Deleted == true).Count;
                int countUnDelG = listG.FindAll(v => v.Deleted == false).Count;
                if (countG != 0)
                {
           %>
            <li><!--字母分类列表G-->
                <h3>G&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelG != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listG)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=3">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelG != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listG)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=3">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul> 
                <%} %>
            </li>
            <%}
            }%>
            <%if (vdic.ContainsKey("H"))
              {
                  List<Vegetable> listH = vdic["H"] as List<Vegetable>;
                  int countH = listH.FindAll(v => v.Keys == "H").Count;
                  int countDelH = listH.FindAll(v => v.Deleted == true).Count;
                  int countUnDelH = listH.FindAll(v => v.Deleted == false).Count;
                  if (countH != 0)
                  {
           %>
            <li><!--字母分类列表H-->
                <h3>H&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                 <% if (countUnDelH != 0)
                    { %>          
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listH)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=3">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                 <% if (countDelH != 0)
                    { %>  
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                        foreach (Vegetable veg in listH)
                        {
                            if ((veg.Deleted) == true)
                            { %>
                                <li>
                                    <span><%=veg.VName%></span>&nbsp;
                                    <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=3">恢复</a>
                                    <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                                </li>
                            <%}
                        }
                      %>
                </ul> 
                <%} %>
            </li>
            <%}
              } %>
            <%
            if (vdic.ContainsKey("I"))
            {
                List<Vegetable> listI = vdic["I"] as List<Vegetable>;
                int countI = listI.FindAll(v => v.Keys == "I").Count;
                int countDelI = listI.FindAll(v => v.Deleted == true).Count;
                int countUnDelI = listI.FindAll(v => v.Deleted == false).Count;

                if (countI != 0)
                {  
           %>
            <li><!--字母分类列表I-->
                <h3>I&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                 <% if (countUnDelI != 0)
                    { %>       
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listI)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=3">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                 <% if (countDelI != 0)
                    { %> 
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listI)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                    <li>
                        <span><%=veg.VName%></span>&nbsp;
                        <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=3">恢复</a>
                        <a class="alterVegetable" vid="<%=veg.VID %>" tab="3">修改</a>
                    </li>
                        <%}
                    }
                      
                   %>
                </ul> 
                <%} %>
            </li>
            <%}
            } %>
            </ul>
            <!--JKL菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-4" <%if(MenuTab!="4"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("J"))
            {
                List<Vegetable> listJ = vdic["J"] as List<Vegetable>;
                int countJ = listJ.FindAll(v => v.Keys == "J").Count;
                int countDelJ = listJ.FindAll(v => v.Deleted == true).Count;
                int countUnDelJ = listJ.FindAll(v => v.Deleted == false).Count;

                if (countJ != 0)
                {  
           %>
            <li><!--字母分类列表J-->
                <h3>J&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelJ != 0)
                   { %>         
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listJ)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=4">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelJ != 0)
                   { %> 
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listJ)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li><span><%=veg.VName%></span>&nbsp;
                            <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=4">恢复</a>
                            <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a></li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("K"))
            {
                List<Vegetable> listK = vdic["K"] as List<Vegetable>;
                int countK = listK.FindAll(v => v.Keys == "K").Count;
                int countDelK = listK.FindAll(v => v.Deleted == true).Count;
                int countUnDelK = listK.FindAll(v => v.Deleted == false).Count;

                if (countK != 0)
                {  
           %>
            <li><!--字母分类列表K-->
                <h3>K&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelK != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listK)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                    <li>
                        <span><%=veg.VName%></span>&nbsp;
                        <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=4">删除</a>
                        <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a>
                    </li>
                        <%}
                    }
                 %>       
                </ul>
                <%} %>
                <% if (countDelK != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listK)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                    <li>
                        <span><%=veg.VName%></span>&nbsp;
                        <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=4">恢复</a>
                        <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a>
                    </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("L"))
            {
                List<Vegetable> listL = vdic["L"] as List<Vegetable>;
                int countL = listL.FindAll(v => v.Keys == "L").Count;
                int countDelL = listL.FindAll(v => v.Deleted == true).Count;
                int countUnDelL = listL.FindAll(v => v.Deleted == false).Count;

                if (countL != 0)
                {  
           %>
            <li><!--字母分类列表L-->
                <h3>L&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelL != 0)
                   { %>         
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listL)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=4">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelL != 0)
                   { %> 
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listL)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=4">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="4">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            </ul>
            <!--MNO菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-5" <%if(MenuTab!="5"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("M"))
            {
                List<Vegetable> listM = vdic["M"] as List<Vegetable>;
                int countM = listM.FindAll(v => v.Keys == "M").Count;
                int countDelM = listM.FindAll(v => v.Deleted == true).Count;
                int countUnDelM = listM.FindAll(v => v.Deleted == false).Count;

                if (countM != 0)
                {  
           %>
            <li><!--字母分类列表M-->
                <h3>M&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelM != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listM)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=5">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelM != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listM)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=5">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("N"))
            {
                List<Vegetable> listN = vdic["N"] as List<Vegetable>;
                int countN = listN.FindAll(v => v.Keys == "N").Count;
                int countDelN = listN.FindAll(v => v.Deleted == true).Count;
                int countUnDelN = listN.FindAll(v => v.Deleted == false).Count;

                if (countN != 0)
                {  
           %>
            <li><!--字母分类列表N-->
                <h3>N&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelN != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listN)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=5">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelN != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listN)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=5">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("O"))
            {
                List<Vegetable> listO = vdic["O"] as List<Vegetable>;
                int countO = listO.FindAll(v => v.Keys == "O").Count;
                int countDelO = listO.FindAll(v => v.Deleted == true).Count;
                int countUnDelO = listO.FindAll(v => v.Deleted == false).Count;

                if (countO != 0)
                {  
           %>
            <li><!--字母分类列表O-->
                <h3>O&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelO != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listO)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=5">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelO != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listO)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=5">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="5">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>

            </ul>
            <!--PQR菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-6" <%if(MenuTab!="6"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("P"))
            {
                List<Vegetable> listP = vdic["P"] as List<Vegetable>;
                int countP = listP.FindAll(v => v.Keys == "P").Count;
                int countDelP = listP.FindAll(v => v.Deleted == true).Count;
                int countUnDelP = listP.FindAll(v => v.Deleted == false).Count;

                if (countP != 0)
                {  
           %>
            <li><!--字母分类列表P-->
                <h3>P&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelP != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listP)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=6">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelP != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listP)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=6">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul> 
                <%} %>
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("Q"))
            {
                List<Vegetable> listQ = vdic["Q"] as List<Vegetable>;
                int countQ = listQ.FindAll(v => v.Keys == "Q").Count;
                int countDelQ = listQ.FindAll(v => v.Deleted == true).Count;
                int countUnDelQ = listQ.FindAll(v => v.Deleted == false).Count;

                if (countQ != 0)
                {  
           %>
            <li><!--字母分类列表Q-->
                <h3>Q&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelQ != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listQ)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=6">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelQ != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listQ)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=6">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("R"))
            {
                List<Vegetable> listR = vdic["R"] as List<Vegetable>;
                int countR = listR.FindAll(v => v.Keys == "R").Count;
                int countDelR = listR.FindAll(v => v.Deleted == true).Count;
                int countUnDelR = listR.FindAll(v => v.Deleted == false).Count;

                if (countR != 0)
                {  
           %>

            <li><!--字母分类列表R-->
                <h3>R&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelR != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listR)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=6">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelR != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listR)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=6">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="6">修改</a>
                            </li>
                        <%}
                    }
                     %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            </ul>
            <!--STU菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-7" <%if(MenuTab!="7"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("S"))
            {
                List<Vegetable> listS = vdic["S"] as List<Vegetable>;
                int countS = listS.FindAll(v => v.Keys == "S").Count;
                int countDelS = listS.FindAll(v => v.Deleted == true).Count;
                int countUnDelS = listS.FindAll(v => v.Deleted == false).Count;

                if (countS != 0)
                {  
           %>
            <li><!--字母分类列表S-->
                <h3>S&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelS != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listS)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=7">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelS != 0)
                   { %>

                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listS)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=7">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("T"))
            {
                List<Vegetable> listT = vdic["T"] as List<Vegetable>;
                int countT = listT.FindAll(v => v.Keys == "T").Count;
                int countDelT = listT.FindAll(v => v.Deleted == true).Count;
                int countUnDelT = listT.FindAll(v => v.Deleted == false).Count;

                if (countT != 0)
                {  
           %>
            <li><!--字母分类列表T-->
                <h3>T&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelT != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listT)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=7">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelT != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listT)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=7">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("U"))
            {
                List<Vegetable> listU = vdic["U"] as List<Vegetable>;
                int countU = listU.FindAll(v => v.Keys == "U").Count;
                int countDelU = listU.FindAll(v => v.Deleted == true).Count;
                int countUnDelU = listU.FindAll(v => v.Deleted == false).Count;

                if (countU != 0)
                {  
           %>
            <li><!--字母分类列表U-->
                <h3>U&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelU != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listU)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=7">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelU != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listU)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=7">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="7">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul> 
                <%} %>
            </li>
            <%}
            } %>
            </ul>
            <!--VWX菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-8" <%if(MenuTab!="8"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("V"))
            {
                List<Vegetable> listV = vdic["V"] as List<Vegetable>;
                int countV = listV.FindAll(v => v.Keys == "V").Count;
                int countDelV = listV.FindAll(v => v.Deleted == true).Count;
                int countUnDelV = listV.FindAll(v => v.Deleted == false).Count;

                if (countV != 0)
                {  
           %>
            <li><!--字母分类列表V-->
                <h3>V&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelV != 0)
                   { %>         
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listV)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=8">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelV != 0)
                   { %> 
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listV)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=8">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("W"))
            {
                List<Vegetable> listW = vdic["W"] as List<Vegetable>;
                int countW = listW.FindAll(v => v.Keys == "W").Count;
                int countDelW = listW.FindAll(v => v.Deleted == true).Count;
                int countUnDelW = listW.FindAll(v => v.Deleted == false).Count;

                if (countW != 0)
                {  
           %>
            <li><!--字母分类列表W-->
                <h3>W&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelW != 0)
                   { %>         
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listW)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=8">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelW != 0)
                   { %> 
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listW)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=8">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("X"))
            {
                List<Vegetable> listX = vdic["X"] as List<Vegetable>;
                int countX = listX.FindAll(v => v.Keys == "X").Count;
                int countDelX = listX.FindAll(v => v.Deleted == true).Count;
                int countUnDelX = listX.FindAll(v => v.Deleted == false).Count;

                if (countX != 0)
                {  
           %>
            <li><!--字母分类列表X-->
                <h3>X&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelX != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listX)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=8">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelX != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                    foreach (Vegetable veg in listX)
                    {
                        if ((veg.Deleted) == true)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=8">恢复</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="8">修改</a>
                            </li>
                        <%}
                    }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            </ul>
            <!--YZ菜单-->
            <ul class="menuContentDeleteAndRestore" id="menu-9" <%if(MenuTab!="9"){%>style="display:none;"<%} %>>
            <%
            if (vdic.ContainsKey("Y"))
            {
                List<Vegetable> listY = vdic["Y"] as List<Vegetable>;
                int countY = listY.FindAll(v => v.Keys == "Y").Count;
                int countDelY = listY.FindAll(v => v.Deleted == true).Count;
                int countUnDelY = listY.FindAll(v => v.Deleted == false).Count;

                if (countY != 0)
                {  
           %>
            <li><!--字母分类列表Y-->
                <h3>Y&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelY != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listY)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=9">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="9">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelY != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                foreach (Vegetable veg in listY)
                {
                    if ((veg.Deleted) == true)
                    { %>
                        <li>
                            <span><%=veg.VName%></span>&nbsp;
                            <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=9">恢复</a>
                            <a class="alterVegetable" vid="<%=veg.VID %>" tab="9">修改</a>
                        </li>
                    <%}
                }
                      %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            <%
            if (vdic.ContainsKey("Z"))
            {
                List<Vegetable> listZ = vdic["Z"] as List<Vegetable>;
                int countZ = listZ.FindAll(v => v.Keys == "Z").Count;
                int countDelZ = listZ.FindAll(v => v.Deleted == true).Count;
                int countUnDelZ = listZ.FindAll(v => v.Deleted == false).Count;

                if (countZ != 0)
                {  
           %>
            <li><!--字母分类列表Z-->
                <h3>Z&nbsp;&nbsp;&nbsp;<a href="/ManagerCenter/AddVegetable">+添加新品种</a></h3><br/>
                <% if (countUnDelZ != 0)
                   { %>        
                <b class="menuOwnVegColor">已有蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                <%
                    foreach (Vegetable veg in listZ)
                    {
                        if ((veg.Deleted) == false)
                        { %>
                            <li>
                                <span><%=veg.VName%></span>&nbsp;
                                <a href="/ManagerCenter/Delete/?vid=<%=veg.VID %>&menuTab=9">删除</a>
                                <a class="alterVegetable" vid="<%=veg.VID %>" tab="9">修改</a>
                            </li>
                        <%}
                    }
                  %>       
                </ul>
                <%} %>
                <% if (countDelZ != 0)
                   { %>
                <b class="menuDeleteVegColor">已删除蔬菜</b><hr/>
                <ul class="vegetableManageItem"><!--字母分类子列表-->
                    <%
                        foreach (Vegetable veg in listZ)
                        {
                            if ((veg.Deleted) == true)
                            { %>
                                <li>
                                    <span><%=veg.VName%></span>&nbsp;
                                    <a href="/ManagerCenter/Restore/?vid=<%=veg.VID %>&menuTab=9">恢复</a>
                                    <a class="alterVegetable" vid="<%=veg.VID %>" tab="9">修改</a>
                                </li>
                            <%}
                        }
                    %>
                </ul>
                <%} %> 
            </li>
            <%}
            } %>
            </ul>
    </div>

</asp:Content>
