 
            /////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////       公共方法        /////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////////

            /*验证0<num<=1的数 */
            function vldPct(str) {
                var reg = /^(?:0\.\d+|[01](?:\.0)?)$/; return reg.test(str);
            }

            /*验证浮点数  正浮点数*/
            function vldFloat(str) {
                var re = new RegExp(/^(0|[1-9]\d*|(0|[1-9]\d*)\.\d*[1-9])$/);        
                /// 正浮点数^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$/);
                  return  re.test(str);
            }
            /*验证邮箱*/
            function vldEmail(str) {
                var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
                return reg.test(str);
            }
            /*校验普通电话、传真号码：可以“+”开头，除数字外，可含有“-”*/ 
            function vldPhone(str)
            { var reg = /^[+]{0,1}(\d){1,3}[ ]?([-]?((\d)|[ ]){1,12})+$/; return reg.test(str); }

            /*验证手机号  由11位数字组成  1开头 接着第二位数是3、4、5或者8，这个可以自行添加*/
            function vldMobilePhone(str)
            { var reg = /^1[3|4|5|8][0-9]\d{4,8}$/; return reg.test(str); } ///^1[3|4|5|8][0-9]\d{4,8}$/;

            /*验证正整数   全部由数字组成*/
            function vldNum(str) {
                var reg = /^[0-9]d*$/; return reg.test(str);//^[0-9]|[1-9][0-9]*$
            }

       /*下一页*/
       function btnNext(current,total,url)
       {
            current ++;
            if (current > total) { current = total; }
            window.location.href =url+ current;
       }
       /*上一页*/
       function btnPrevious(current,url)
       {
           current--;
           if (current <= 0) { current = 1; }//"/OrderManager/InputPrice/"
            window.location.href =  url + current;
       }
       /*打印订单*/
       function printOrder(id) {
           $("#"+id).hide();
           window.print();
           $("#" + id).show(1000);
       }

       /*计算总额*/
       function calculate(id) {
           var price = $("#input" + id).val().trim();
           var count = $("#span" + id).text();
           var total = (count * price).toString();
           var index = total.lastIndexOf(".");
           //保留两位小数
           if (index > 0) {
               total = total.substr(0, index + 3);
           }

           $("#total" + id).html(total);
       }

        /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////       私有方法        /////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////
       function ShowObjProperty(Obj) {
           var PropertyList = '';
           var PropertyCount = 0;
           for (i in Obj) {
               if (Obj.i != null)
                   PropertyList = PropertyList + i + '属性：' + Obj.i + '\r\n';
               else
                   PropertyList = PropertyList + i + '方法\r\n';
           }
           alert(PropertyList);
       }
       //****************************************************************************************//
       //-------------------------------------订单处理母版页-----------------------------------//
       //****************************************************************************************//
       /*显示或隐藏*/
       function masterShowHide(id) {
           if ($("#" + id).is(":hidden")) {
               $("#" + id).show('fast'); return;
           }
           $("#" + id).hide('fast');
       }

       //****************************************************************************************//
       //--------------------------------------- 送货单打印页面--------------------------------//
       //****************************************************************************************//

       $(document).ready(function () {
           $("#modifydn").bind("click", mofigydn);
       });

       function  printDN(id){
            $("#modifydn").hide();
            printOrder(id);
            $("#modifydn").attr({ src: "../../../Content/Image/pagesImg/modifydn.png", title: "修改" });
            $("#modifydn").show(500);
       }
       /*保存送货单*/
       function savedn()
       {
           $('#dnForm').ajaxSubmit({
               type: "post",
               url: "/OrderManager/UpdateDeliveryNote/?oid=" + $("#oid").val(),
               dataType: "text",
               success: function (data) {
                   $("td[id^='td']").each(
                       function (i, elem) {
                           var vid = $(this).attr("id").toString().substring(2, $(this).attr("id").toString().length);
                           var price = $("#input" + vid).val();
                           $("#input" + vid).remove();
                           $(this).append('<span  id="sp' + vid + '">' + price + '</span>');
                       });

                 $("#modifydn").unbind("click");
                 $("#modifydn").bind("click", modifydn);
                 $("#modifydn").attr({ src: "../../../Content/Image/pagesImg/modifydn.png", title: "修改" });
               }
           });
       }
       /*修改送货单*/
       function mofigydn() {
          // 
           $("td[id^='td']").each(
           function (i, elem) {
               var vid = $(this).attr("id").toString().substring(2, $(this).attr("id").toString().length);
               var price = $("#sp" + vid).text();
               $("#sp" + vid).remove();
               var js = '<input type="text" style="width:80px;"  id="input' + vid + '" name="input' + vid + '" value="' + price + '"  onkeyup="calculate(' + vid + ')" />';
               $(this).append(js);
           });
           $("#modifydn").unbind("click");
           $("#modifydn").bind("click", savedn);
           $("#modifydn").attr({ src: "../../../Content/Image/pagesImg/save.png", title: "保存" });
       }
       


       //****************************************************************************************//
       //---------------------------------------录入成本----------------------------------------//
       //****************************************************************************************//
       var ippFlag = true;
       /*录入成本*/
       function inputPrice() {
           $("input[name^='input']").each(function (i, elem) {
               /*检测是否为空*/
               if ($(this).val().trim() == "") {
                   ippFlag = false;
                   $(this).attr({ style: "border: 1px solid red;width:80px;" });
                   alert("数据不能为空！");
                   return false;
               }
               if (!vldFloat($(this).val().trim())) {
                   //无效数字！
                   $(this).attr({ style: "border:1px solid red;width:80px;" });
                   ippFlag = false;
                   return false;
               }
                $(this).attr({ style: "width:80px;" });
          });
          if (ippFlag) {
              $("#InputPriceForm").submit(); return;
          }
      }
        /*计算成本*/
        function calcCost(id) {
            $("#input" + id).attr({ style: "width:80px;" });
            var input = $("#input" + id).val().trim();
            if (input == "") return;
        
            if (!vldFloat(input)) {
                alert("请输入有效数字！");
                $("#input" + id).val("");
                $("#input" + id).position(0);
                typeInFlag = false;
                return;
            }
            calculate(id);
        }
       //****************************************************************************************//
       //-------------------------------------录入实收量--------------------------------------//
       //****************************************************************************************//
       var typeInFlag = true;
       /*录入实收量后计算总额*/
       function calcTotal(vid) {
           var inputObj = $("#input" + vid);
           var input = inputObj.val();
           if (input == "") return;
           typeInFlag = true;
           if (!vldFloat(input)) {
               alert("请输入有效数字！");
               inputObj.val("");
               inputObj.position(0);
               typeInFlag = false;
               return;
           }
           if ( parseFloat(input)  > parseFloat($("#oc" + vid).text())*2 ) {
               alert("您录入的实收量已经超出最大订购量！"); 
               typeInFlag = false;
                return;
           }
           calculate(vid);
       }
       /*录入实收量*/
       function inputReal() {
           $("input[name^='input']").each(function (i, elem) {
               if ($(this).val().trim() == "") {
                   typeInFlag = false;
                   $(this).attr({ style: "border: 1px solid red;width:80px;" });
                   return false;
               }
            
               $(this).attr({ style: "width:80px;" });
           });
           if (typeInFlag) {
               $("#InputRealCountForm").submit();
               return;
           }
           alert("数据不为空！");
       }
      

       //****************************************************************************************//
       //-------------------------------------企业管理页面--------------------------------------//
       //****************************************************************************************//

       $(document).ready(function () {
           epblur();
       });
       /* 删除企业 */
       function delEp(eid) {
           if (!confirm('确认删除吗？')) return;
           $.ajax({
               type: "get",
               url: "/ManagerCenter/DeleteHotel/?eid=" + eid,
               dataType: "text",
               success: function (data) {
                   if (data == "success") {
                       $("#row" + eid).remove();
                       alert("删除成功！"); return;
                   }
                   alert("删除失败");
               }
           });
       }
       /*屏蔽或恢复企业*/
       function setDelState(eid) {
           $.ajax({
               type: "get",
               url: "/ManagerCenter/SetHotelDelState/?eid=" + eid,
               dataType: "text",
               success: function (data) {
                   if (data == "faile") return;
                   if ($("#banep" + eid).attr("alt").trim() == "激活") {
                       $("#banep" + eid).attr({ src: "../../../Content/Image/pagesImg/forbidden.png", title: "禁用" });
                       return;
                    }
                   $("#banep" + eid).attr({ src: "../../../Content/Image/pagesImg/activate.png", title: "激活" });
               }
           });
       }
       /*修改按钮*/
       function update(eid) {
           epunblur();           $("#operate").val("update"); $("#eid").val(eid);
           $("#btnOpr").val("确认修改"); $("#navType").text("修改企业信息");
           $.getJSON("/ManagerCenter/GetEnterprise/?eid=" + eid, function (Enterprise) {
               $("#ename").val(Enterprise.EName); $("#addr").val(Enterprise.Addr); $("#phone").val(Enterprise.MobilePhone);
               $("#fax").val(Enterprise.Fax);  $("#email").val(Enterprise.Email); //$("#discount").val(Enterprise.DisCount);
           });
       }
      
       /*操作按钮  更新或添加企业*/
       function btnOperate() {
           if ($("#operate").val() == "add")
           { if (!vldEmpty()) return; }

           $('#addEpForm').ajaxSubmit({
               type: "post",
               url: "/ManagerCenter/AddOrUpdateHotel",
               dataType: "text",
               success: function (data) {
                   if ($("#operate").val() == "add") {
                       if (data == -1) { alert("添加失败！"); return; }
                       /*添加新节点*/
                       var js = "<tr id='row'" + data + "><td>" + $("#ename").val() + "</td>";
                       js += "<td><a onclick='delEp(" + data + ")'>删除</a>&nbsp;&nbsp;";
                       js += "<a onclick='update(" + data + ")'>修改</a>&nbsp;&nbsp;";
                       js += "<a id='ban" + data + "'  onclick='setDelState(" + data + ")'>屏蔽</a>";
                       js += "</td></tr>";
                       $("#tabeplist").append(js); alert("添加成功！"); 
                   }
                   else { alert(data); }
               }
           });
       }

       /*空值验证*/
       function vldEmpty() {
           if ($("#ename").val() == "") { $("#err").text("企业名称不为空"); return false; } 
           if ($("#addr").val() == "") { alert("地址不为空"); return false; }
           if ($("#phone").val() == "") { alert("联系电话不为空"); return false; }
           if ($("#fax").val() == "") { alert("传真不为空"); return false; }
           if ($("#discount").val() == "") { alert("返点不为空"); return false; }
           if ($("#email").val() == "") { alert("邮箱不为空"); return false; }
           return true;
       }

       /*添加企业按钮*/
       function btnAddEp() {
           epblur();
           $("#operate").val("add"); $("#btnOpr").val("确认添加");
           $("#navType").text("添加新企业"); $("#err").text("");
           $("#ename").val(""); $("#addr").val(""); $("#phone").val("");
           $("#fax").val(""); $("#discount").val(""); $("#email").val("");
           $("#pherr").text(""); $("#emerr").text(""); $("#dcerr").text("");
       }

       /*绑定离焦事件*/
       function epblur() {
           $("#ename").bind("blur", function () {
               $("#err").text(""); if ($("#ename").val() == "") return;
               $.ajax({
                   type: "post",
                   url: "/ManagerCenter/ValidateEpExistOrNot/?ename=" + $("#ename").val(),
                   dataType: "text",
                   success: function (data) { $("#err").text(data); }
               });
           });
           $("#phone").bind("blur", function () {
               $("#pherr").text("");
               if ($("#phone").val() == "") return;
               if (!vldMobilePhone($("#phone").val())) { $("#pherr").text("无效手机号！"); }
           });
           $("#email").bind("blur", function () {
               $("#emerr").text("");
               if ($("#email").val() == "") return;
               if (!vldEmail($("#email").val())) { $("#emerr").text(" 无效邮箱！") }
           });
           $("#fax").bind("blur", function () {
               $("#faxerr").text("");
               if ($("#fax").val() == "") return;
               if (!vldPhone($("#fax").val())) { $("#faxerr").text("无效传真！"); }
           });
           $("#discount").bind("blur", function () {
               $("#dcerr").text("");
               if ($("#discount").val() == "") return;
               if (!vldPct($("#discount").val())) { $("#dcerr").text("0<返点<1"); }
           });
       }

       /*解绑离焦事件*/
       function epunblur() {
           $("#ename").unbind("blur");
           $("#phone").unbind("blur");
           $("#email").unbind("blur");
           $("#discount").unbind("blur");
       }
       //****************************************************************************************//
       //----------------------------------------部门管理页面----------------------------------//
       //****************************************************************************************//

       $(document).ready(function () {
           dpblur();
       });
       /*显示或隐藏部门*/
       function showOrHideDp(id) {
           $("#childDiv" + id).toggle('fast');
           if ($("div #childDiv" + id + " ul li").children().html() == null) {
               $("#b" + id).text("[-]");
               return;
           }
           if ($("#b" + id).text() == "[-]")
           { $("#b" + id).text("[+]"); return; }
           $("#b" + id).text("[-]");
       }

       /*添加按钮*/
       function btnAdd() {
           dpblur(); $("#dnavType").text("添加部门");
           $("#dmoperate").val("add"); $("#btnConf").val("确认添加");

           $("#dname").val(""); $("#daddr").val(""); $("#dmbp").val("");
           $("#dfax").val(""); $("#ddiscount").val(""); $("#demail").val(""); $("#dlbc").val("");
           $("#dmbperr").text(""); $("#demerr").text(""); $("#ddcerr").text("");
       }

       /*绑定离焦事件*/
       function dpblur() {
           $("#dname").bind("blur", function () {
               $("#dnerr").text("");
               if ($("#dname").val() == "") return;
               $.ajax({
                   type: "post",
                   url: "/ManagerCenter/ValidateDpExistOrNot/?dname=" + $("#dname").val() + "&eid=" + $("#ename").val(),
                   dataType: "text",
                   success: function (data) { $("#dnerr").text(data); }
               });
           });
           $("#dmbp").bind("blur", function () {
               $("#mbperr").text("");
               if ($("#dmbp").val() == "") return;
               if (!vldMobilePhone($("#dmbp").val())) { $("#mbperr").text("无效手机号！"); }
           });
           $("#demail").bind("blur", function () {
               $("#demerr").text("");
               if ($("#demail").val() == "") return;
               if (!vldEmail($("#demail").val())) { $("#demerr").text(" 无效邮箱！") }
           });
           $("#dfax").bind("blur", function () {
               $("#dferr").text("");
               if ($("#dfax").val() == "") return;
               if (!vldPhone($("#dfax").val())) { $("#dferr").text("无效传真！"); }
           });
           $("#ddiscount").bind("blur", function () {
               $("#ddcerr").text("");
               if ($("#ddiscount").val() == "") return;
               if (!vldPct($("#ddiscount").val())) { $("#ddcerr").text("0<返点<1"); }
           });
           $("#dlbc").bind("blur", function () {
               $("#dlbcerr").text("");
               if ($("#dlbc").val() == "") return;
               if (!vldPct($("#dlbc").val())) { $("#dlbcerr").text("无效数字！"); }
           });

       }

       /*解绑离焦事件*/
       function dpunblur() {
           $("#dfax").unbind("blur"); $("#demail").unbind("blur");
           $("#dmbp").unbind("blur"); $("#dname").unbind("blur");
           $("#dlbc").unbind("blur");
       }

       /*获取部门信息*/
       function getDpInfo(did, eid) {
           dpunblur(); $("#dmoperate").val("update"); $("#did").val(did);
           $("#btnConf").val("确认修改"); $("#dnavType").text("修改企业信息");

           $.getJSON("/ManagerCenter/GetDepartment/?did=" + did, function (Department) {
               $("#dname").val(Department.DName); $("#dmbp").val(Department.MobilePhone); $("#ename").val(eid);
               $("#dfax").val(Department.Fax); $("#demail").val(Department.Email); $("#daddr").val(Department.Addr);
              // $("#dlbc").val(Department.LabourCharges); $("#ddiscount").val(Department.DisCount);
           });
       }

       /*添加或修改部门*/
       function dpConf() {
           $('#addDpForm').ajaxSubmit({
               type: "post",
               url: "/ManagerCenter/AddOrUpdateDepartment",
               dataType: "text",
               success: function (data) {
                   if ($("#dmoperate").val() == "add") {
                       if (data == -1) { alert("添加失败！"); return; }
                       if ($("#ul" + $("#ename").val()).html().trim() != "") {
                           //替换最后一个节点的字符
                           var reg = new RegExp("└", "g"); //创建正则RegExp对象  
                           var str = $("#ul" + $("#ename").val() + "  li:last").html();
                           $("#ul" + $("#ename").val() + "  li:last").html(str.replace(reg, "├"));
                       }

                       //添加新节点
                       var js = " <li id='dp" + data + "' onmouseout='hideImg(" + data + ")' onmouseover='showImg(" + data + ")'>";
                       js += "└ ┄[-]<a  id='a" + data + "'>" + $("#dname").val() + "</a>&nbsp;&nbsp;";
                       js += " <img src='../../../Content/Image/pagesImg/edit.png' id='editimg" + data + "' class='img' ";
                       js += " onclick='getDpInfo(" + data + "," + $("#ename").val() + ")' title='修改'/>&nbsp;&nbsp;";
                       js += " <img src='../../../Content/Image/pagesImg/activate.png' id='faimg" + data + "' class='img' ";
                       js += " onclick='forbiddenOrActivate(" + data + "," + $("#ename").val() + ")' title='激活'/>  &nbsp;";
                       js += "<img src='../../../Content/Image/pagesImg/del.png' id='delimg" + data + "' class='img' ";
                       js += " onclick='delDep(" + data + ")' title='删除'/></li>";

                       $("#ul" + $("#ename").val()).append(js);
                       alert("添加成功！");
                   }
                   else { alert(data); }
               }
           });
       }
       //*************************************************//
       /*       移除节点   参数：子节点ID，父节点ID       */
       //*************************************************//
       function removeNode(cid,pid) {
           var parentNode = $(cid).parent();
           $(cid).remove(); //移除节点
           //替换字符  
            var js = parentNode.children().last().html().trim();
            js = "└ " + js.substr(2,js.length-2);
            parentNode.children().last().html(js);
           if (parentNode.children() == null) {
               $("#b" + pid).text("[-]");
           }
       }

       /*删除部门*/
       function delDep(did, eid) {
           if (!confirm('确认删除吗？')) return;
           $.ajax({
               type: "get",
               url: "/ManagerCenter/DelDepartment/?did=" + did,
               dataType: "text",
               success: function (data) {
                   if (data == "success") { //删除成功则移除节点
                       removeNode("#dp" + did, eid); alert("删除成功！");
                   }
               }
           });
       }

       /*屏蔽或激活部门*/
       function forbiddenOrActivate(did) {
           $.ajax({
               type: "get",
               url: "/ManagerCenter/SetDepDelState/?did=" + did,
               dataType: "text",
               success: function (data) {
                   if (data == "success") {
                       //确保a的：hover属性
                       $("#a" + did).hover(
                        function () {
                            $(this).attr("style", "color:red;");
                        }, function () {
                            $(this).attr("style", "color:blue;");
                        });
                       //变换图标
                       if ($("#faimg" + did).attr("title").trim() == "激活") {
                           $("#a" + did).attr("style", "color:#blue;");
                           $("#faimg" + did).attr({ src: "../../../Content/Image/pagesImg/activate.png", title: "屏蔽" });
                           return;
                       }
                       $("#a" + did).attr("style", "color:#ccc;");
                       $("#faimg" + did).attr({ src: "../../../Content/Image/pagesImg/forbidden.png", title: "激活" });
                       return;
                   }
                   alert(data);
               }
           });
       }
       //****************************************************************************************//
       //----------------------------------------蔬菜管理页面----------------------------------//
       //****************************************************************************************//
       $(document).ready(function () {
           $("#goods").bind("blur", vldVName);
       });
       var addVgtbFlag=false;
       /*验证蔬菜名称是否存在*/
       function vldVName() {
           $.ajax({
               type: "post",
               url: "/ManagerCenter/ValidateVegtbName/?vname=" + $("#goods").val(),
               dataType: "text",
               success: function (data) {
                   $("#error").text(data);
                   if (data == "") { addVgtbFlag= true; }
               }
           });
       }
       /*添加蔬菜*/
       function addVegtb() {
           if ($("#goods").val().trim() == "") {
               alert("蔬菜名称不为空！");return;
           }
           if (!addVgtbFlag) { return; }
           $('#addGoodsForm').ajaxSubmit({
               type: "post",
               url: "/ManagerCenter/AddVegtb",
               dataType: "text",
               success: function (data) {
                   alert(data);
               }
           });
       }

       //****************************************************************************************//
       //----------------------------------------分类管理页面----------------------------------//
       //****************************************************************************************//
       $(document).ready(function () {
           ctgBlur();
       });

       /*显示图片*/
       function showImg(id) {
           $("#editimg" + id).show();
           $("#delimg" + id).show();
           $("#add" + id).show();
           $("#faimg" + id).show();
       }
       /*隐藏图片*/
       function hideImg(id) {
           $("#editimg" + id).hide();
           $("#delimg" + id).hide();
           $("#add" + id).hide();
           $("#faimg" + id).hide();
       }
       /*获取类别信息*/
       function getCtg(cid) {
           $("#ctgOpr").val("update"); $("#btnCtgConf").val("确认修改");
           ctgnuBind(); $("#cid").val(cid);
           $.getJSON("/ManagerCenter/GetCategory/?cid=" + cid,
         function (Category) {
             $("#pcid").val(Category.PCID); $("#corder").val(Category.COrder); $("#cname").val(Category.CName);
         });
       }

       /*删除类别*/
       function delCtg(cid, pcid) {
           if (!confirm("确定删除吗？")) return;
           //若删除父节点则先判断是否存在子节点
           if (cid == pcid) {
               if ($("#childDiv" + cid + "  ul").html().trim() != "") {
                   alert("该类有子类存在，不能删除！"); return;
               }
           }
           $.ajax({
               type: "post",
               url: "/ManagerCenter/DelCategory/?cid=" + cid,
               dataType: "text",
               success: function (data) {
                   if (data == "success") { //删除成功则移除节点
                       //移除父节点
                       if (cid == pcid) {
                           $("#parentDiv" + cid).remove();
                           $("#childDiv" + cid).remove();
                           $("select").find("option[value=" + cid + "]").remove();
                           return;
                       }
                       //移除子节点
                       removeNode("#ctg" + cid, pcid);
                       alert("删除成功！");
                   }
               }
           });
       }
       var vldCName = false;
       var vldVOrder = false;

       /*添加或修改类别*/
       function ctgConf() {
           if ($("#ctgOpr").val() == "add") {
               if (!(vldCName && vldVOrder)) return;
           }
           $('#ctgForm').ajaxSubmit({
               type: "post",
               url: "/ManagerCenter/AddOrUpdateCategory",
               dataType: "text",
               success: function (data) {
                   if ($("#ctgOpr").val() == "add") {
                       if (data == -1) { alert("添加失败！"); return; }

                       var pcid = $("#pcid").val();
                       //添加子节点
                       if (pcid != "0") {
                           //替换最后一个节点的字符
                           if ($("#ul" + pcid).html().trim() != "") {
                               var reg = new RegExp("└", "g"); //创建正则RegExp对象  
                               var str = $("#ul" + pcid + "  li:last").html();
                               $("#ul" + pcid + "  li:last").html(str.replace(reg, "├"));
                           }
                           //如果父类没有子类且父类标签为[-]则父类标签变为[+]
                           if ($("#ul" + pcid).html().trim() == "") {
                               if ($("#b" + pcid).text().trim() == "[-]") {
                                   $("#b" + pcid).text("[+]");
                               }
                           }
                           //添加子节点
                           var childNodejs = " <li id='ctg" + data + "' onmouseout='hideImg(" + data + ")'";
                           childNodejs += " onmouseover='showImg(" + data + ")'>└ ┄[-]  ";
                           childNodejs += " &nbsp;&nbsp;<span style='width:10px;'>" + $("#corder").val() + "</span>&nbsp;";
                           childNodejs += " <a  id='a" + data + "'>" + $("#cname").val() + "</a>&nbsp;";
                           childNodejs += " <img src='../../../Content/Image/pagesImg/edit.png' id='editimg" + data + "'";
                           childNodejs += " class='img' onclick='getCtg(" + data + ")' title='修改'/>&nbsp;";
                           childNodejs += "<img src='../../../Content/Image/pagesImg/del.png'  id='delimg" + data + "' ";
                           childNodejs += " class='img' onclick='delCtg(" + data + "," + pcid + ")' title='删除'/></li>";
                           $("#ul" + pcid).append(childNodejs);
                           return;
                       }
                       //添加父节点
                       var parentNodejs = "  <div style=' margin-bottom:5px;'><div class='fontStyle' id='parentDiv" + data + "'";
                       parentNodejs += "  onmouseout='hideImg(" + data + ")' onmouseover='showImg(" + data + ")'>";
                       parentNodejs += "<b id='b" + data + "'>[-]</b>";
                       parentNodejs += " <span onclick='showOrHideDp(" + data + ")'>" + $("#cname").val() + "</span> &nbsp;&nbsp;";
                       parentNodejs += " <img src='../../../Content/Image/pagesImg/edit.png' id='editimg" + data + "'";
                       parentNodejs += "  onclick='getCtg(" + data + ")' class='img' title='修改'/>  &nbsp;";
                       parentNodejs += "<img src='../../../Content/Image/pagesImg/add.png' id='add" + data + "'";
                       parentNodejs += " class='img' onclick='addCtg(" + data + ")' title='添加'/> &nbsp;";
                       parentNodejs += "<img src='../../../Content/Image/pagesImg/del.png' id='delimg" + data + "'";
                       parentNodejs += " class='img' onclick='delCtg(" + data + "," + data + ")' title='删除'/></div>";
                       parentNodejs += " <div class='fontStyleChild' id='childDiv" + data + "'>";
                       parentNodejs += " <ul id='ul" + data + "'></ul></div></div>";
                       $("#ctglist").append(parentNodejs);

                       //添加父类成功后更新右侧下拉列表数据
                       $("select").find("option[value=0]").remove();
                       var opjs = "<option value='" + data + "'>" + $("#cname").val() + "</option>";
                       opjs += "<option value='0'>无</option>";
                       $("select").append(opjs);

                       alert("添加成功！");
                   }
                   else { alert(data); }
               }
           });
       }

       /*绿色添加按钮触发事件*/
       function addCtg(pcid) {
           $("#ctgOpr").val("add"); $("#cname").val("");
           $("#corder").val(""); $("#pcid").val(pcid);
           $("#btnCtgConf").val("确认添加");
       }

       /*解除绑定*/
       function ctgnuBind() {
           $("#cname").unbind("blur");
           $("#corder").unbind("blur");
       }

       /*绑定离焦事件*/
       function ctgBlur() {
           $("#cname").bind("blur", function () {
               if ($(this).val() == "") return;
               $("cnerr").text("");
               $.ajax({
                   type: "get",
                   url: "/ManagerCenter/CategoryNameExistOrNot/?cname=" + $(this).val().trim(),
                   dataType: "text",
                   success: function (data) {
                       $("#cnerr").text(data);
                       if (data == "") vldCName = true;
                   }
               });
           });
           $("#corder").bind("blur", function () {
               if ($(this).val() == "") return;
               $("#coerr").text("");
               if (!vldNum($(this).val())) { $("#coerr").text("无效数字！"); }
               vldVOrder = true;
           });
       }

       //****************************************************************************************//
       //----------------------------这个是那个下单首页的JS-----------------------------------//
       //****************************************************************************************//
       //## 全局变量定义
       var remarksIsOpen = false; //## 备注盒子是否打开了
       var account = 0; //## 购物车物品总数
       var isUpdating = false;
       //var getCart
       //## 全局变量定义 end
       // -------下单首页私有方法 -------//
       //## 获得ABC的蔬菜<li>对象
       function getABCTabVegetableLiHd(vid) {
           return $(".vegetablesName[vid=" + vid + "]");
       }
       //## 获得购物车的蔬菜<li>对象
       function getShopingCartItemliHd(vid) {
           return $(".cartMsg ul li[vid=" + vid + "]");
       }
       function addHtmlToCartMsgUl(vegetablesID, did, vegetablesName, vegetablesCount) {		//## 购物车单笔数据Html字符串
           var cartHtmlString = '<li vid="' + vegetablesID + '" did=' + did + '><div class="cartDetails"><font class="nameVege">' + vegetablesName + '</font><font>X</font><font type="text" class="txtCartD">' + vegetablesCount + '</font><a class="delCartItem">删除</a><a class="alterCartItem">修改</a></div></li>';
           $('.cartMsg ul').append(cartHtmlString);
       }
       //## 根据企业ID获取部门列表
       function getDepartmentListByEdi(eid) {
           if (eid == -1) //## 如果企业选中“全部”
           {
               $("#Department").html("<option value='-1' >全部</option>");
               return;
           }
           $('.departmentSelect input').attr("disabled", "disabled");
           $("#Department").html("<option value='-2' >请稍等...</option>");
           //## 获得操作类型
           var DepartmentSelectActionType = parseInt($("#Department").attr("action"));
           switch (DepartmentSelectActionType) {
               case 1: //## 在部门列表加上“全部”，不绑定"change"事件
                   $.getJSON("/AJAX/GetDepartmentListByEnterpriseID?eid=" + eid, function (DepartmentList) {
                       $("#Department").empty();
                       $("#Department").append('<option value="-1" >全部</option>');
                       $.each(DepartmentList, function (key, val) {
                           $("#Department").append("<option value='" + val.DID + "' >" + val.DName + "</option>");
                       })
                       $('.departmentSelect input').removeAttr("disabled");
                   })
                   break;
               case 2:
                   $.getJSON("/AJAX/GetDepartmentListByEnterpriseID?eid=" + eid, function (DepartmentList) {
                       $("#Department").empty();
                       $.each(DepartmentList, function (key, val) {
                           $("#Department").append("<option value='" + val.DID + "' >" + val.DName + "</option>");
                       })
                       updateShopingCartByDid($("#Department").val());
                       $('.departmentSelect input').removeAttr("disabled");
                   })
               case 3: //## 不绑定部门"change"事件
                   $.getJSON("/AJAX/GetDepartmentListByEnterpriseID?eid=" + eid, function (DepartmentList) {
                       $("#Department").empty();
                       $.each(DepartmentList, function (key, val) {
                           $("#Department").append("<option value='" + val.DID + "' >" + val.DName + "</option>");
                       })
                       $('.departmentSelect input').removeAttr("disabled");
                   })
                   break;
               default:
                   break;
           }
       }
       //## 鼠标经过提示框
       function TipsBoxHoverIn() {
           var remark = $(this).find("#remark").val();
           if (remark == "" || typeof (remark) == 'undefined' || remark == null)//## 如果没有备注
               return;
           var handleWidth = $(this).outerWidth();
           var handleHeight = $(this).outerHeight();
           $(".mtipsBox").text("备注：" + $(this).find("#remark").val());
           $(".mtipsBox").fadeIn("fast");
           $(this).bind("mousemove", function (e) {
               $(".mtipsBox").css("top", e.pageY - handleHeight);
               $(".mtipsBox").css("left", e.pageX - ($(".mtipsBox").outerWidth()) / 2);
           })
       }
       function TipsBoxHoverOut()//## hoverOut
       {
           $(this).unbind("mousemove");
           $(".mtipsBox").fadeOut("fast");
       }

       //## 提示框
       function showTipsBox(handle, tipsMessage, showTime, showSpeed) {
           var styleBoxHtml = '<div class="tipsBox" style="display: none;">' + tipsMessage + '</div>';
           $("body").append(styleBoxHtml);
           var tipsBox = $(".tipsBox");
           var top = handle.position().top - tipsBox.outerHeight() - 5;
           var left = handle.position().left - ((tipsBox.outerWidth() - handle.outerWidth()) / 2);
           $(".tipsBox").css("top", top);
           $(".tipsBox").css("left", left);
           $(".tipsBox").fadeToggle("fast");
           setTimeout(function () { $(".tipsBox").fadeToggle("fast"); }, showTime);
           setTimeout(function () { $(".tipsBox").remove(); }, showTime + 200);
       }
       //## 删除购物物品
       function delCartItem() {
           var did = $(this).parent().parent().attr('did');
           var vid = $(this).parent().parent().attr('vid');
           var scid = did + "-" + vid;
           var delBtnHd = $(this);
           //## 异步请求，删除数据上的数据
           //## 删除页面上本笔的显示的数据
           $.getJSON("/TakeOrder/DelCartItem?scid=" + scid, function (result) {
               if (result.Result == "OK") {
                   showTipsBox(delBtnHd, "删除成功！", 800, "fast");
                   delBtnHd.parent().parent().remove();
                   $("#cartItemAccount").text(--account); //## 更新购物车总数
                   $(".vegetablesName[vid=" + vid + "]").siblings(".goodsCountInput").val("");
                   $(".vegetablesName[vid=" + vid + "]").siblings("#remark").val("");
               } else {
                   alert("删除不成功！");
               }
           })

       }
       //## 保存购物车修改
       function saveCartItem() {
           var vcount = $(this).siblings(".txtCartD").val();
           if (isNaN(vcount) || vcount == "" || vcount == "0") {
               var connter = $(this).siblings(".txtCartD");
               connter.css("background-color", "#FFB9DC");
               setTimeout(function () { connter.removeAttr("style"); }, 500);
               return;
           }
           var did = $(this).parent().parent().attr("did");
           var vid = $(this).parent().parent().attr("vid");
           var remark = $(this).siblings(".remark2").val();
           //## 异步请求写库，保存修改
           $.ajax({
               type: "POST",
               context: $(this),
               url: "/TakeOrder/UpdateShopingCart",
               data: "scid=" + did + "-" + vid + "&vid=" + vid + "&vcount=" + vcount + "&remark=" + remark + "&did=" + did,
               dataType: "json",
               success: saveCartItemAjaxCallback,
               error: function () { alert("保存不成功！"); }
           });
       }
       //## 显示模态盒子
       function showModalBox(title) {
           var modalHtmlString = '<div id="dialog-mask"></div>'
									+ '<div class="dialogWrap">'
										+ '<div class="dialogContent">'
											+ '<div class="dialogTitle"><span>' + title + '</span><span class="dialogCloseBtn" title="关闭">X</span></div>'
											+ '<div id="dialog">'
											+ '</div>'
										+ '</div>'
									+ '</div>';
           $("body").append(modalHtmlString);
           //## 位置调整
           resetModalBox();
           $(".dialogCloseBtn").bind("click", function () {
               closeModalBox();
           })
       }
       //## 关闭模态盒子
       function closeModalBox() {
           $("#dialog-mask").remove();
           $(".dialogWrap").remove();
       }
       //## 设置Html代码到模态盒子
       function setHtmlToModalBox(HtmlString) {
           $("#dialog").html(HtmlString);
       }
       function resetModalBox() {
           var wnd = $(window), doc = $(document),
				pTop = doc.scrollTop(), pLeft = doc.scrollLeft();

           pTop += (wnd.height() - $(".dialogWrap").outerHeight()) / 2;
           pLeft += (wnd.width() - $(".dialogWrap").outerWidth()) / 2;
           $(".dialogWrap").css({ "top": pTop, "left": pLeft });
       }
       ///## 载入远程html代码
       function loadHtmlToMidalBox(url, callback) {
           $("#dialog").load(url, callback);
       }
       //## 购物车修改按钮点击事件函数
       function alertCartItem()//$('.cartMsg').animate({scrollTop:$('.alterBox').offset().top+$('.cartMsg').scrollTop()},300);
       {
           if ($(this).parent().siblings(".alterBox").length > 0) {
               var alterBoxHd = $(this).parent().siblings(".alterBox");
               alterBoxHd.css("border-color", "#FF0000");
               setTimeout(function () { alterBoxHd.removeAttr("style") }, 300);
               return;
           }
           var vegetableName = $(this).siblings(".nameVege").text(); //## 蔬菜名称
           var vegetableCount = $(this).siblings(".txtCartD").text();
           var currentVid = $(this).parent().parent().attr("vid");
           var remark = $(".vegetablesName[vid=" + currentVid + "]").siblings("#remark").val();
           var CartItemDetailHtmlStr = '<div class="alterBox" style="display:block;"><font class="nameVege bold">' + vegetableName + '</font><span class="closeAlterBtn">X</span><div class="clear"></div><font>&nbsp;&nbsp;数量：</font><input type="text" class="txtCartD" maxlength="5" value="' + vegetableCount + '" /><a type="button" class="saveCartItemBtn">保存修改</a><div class="clear"></div><font class="remarkName"> 备注：</font><textarea class="remark2" >' + remark + '</textarea><div class="clear"></div>';
           $(this).parent().parent().append(CartItemDetailHtmlStr);
           //## 保存修改按钮点击事件
           $('.saveCartItemBtn').unbind("click");
           $(".saveCartItemBtn").bind("click", saveCartItem);
           //## 修改盒子关闭事件
           $(".closeAlterBtn").unbind("click");
           $(".closeAlterBtn").bind("click", function () {
               $(this).parent(".alterBox").remove();
           })
       }
       //## 更新更物车AJAX回调函数
       function saveCartItemAjaxCallback(result) {

           var vcount = $(this).siblings(".txtCartD").val();
           var vid = $(this).parent().parent().attr("vid");
           var remark = $(this).siblings(".remark2").val()
           $(".vegetablesName[vid=" + vid + "]").siblings(".goodsCountInput").val(vcount); //## 更新ABC Tab的数量
           $(".vegetablesName[vid=" + vid + "]").siblings("#remark").val(remark); //## 更新ABC Tab 的备注
           $(this).parent().siblings(".cartDetails").find(".txtCartD").text(vcount);
           showTipsBox($(this), "保存成功！", 800, "fast");
           $(this).parent(".alterBox").remove();
       }
       //## 加入购物车AJAX回调函数
       function addItemToCartCallback(result) {
           var vegetablesID = $(this).siblings('.vegetablesName').attr('vid'); //## 蔬菜ID
           var vegetablesName = $(this).siblings('.vegetablesName').text(); //## 蔬菜名字
           var vegetablesCount = $(this).siblings('.goodsCountInput').val(); 			//## 蔬菜数量			   
           var did = $('#Department').val();  //## 部门ID

           showTipsBox($(this), "操作成功！", 800, "fast"); //## 成功提示优化
           if ($(".cartMsg ul li[vid=" + vegetablesID + "]").length > 0)//## 如果已经加入购物车，则更新购物车
           {
               var cartItemLiHd = $(".cartMsg ul li[vid=" + vegetablesID + "]");
               cartItemLiHd.find(".txtCartD").text(vegetablesCount);
               var alterBox = cartItemLiHd.find(".alterBox");
               if (alterBox.length > 0) {
                   var remark = $(".vegetablesName[vid=" + vegetablesID + "]").siblings("#remark").val();
                   //## 更新已经打开的购物车修改盒子
                   alterBox.find(".txtCartD").val(vegetablesCount);
                   alterBox.find(".remark2").val(remark);
               }
           } else {
               //## 添加购物车盒子购物显示信息
               //## 购物车单笔数据Html字符串
               addHtmlToCartMsgUl(vegetablesID, did, vegetablesName, vegetablesCount);
               $("#cartItemAccount").text(++account); //## 更新购物车总数
           }


           //## 添加vegetable后让滚动条滚到最后//$('.cartMsg').animate({scrollTop:$('.cartMsg').height()},300);
           $('.cartMsg').scrollTop($('.cartMsg').scrollTop() + $('.cartMsg').height());

           //## 绑定-删除购物车的项目事件
           //if($(".delCartItem").data("events")["click"])
           $(".delCartItem").unbind("click");
           $('.delCartItem').bind('click', delCartItem)
           //## 购物车修改事件
           //if($('.alterCartItem').data("events")["click"])//## 如果已经绑定了，必须先解绑，否则会被绑了多个相同的事件到同一个对象
           $('.alterCartItem').unbind("click");
           $('.alterCartItem').bind('click', alertCartItem);
       } //## ajax回调函数

       //## 更新购物车左边盒子视图，右边A,B,C视图
       function updateShopingCartByDid(did) {
           //## 使更新的视图变成菊花
           var busyHtml = '<div class="busy"><img id="busy" src="../Content/Image/pagesImg/busy.gif" /><br /><span>请稍等~~</span></div>';
           $("#abc").hide();
           $(".cartMsg").hide();
           if (!isUpdating) {
               $(".cartBox").append(busyHtml);
               $(".contentWholesalerRight").append(busyHtml);
               isUpdating = !isUpdating;
           }
           account = 0; //## 购物车计数器清零
           //## 异步请求数据
           $.getJSON("/TakeOrder/GetShopingCartList/?did=" + did, function (ShopingCartList) {
               $(".cartMsg ul").empty();
               $(".goodsCountInput").val("");
               $("#remark").val("");
               if (ShopingCartList != null)//## 如果部门购物车不为null
               {
                   $.each(ShopingCartList,
								function (key, val) {
								    addHtmlToCartMsgUl(val.VID, val.DID, val.VName, val.VCount);
								    var vidHd = getABCTabVegetableLiHd(val.VID);
								    vidHd.siblings(".goodsCountInput").val(val.VCount);
								    vidHd.siblings("#remark").val(val.Remarks);
								    account++;
								}
							);
               }
               $("#cartItemAccount").text(account); //## 更新购物车总数		
               $('.delCartItem').bind('click', delCartItem); //## 绑定-删除购物车的项目事件	   
               $('.alterCartItem').bind('click', alertCartItem)//## 购物车修改事件
               $(".busy").remove(); //## 干掉小菊花
               $("#abc").show();
               $(".cartMsg").show();
               isUpdating = !isUpdating;
           });
       }

       // -------下单首页私有方法 End-------//  

       //## Onload 时执行
       $(document).ready(function (e) {
           //*****************************各种事件********************************//
           if (parseInt($("#Department").attr("action")) == 2) {
               updateShopingCartByDid($("#Department").val());
               $("#Department").bind("change", function () {
                   updateShopingCartByDid($("#Department").val());
               })
           }
           
           //## 弹出提示框 调试
           /*			$(".tipsBoxTest").bind("click",function(){
           showTipsBox($(this),"这个不是小菊花！",3000,500);
           })*/
           //hoverTipsBox($(".menuContent li ul li"),$(".menuContent li ul li").siblings("#remark").val(),0,0);

           $(".menuContent li ul li").hover(TipsBoxHoverIn, TipsBoxHoverOut);

           //## ABC,DEF,切换事件
           $('.menuNav li').click(function () {
               var currentTabID = $(this).attr('id');
               var currentMenuIndex = currentTabID.split("-")[1];
               var a = document.getElementById("menu-" + currentMenuIndex);
               for (var i = 0; i <= 9; i++) {
                   if (i != currentMenuIndex) {
                       $("#menu-" + i).attr("style", "display:none");
                       $("#tab-" + i).removeAttr("style");
                   }
               }
               $("#menu-" + currentMenuIndex).attr("style", "display:block");
               $("#tab-" + currentMenuIndex).css("background-color", "#FFFFFF");
           })

           //## 加入购物车
           $('.addToCart').click(function () {
               var addToCartBtnHd = $(this);
               var vegetablesID = $(this).siblings('.vegetablesName').attr('vid'); //## 蔬菜ID
               var vegetablesName = $(this).siblings('.vegetablesName').text(); //## 蔬菜名字
               var vegetablesCount = $(this).siblings('.goodsCountInput').val(); 			//## 蔬菜数量			   
               var did = $('#Department').val();  //## 部门ID

               var remark = $(".vegetablesName[vid=" + vegetablesID + "]").siblings("#remark").val();
               if (typeof (remark) == "undefined" || remark == null)//## 如果备注没有填，传到后台为空串，写库时转为null写进库
                   remark = "";
               if (isNaN(vegetablesCount) || vegetablesCount == "" || vegetablesCount == "0")//## 蔬菜数量  没有填，或不是数字时，提示
               {
                   addToCartBtnHd.siblings('.goodsCountInput').css("background-color", "#FFB9DC");
                   setTimeout(function () { addToCartBtnHd.siblings('.goodsCountInput').removeAttr("style") }, 300);
                   return;
               }
               $.ajax({//## 异步请求，把单条信息写
                   type: "POST",
                   context: $(this),
                   url: "/TakeOrder/AddItemToCart",
                   data: "vid=" + vegetablesID + "&vcount=" + vegetablesCount + "&remark=" + remark + "&did=" + did,
                   dataType: "json",
                   success: addItemToCartCallback
               }); //## $.ajax 结束	
           });

           //## 添加备注
           $('.addRemarks').click(function () {
               //## 获取隐藏属性中的备注
               var remark = $(this).siblings('#remark').val();
               var remarksHtml = '<div class="remarksBox clear" vid="' +
				 $(this).siblings('.vegetablesName').attr("vid")//## 蔬菜ID
				 + '">' +
				 $(this).siblings('.vegetablesName').html()//## 蔬菜名称
				 + '：<input type="text" value="' + remark + '"/><span class="remarkBoxOKBtn" >完成</span><span class="CloseRemarkBoxBtn">X</span></div>';
               if (!remarksIsOpen) {
                   if ($(this).parent().attr('position') == "1") {
                       $(this).parent().after(remarksHtml);
                   } else {
                       if ($(this).parent().next().length > 0)//## 判断最后一行数据是否只有一条数据（判断元素是否存在）
                           $(this).parent().next().after(remarksHtml);
                       else
                           $(this).parent().after(remarksHtml);
                   }
                   remarksIsOpen = !remarksIsOpen;
                   //## 绑定关闭备注盒子事件
                   $('.CloseRemarkBoxBtn').bind('click', function () {
                       remarksIsOpen = !remarksIsOpen;
                       $(this).unbind('click');
                       $(this).parent().remove();
                   })
                   //## 绑定备注完成事件
                   $('.remarkBoxOKBtn').bind('click', function () {
                       var input = $(this).siblings('input');
                       //alert(isNaN(input.val()));
                       if (input.val() == "") {
                           /*input.css("border","1px solid #FF0000");
                           window.setTimeout(function(){input.removeAttr("style");},500);
                           input.css("border","1px solid #FF0000");
                           window.setTimeout(function(){input.removeAttr("style");},500);*/
                           input.css("background-color", "#FFB9DC");
                           window.setTimeout(function () { input.removeAttr("style"); }, 500);
                       } else {
                           //## 蔬菜ID 
                           var vid = $(this).parent(".remarksBox").attr("vid");
                           remarksIsOpen = !remarksIsOpen;
                           $(".vegetablesName[vid=" + vid + "]").siblings('#remark').val(input.val());
                           $(this).unbind('click');
                           $(this).parent().remove();
                       }
                   })
               } //## if (!remarksIsOpen) End
           })
           //## 企业选择下拉框改变事件
           $("#Enterprise").bind('change', function () {
               getDepartmentListByEdi($(this).val());
           })
           //## 从购物车提交订单
           $("#submitShopingCart").bind("click", function () {
               if (account <= 0) {
                   alert("购物车为空！请添加蔬菜！");
                   return;
               }
               $.getJSON("/TakeOrder/SubmitOrder?did=" + $("#Department").val(), function () {
                   alert("订单成功提交！");
                   location.reload();
               });
           })
           //## 修改利润事件
           $(".saveProfit").bind("click", function () {
               var inputTextHd = $(this).siblings(".inputText"); //## 利润输入框对象
               if (isNaN(inputTextHd.val()) || inputTextHd.val() >= 1 || inputTextHd.val().length > 3) {
                   inputTextHd.css("background-color", "#F69");
                   setTimeout(function () { inputTextHd.removeAttr("style"); }, 600);
                   return;
               }
               var pid = inputTextHd.attr("pid");
               var profitValue = inputTextHd.val();
               var saveProfitBtnHd = $(this);
               $.getJSON("/ManagerCenter/SaveProfitByPid/?pid=" + pid + "&profit=" + profitValue,
					function (result) {//## 修改利润回调函数
					    if (result.Result == "OK") {
					        showTipsBox(saveProfitBtnHd, "已保存！", 800, "fast");
					    } else {
					        alert("保存不成功，请检查输入是否有误。")
					    }
					}
					);
           });
           $(".alterVegetable").bind("click", function () {
               var busyHtml = '<div class="busy"><img id="busy" src="../Content/Image/pagesImg/busy.gif" /><br /><span>请稍等~~</span></div>';
               var vid = $(this).attr("vid");
			   var tab = $(this).attr("tab");
               showModalBox("蔬菜编辑");
               setHtmlToModalBox(busyHtml);
               $("#dialog").load("/ManagerCenter/EditVegetable?vid=" + vid, function () {
                   $(".busy").remove(); //## 干掉小菊花
				   $("#submitAlterVegetable").bind("click",function(){
					   		var vid = $("#goods").attr("vid");
							var vname = $("#goods").val();
							var cid = $("select[id=category]").val();
							var keys = $("select[id=keys]").val();
							var specification = $("#specification").val();
							$.ajax({
								type:"POST",
								url:"/ManagerCenter/UpdateVegetable/",
								data:"vid="+vid+"&vname="+vname+"&cid="+cid+"&keys="+keys+"&specification="+specification,
								dataType:"json",
								success:function(result)
									{
										if(result.Result=="OK")
										{
											alert("保存成功！");
											location.href="/ManagerCenter/DeleteAndRestore/"+tab;
										}else{
											alert("保存不成功！");
										}						
									},
								error:function(){alert("请求出错！");}
								});
					   })
                   resetModalBox();
               });
           });
           //*****************************各种事件 End********************************//	
       });

       //--------------这个是那个下单首页的JS 结束-----------------------------------//

       //-----------------------验证修改个人信息模块--------------------------------//
       //验证用户名
       function validateUserName() 
       {
           var innerid = document.getElementById("validateUName");

           innerid.innerHTML = "";

           var username = document.getElementById("LoginName");
           var usernameValue = username.value;
           if (usernameValue.length <= 0) 
           {
               innerid.innerHTML = "请输入用户名";
               //username.select();
               //username.focus();
               return false;
           }

           if (usernameValue.length < 2 || usernameValue.length > 15)
            {
               innerid.innerHTML = "用户名需2-15位";
               //username.select();
               //username.focus();
               return false;
           }

           for (i = 0; i < usernameValue.length; i++) 
           {
               var ch = usernameValue.charAt(i);

               if ((ch >= 0 && ch <= 9) || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')) {

               }
               else {
                   innerid.innerHTML = "用户名只能输入字母或者数字";
                   //username.select();
                   //username.focus();
                   return false;
               }

           }
           return true;
       }

       //验证地址
       function validateAddres() {
           var innerAddr = document.getElementById("validateAddr");

           innerAddr.innerHTML = "";

           var address = document.getElementById("Address");
           var addressValue = address.value;
           if (addressValue.length <= 0) {
               innerAddr.innerHTML = "请输入地址";
               //address.select();
               //address.focus();
               return false;
           }

           return true;
       }

       //验证固定电话
       function validatePhone() {
           var innerPhone = document.getElementById("validatePhone");

           innerPhone.innerHTML = "";

           var phoneNum = document.getElementById("PhoneNum");
           var phoneNumValue = phoneNum.value;
           if (phoneNumValue.length <= 0) {
               innerPhone.innerHTML = "请输入固定电话";
               //phoneNum.select();
               //phoneNum.focus();
               return false;
           }

           return true;
       }

       //验证手机号码
       function validateMobilePhone() {
           var innerMobilePhone = document.getElementById("validateMobilePhone");

           innerMobilePhone.innerHTML = "";

           var mobilePhone = document.getElementById("MobilePhone");
           var mobilePhoneValue = mobilePhone.value;
           if (mobilePhoneValue.length <= 0) {
               innerMobilePhone.innerHTML = "请输入手机号码";
               //mobilePhone.select();
               //mobilePhone.focus();
               return false;
           }

           if (!vldMobilePhone(mobilePhoneValue)) {
               innerMobilePhone.innerHTML = "手机号码必须是以1开始的十一位数字";
               return false;
                
           }

           return true;
       }

       //验证传真
       function validateFax() {
           var innerFax = document.getElementById("validateFax");

           innerFax.innerHTML = "";

           var fax = document.getElementById("Fax");
           var faxValue = fax.value;
           if (faxValue.length <= 0) {
               innerMobilePhone.innerHTML = "请输入传真";
               //fax.select();
               //fax.focus();
               return false;
           }

           return true;
       }

       //验证邮箱
       function validateEmail() {
           var innerEmail = document.getElementById("validateEmail");

           var emailobj = document.getElementById("Email");
           var emailobjvalue = emailobj.value;

           innerEmail.innerHTML = "";

           if (!vldEmail(emailobjvalue)) {
               innerEmail.innerHTML = "邮箱格式不正确";
           }

           if (emailobjvalue.length <= 0) {
               innerEmail.innerHTML = "请输入邮箱";
               //emailobjvalue.select();
               //emailobjvalue.focus();
               return false;
           }

           return true;
       }

       //验证旧密码
       function validateOldPwd() {
           var innerOldPwd = document.getElementById("validateOldPwd");

           innerOldPwd.innerHTML = "";

           var oldPwd = document.getElementById("OldPwd");
           var oldPwdValue = oldPwd.value;
           if (oldPwdValue.length <= 0) {
               innerOldPwd.innerHTML = "请输入旧密码";
               //oldPwdValue.select();
               //oldPwdValue.focus();
               return false;
           }

           return true;
       }

       //验证新的密码两个是否相等以及是否为空
       function validateNewPwd() {
           var innerNewPwd = document.getElementById("validateNewPwd");
           var inneriSureNewPwd = document.getElementById("validateNewSurePwd");

           innerNewPwd.innerHTML = "";
           innerSureNewPwd.innerHTML = "";

           var pwdtext = document.getElementById("NewPwd").value;
           var pwdtext2 = document.getElementById("SureNewPwd").value;

           if (pwdtext.length < 6 || pwdtext.legth > 12) {
               innerNewPwd.innerHTML = "密码必须是6-12位";
               //document.getElementById("pwd").select();
               //document.getElementById("pwd").focus();
               return false;
           }

           if (pwdtext != pwdtext2) {

               innerSureNewPwd.innerHTML = "两次输入密码必须相同";
               //document.getElementById("pwd2").focus();
               //document.getElementById("pwd2").select();
               return false;
           }


           return true;
       }

       function validate() {
           return validateUserName() && validateAddres() && validatePhone() && validateMobilePhone() && validateFax() && validateEmail() && validateOldPwd() && validateNewPwd();
       }


       //-----------------------验证修改个人信息模块结束--------------------------------//



       //-----------------------验证数据统计日期模块--------------------------------//
       function validateMonth() {
           var monthValue = document.getElementById("selectMonth").value;
           if (monthValue == "") {
               alert("请选择要查询的年月份");
               return;
           }
           window.open("/DataCenter/DataAnalysePrint/" + monthValue.replace("-", ""));
       }

