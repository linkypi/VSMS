<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" type="text/css" href="../../Content/main.css" />

<title>登录页</title>
</head>

<body >
	<!--top顶部状态栏
	<div class="top">
    	<div class="msgShow wrapWidth">
        	<span class="showHome">您好，欢迎来到<em>中山市安健（圣狮）蔬菜流通中心</em></span>
            <span class="showUser">欢迎你，******主管&nbsp;&nbsp;|&nbsp;&nbsp;<a>退出</a></span>
        </div>
    </div>-->
    
    <!--header头部-->
	<div class="headerLogin">
    	<div class="headerbg"><!--因为有两个背景图，所以有这两个层-->
            <!--头部的内容，包括logo、搜索、热线电话-->
            <div class="headerContent wrapWidth">
            	<div class="logo"><a></a></div>
                <div class="LoginTopTxt">
                	<b>用户登录主页</b>
                    <span>Login</span>
                </div>
                <div class="phone">
                	<b>如有问题请拨打热线电话:</b>
                    <span>0760&nbsp;-&nbsp;88301982</span>
                </div>
            </div>
            <div class="clear"></div>
            
    	</div>
    </div>
    
    <div class="clear"></div>
<!--content主体-->
    <div class="contentLogin wrapWidth">
    	<div class="loginbg1">
        	<div class="infotxt">
            	<table height="236px" width="650px">
                	<tr height="38px">
                        <td colspan="5"><strong>中山市安健蔬菜流通中心，用户享有以下服务：</strong></td>
                    </tr>
                    <tr height="30px">
                    	<td width="12px"></td>
                    	<td><p>如果您是批发商</p></td>
                        <td><p>如果您是客户主管</p></td>
                        <td><p>如果您是采购员</p></td>
                        <td><p>如果您是工厂管理员</p></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td><span>管理所有用户</span></td>
                        <td><span>管理各部门采购员</span></td>
                        <td><span>管理订单</span></td>
                        <td><span>管理库存</span></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td><span>审核订单</span></td>
                        <td><span>查看订单</span></td>
                        <td><span>下订单</span></td>
                        <td><span>审核订单价格</span></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td><span>管理用户信息</span></td>
                        <td><span>管理采购员信息</span></td>
                        <td><span>管理个人信息</span></td>
                        <td><span>管理工厂信息</span></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td><span>查看库存</span></td>
                        <td><span>查看订单统计情况</span></td>
                        <td><span>管理常用列表</span></td>
                        <td><span>打印订单</span></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr height="25px;">
                    	<td width="12px"></td>
                    	<td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="loginbg2">  
                <form id="form1"  method="post" >
            	<table width="300px">
                	<tr >
                    	<td colspan="2">
                            <table height="75px">
                            	<tr>
                                	<td width="60px"></td>
                                    <td width="230px">
                                    	<strong>用户登陆</strong>
                                    </td>
                                </tr>
                            </table>	
                        </td>
                    </tr>
                  
                    <tr height="42px">
                    	<td width="84" ><b>用户名:</b></td>
                        <td width="216"><input type="text" id="loginName" name="loginName" class="loginTxt" value="<%=ViewData["LoginName"] %>" /></td>
                    </tr>
                    <tr height="42px">
                    	<td align="right" height="40px"><b>密&nbsp;&nbsp;&nbsp;&nbsp;码：</b></td>
                        <td><input type="password" id="loginPwd" name="loginPwd" class="loginTxt" value="<%=ViewData["pwd"] %>" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                        	<!--
                            <table height="30px">
                            	<tr>
                                	<td><input type="radio" id="buyer" runat="server"  name="identify" value="1" onclick="selectRole()" /></td>
                                    <td><span><label for="buyer">采购员</label></span>&nbsp;</td>
                                    <td><input type="radio" id="wholeSaler" runat="server"  name="identify" value="2" onclick="selectRole()" /></td>
                                    <td><span><label for="wholeSaler">批发商</label></span>&nbsp;</td>
                                    <td><input type="radio" id="factory" runat="server"  name="identify" value="3 " onclick="selectRole()"/></td>
                                    <td><span><label for="factory">工厂管理员</label></span>&nbsp;</td>
                                    <td><input type="radio" id="buyManager" runat="server" name="identify"  value="4" onclick="selectRole()" /></td>
                                    <td><span><label for="buyManager">客户主管</label></span><input type="hidden" runat="server" id="role" /></td>
                                </tr>
                            </table>
                            -->
                        </td>
                    </tr>
                    <tr >
                    	<td></td>
                        <td>
                        	<table height="30px">
                            	<tr>
                                	<td><input type="checkbox" name="checkbox" <%=ViewData["checkbox"] %>/>
                                     </td>
                                    <td>&nbsp;&nbsp;<span>记住密码</span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                    	<td ></td>
                        <td height="40px">
                       
                        <input type="submit" id="loginBTN" class="loginBTN"  value="" />
                        </td>
                    </tr>
                   
                </table> </form>
            </div>
        </div>
    </div>
    
    <!--line分隔线   2  -->
    <hr class="line" />
    
    <!--footer页脚-->
    <div class="footer wrapWidth" >
    	<div class="about">
        	<a>关于我们</a>|
            <a>广告服务</a>|
            <a>供应商服务</a>|
            <a>团购服务</a>|
            <a>诚聘英才</a>|
            <a>法律声明</a>
        </div>
        <div class="about">
        	<font>客服电话：0760-88301982</font>
        	<font>手机：15017338764</font>
        	<font>E-mail：zsanjian@163.com</font>
        	<font>地址：中山市沙溪圣狮松利基</font>
        </div>
        <div class="about">
        	<font>版权所有&copy;2012************</font>
        	<font>技术支持：xphp办公室</font>
        	<font>粤ICP备 ************</font>
        </div>
    </div>
    
</body>
</html>
