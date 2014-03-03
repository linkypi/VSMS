using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VSMS.Models.BLL;
using VSMS.Models.Model;
using VSMS.Models.MVCModels;
using VSMS.Common.XphpTool;

namespace VSMS.Web.MVC.Controllers
{
    public class ManagerCenterController : BaseController
    {
        private VegetableService vs = new VegetableService();
        private readonly CategoryService cs = new CategoryService();
        private readonly EnterpriseService es = new EnterpriseService();
        private AdminService adminService=new AdminService();
        private DepartmentService ds = new DepartmentService();
        private ProfitService ps = new ProfitService();
        
        
        EarnManagementModels MvcModel = new EarnManagementModels();
        //
        // GET: /ManagerCenter/

        public ActionResult Index()
        {
            return View();
            

        }

        /// <summary>
        /// 添加新品种页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddVegetable()
        {
            //詹佳杭js控制样式setNavigationCSS
            ViewData["LiId"] = "managerCenter";

            List<Category> list=cs.GetAllCategories();
            return View(list);
        }
        /// <summary>
        /// 蔬菜修改
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        //public ActionResult AddVegetable(int vid)
        //{
        //    //詹佳杭js控制样式setNavigationCSS
        //    ViewData["LiId"] = "managerCenter";


        /// <summary>
        /// 验证蔬菜名称
        /// </summary>
        [HttpPost]
        public void ValidateVegtbName(string vname)
        {
            if (vs.ExistOrNot(vname))
            { Response.Write("该蔬菜名称已存在！"); }
        }

        /// <summary>
        /// 添加蔬菜
        /// </summary>
        [HttpPost]
        public void AddVegtb()
        {
            Vegetable vt = new Vegetable();
            vt.CID = int.Parse(Request.Form["category"]);
            vt.VName = Request.Form["goods"];
            vt.Specification = double.Parse(Request.Form["specification"]);
            vt.Keys = Request.Form["keys"];
            bool ret = vs.Add(vt);
            if (!ret)
            {
                Response.Write("添加失败！");
                return;
            }
            Response.Write("添加成功！");
        }

        public ActionResult ChangeVOrder()
        {
            //Request.Form["vOrder"]
            ViewData["VOrderList"] = vs.GetChangeVOrder();
            return View();
        }

        public ActionResult DeleteAndRestore(int? id)
        {
            ViewData["MenuTab"] = id;
            if (ViewData["MenuTab"] == null)
            {
                ViewData["MenuTab"] = 1;
            }
            ViewData["Vegetable"] = vs.GetVegetableFromKeys();
            return View();
        }

        /// <summary>
        /// 通过《a》标签传过来的id删除蔬菜
        /// </summary>
        /// <param name="vid">《a》标签传过来的id</param>
        /// <param name="menuTab">《a》标签传过来的ul的id尾数</param>
        /// <returns>删除后刷新页面</returns>
        public ActionResult Delete(int vid,string menuTab)
        {
            vs.DisappearVegetable(vid);
            return RedirectToAction("DeleteAndRestore/" + menuTab);
        }

        /// <summary>
        /// 通过《a》标签传过来的id恢复蔬菜
        /// </summary>
        /// <param name="vid">《a》标签传过来的id</param>
        /// <param name="menuTab">《a》标签传过来的ul的id尾数</param>
        /// <returns>恢复后刷新页面</returns>
        public ActionResult Restore(int vid, string menuTab)
        {
            vs.AppearVegetable(vid);
            return RedirectToAction("DeleteAndRestore/" + menuTab);

        }

        public ActionResult EarnManagement()
        {
            //获得企业列表
            MvcModel.EnterpriseList = es.GetEnterpriseList();

            if (Request.QueryString["eid"] == null && Request.QueryString["did"] == null)
            {
                MvcModel.CurrentEnterprisesID = MvcModel.EnterpriseList[0].EID;
                MvcModel.CurrentDepartmentID = ds.GetDepartmentListByEnterpriseID(MvcModel.CurrentEnterprisesID)[0].DID;
            }
            else
            {
                MvcModel.CurrentEnterprisesID = int.Parse(Request.QueryString["eid"].ToString().Trim());
                MvcModel.CurrentDepartmentID = int.Parse(Request.QueryString["did"].ToString().Trim());
            }
            
            MvcModel.CurrentDepartmentList = ds.GetDepartmentListByEnterpriseID(MvcModel.CurrentEnterprisesID);

            ViewData["MvcModel"] = MvcModel;

            EarnManagementModels earnManagementModels = MvcModel as EarnManagementModels;

            int did = earnManagementModels.CurrentDepartmentID;

            ViewData["ProfitMessage"]=ps.GetChangeMessage(did);

            return View();
        }

        public ActionResult SaveChange()
        {
            EarnManagementModels earnManagementModels = MvcModel as EarnManagementModels;

            int did = earnManagementModels.CurrentDepartmentID;

            List<ProfitMessageModels> profitMessage = ps.GetChangeMessage(did);
            //foreach (ProfitMessageModels profitMsg in profitMessage)
            //{
            //    profitMsg.PI
            //}
            
            return RedirectToAction("DeleteAndRestore");

        }

        /// <summary>
        /// 企业管理
        /// </summary>
        /// <returns></returns>
        public ActionResult HotelManagement()
        {
            List<Enterprise> list = es.GetEnterpriseList();
            return View(list);
        }

        /// <summary>
        /// 获取企业信息
        /// </summary>
        /// <param name="eid"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetEnterprise(int eid)
        {
            return Json( es.GetModel(eid),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除企业
        /// </summary>
        /// <param name="eid">企业编号</param>
        [HttpGet]
        public void DeleteHotel(int eid)
        {
            if (es.DelEnterprise(eid))
            { 
                Response.Write("success");
                return;
            }
            Response.Write("faile");
        }

        /// <summary>
        /// 屏蔽或恢复企业
        /// </summary>
        /// <param name="eid"></param>
        [HttpGet]
        public void SetHotelDelState(int eid)
        {
            if (es.SetDelState(eid))
            {
                Response.Write("success"); 
                return;
            }
            Response.Write("faile");

            
        }

        /// <summary>
        /// 验证企业名称是否存在
        /// </summary>
        /// <param name="ename">企业名称</param>
        [HttpPost]
        public void ValidateEpExistOrNot(string ename)
        {
            if (es.Exist(ename)) { Response.Write("该企业名称已存在 !"); }
        }

        /// <summary>
        /// 添加或修改企业
        /// </summary>
        [HttpPost]
        public void AddOrUpdateHotel()
        {
            Enterprise ep = new Enterprise();
            ep.EName = Request.Form["ename"].Trim();
            ep.Addr = Request.Form["addr"].Trim();
            ep.MobilePhone = Request.Form["phone"].Trim();
            ep.Fax = Request.Form["fax"].Trim();
            ep.Email = Request.Form["email"].Trim();
           // ep.DisCount = double.Parse(Request.Form["discount"].Trim());
            ep.EID = int.Parse(Request.Form["eid"].Trim());
            string type = Request.Form["operate"];
            if (type == "add")
            {
                int eid= es.Add(ep);
                if (eid!=-1) { Response.Write(eid); return; }
                Response.Write(-1);
            }
            if (type == "update" )
            {
                if (es.Update(ep)) { Response.Write("更新成功 !"); return; }
               Response.Write("更新失败！"); 
            }
        }

        public ActionResult PersonMsg()
        {
            ViewData["Msg"] = adminService.GetAdminsMessageByAID(this.currentUser.AID);

            //ViewData["LoginName"] = this.currentUser.LoginName;
            
            return View();
        }


        /// <summary>
        /// 点击修改个人信息按钮后转到的页面
        /// </summary>
        /// <returns>修改页面后重新刷新页面</returns>
        public ActionResult Save()
        {
            string loginName = Request.Form["LoginName"].Trim();       //获得用户名
            string address = Request.Form["Address"].Trim();           //获得地址
            string phoneNum = Request.Form["PhoneNum"].Trim();         //获得固定电话号码
            string mobilNum = Request.Form["MobilePhone"].Trim();      //获得手机号码
            string fax = Request.Form["Fax"].Trim();                   //获得传真
            string email = Request.Form["E-mail"].Trim();              //获得邮箱
            string oldPwd = Request.Form["OldPwd"].Trim();             //获得旧密码
            string newPwd = Request.Form["NewPwd"].Trim();             //获得新密码
            string surePwd = Request.Form["SureNewPwd"].Trim();        //获得新密码的确认密码
            string previousLoginName = this.currentUser.LoginName;

            Admins admins=adminService.GetAdminsMessageByAID(this.currentUser.AID);

            if (adminService.WhetherExistLoginName(loginName,this.currentUser.AID))
            {
                return Content("<script>alert('所更改的用户名已存在，请重新输入');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("所更改的用户名已存在，请重新输入");
                //return View();
            }


            if (address.Length < 0 || phoneNum.Length < 0 || mobilNum.Length < 0 || fax.Length < 0 || email.Length < 0||oldPwd.Length<0)
            {
                //return Content("<script>alert('所有字段都不能为空');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                XphpTool.ShowMsg("所有字段都不能为空");
                return View();
            }

            if (loginName.Length < 2 || loginName.Length > 15)
            {
                return Content("<script>alert('用户名必须在2-15位之间');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("用户名必须在2-15位之间");
                //return View();
            }
            
            if (email.IndexOf("@") <= 0 || email.IndexOf(".") <= 0 || email.LastIndexOf("@") > email.LastIndexOf("."))
            {
                return Content("<script>alert('必须包含@和.，且.需要在@后面');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("必须包含@和.，且.需要在@后面");
                //return View();
            }

            if (oldPwd != admins.Pwd)
            {
                return Content("<script>alert('旧密码错误，请重新输入');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("旧密码错误，请重新输入");
                //return View();
            }

            if (newPwd == "" || newPwd == null||newPwd.Length>12||newPwd.Length<6)
            {
                return Content("<script>alert('新密码不能为空，且必须在6-12位之间');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("新密码不能为空，且必须在6-12位之间");
                //return View();
            }

            if (newPwd != surePwd)
            {
                return Content("<script>alert('两次密码必须相等');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("两次密码必须相等");
                //return View();
            }

            if (adminService.GetUpdateAdminMsg(loginName, newPwd, address, phoneNum, mobilNum, fax, email, previousLoginName))
            {
                return Content("<script>alert('修改个人信息成功');window.location.href='/ManagerCenter/PersonMsg';</script>", "text/html");
                //XphpTool.ShowMsg("修改个人信息成功");
            }
            return RedirectToAction("PersonMsg");
        }


         /// <summary>
        /// 类别管理
        /// </summary>
        /// <returns></returns>
        public ActionResult SortManagement()
        {
            List<Category>list = cs.GetModels();
            List<Category> prlist = cs.GetAllParents();
            Category ct =new Category();
            ct.CName = "无";
            ct.PCID=0;
            prlist.Add(ct);
            ViewData["Parents"] = prlist;
            return View(list);
        }

        /// <summary>
        /// 获取所有父类
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllParents()
        {
            return Json(cs.GetAllParents(),JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 部门管理
        /// </summary>
        /// <returns></returns>
        public ActionResult DepartmentManagement()
        {
            List<Enterprise> list= es.GetAllModels();
            return View(list);
        }

        /// <summary>
        /// 验证部门名称是否存在
        /// </summary>
        /// <param name="ename">部门名称</param>
        /// <param name="eid">部门所在企业编号</param>
        [HttpPost]
        public void ValidateDpExistOrNot(string dname,int eid)
        {
            if (ds.ExistOrNot(eid,dname)) { Response.Write("该部门已存在 !"); }
        }

        /// <summary>
        /// 添加或修改部门
        /// </summary>
        [HttpPost]
        public void AddOrUpdateDepartment()
        {
            Department dp = new Department();
            dp.DName = Request.Form["dname"].Trim();
            dp.Addr = Request.Form["daddr"].Trim();
            dp.MobilePhone = Request.Form["dmbp"].Trim();
            dp.Fax = Request.Form["dfax"].Trim();
            dp.Email = Request.Form["demail"].Trim();
            //dp.DisCount = double.Parse(Request.Form["ddiscount"].Trim());
            dp.EID = int.Parse(Request.Form["ename"].Trim());
            string type = Request.Form["dmoperate"];
            if (type == "add")
            {
                int did = ds.Add(dp);
                if (did != -1) { Response.Write(did); return; }
                Response.Write(-1);
            }
            if (type == "update")
            {
                dp.DID = int.Parse(Request.Form["did"].Trim());
                if (ds.Update(dp)) { Response.Write("更新成功 !"); return; }
                Response.Write("更新失败！");
            }
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="did">部门编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetDepartment(int did)
        {
            return Json(ds.GetModel(did),JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 屏蔽或激活部门
        /// </summary>
        /// <param name="did">部门编号</param>
        [HttpGet]
        public void SetDepDelState(int did)
        {
            if (es.GetEpDelState(did))
            {
                Response.Write("请先激活该部门所在的企业！");
                return;
            }
            if (ds.SetDelState(did))
            {
                Response.Write("success");
                return;
            }
            Response.Write("faile");
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="did"></param>
        [HttpGet]
        public void DelDepartment(int did)
        {
            if (ds.Delete(did))
            {
                Response.Write("success");
                return;
            }
            else
            { Response.Write("faile"); }
           
        }

        /// <summary>
        /// 删除类别
        /// </summary>
        /// <param name="cid">类别编号</param>
        public void DelCategory(int cid)
        {
            if (cs.DelCategory(cid))
            {
                Response.Write("success");
                return;
            }
            Response.Write("faile");
        }

        /// <summary>
        /// 添加或修改类别
        /// </summary>
       public void  AddOrUpdateCategory()
        {
            Category ctg = new Category();
            ctg.COrder = int.Parse(Request.Form["corder"].Trim());
            ctg.CName = Request.Form["cname"].Trim();
            ctg.PCID = int.Parse(Request.Form["pcid"].Trim());

            string type = Request.Form["ctgOpr"];
            if (type == "add")
            {
                int did = cs.Add(ctg);
                if (did != -1) { Response.Write(did); return; }
                Response.Write(-1);
            }
            if (type == "update")
            {
                ctg.CID = int.Parse(Request.Form["cid"].Trim());

                if (cs.Update(ctg))
                { 
                    Response.Write("更新成功 !"); 
                    return; 
                }
                Response.Write("更新失败！");
            }
        }

        /// <summary>
        /// 验证类别是否存在
        /// </summary>
       [HttpGet]
       public void CategoryNameExistOrNot(string cname)
       {
           if (cs.ExistOrNot(cname))
           {
               Response.Write("该类别已存在");
               return;
           }
       }

        /// <summary>
        /// 获取类别信息
        /// </summary>
        /// <param name="cid">类别编号</param>
        /// <returns></returns>
        [HttpGet]
       public ActionResult GetCategory(int cid )
       {
           return Json(cs.GetModelByCID(cid),JsonRequestBehavior.AllowGet);
       }

        public ActionResult SaveProfitByPid(int pid,double profit)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if (ps.GetChangeProfit(profit, pid))
            {
                ajaxResult.Result = "OK";
            } 
            else
            {
                ajaxResult.Result = "error";
            }
            return Json(ajaxResult, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 编辑蔬菜
        /// </summary>
        /// <param name="vid">蔬菜ID</param>
        /// <returns>编辑蔬菜HTML</returns>
        public ActionResult EditVegetable(int vid)
        {
            ViewData["categoriesList"] = cs.GetAllCategories();
            ViewData["vegetable"] = vs.GetVegetableByVid(vid);
            return View();
        }

        /// <summary>
        /// 更新修改蔬菜
        /// </summary>
        /// <param name="vid"></param>
        /// <param name="vname"></param>
        /// <param name="cid"></param>
        /// <param name="keys"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public ActionResult UpdateVegetable(int vid, string vname, int cid, string keys, double specification)
        {
            AjaxResult ajaxResult = new AjaxResult();
            if (vs.Update(vid, vname, cid, keys, specification))
            {
                ajaxResult.Result = "OK";
            }
            else
            {
                ajaxResult.Result = "error";
            }
            return Json(ajaxResult);
        }
    }
}
