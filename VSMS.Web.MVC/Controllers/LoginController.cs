
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSMS.Common.XphpTool;
using VSMS.Models.Model;
using VSMS.Models.BLL;

namespace VSMS.Web.MVC.Controllers
{
    public class LoginController : Controller
    {
        AdminService adminService = null;
        Admins admin = null;

        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewData["LoginName"] = Request.Cookies["LoginName"] == null ? null : Request.Cookies["LoginName"].Value;
            ViewData["pwd"] = Request.Cookies["pwd"] == null ? null : "******";
            ViewData["checkbox"] = Request.Cookies["checkbox"] == null ? null : "checked='checked'";

            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="loginPwd">用户密码</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string loginName, string loginPwd, string checkbox)
        {
            //如果将Cookies设置Expires为DataTime.Now，则该Cookie过期，自动会被删除，此时为null
            if (loginPwd == "******" && Request.Cookies["pwd"]!=null)
            {
                loginPwd = Request.Cookies["pwd"].Value;
            }


            adminService = new AdminService();

            if (!adminService.Login(loginName, loginPwd))
            {
                XphpTool.ShowMsg(adminService.msg);
            }
            else
            {
                //登录成功跳转到管理员首页
                admin = adminService.GetModel(loginName);
                if (admin != null)
                {
                    Session["CurrentUser"] = admin;

                    //登录成功后设置Cookies
                    SetCookies(loginName, loginPwd, checkbox);

                    //如果是打开页面时，Session过期，则登录后返回原页面
                    string url = (string)Session["url"];
                    if (!string.IsNullOrEmpty(url))
                    {
                        Session["url"] = null;
                        return Redirect(url);
                    }

                    return RedirectToAction("TakeOrder", "TakeOrder");
                }
            }

            ViewData["LoginName"] = Request.Cookies["LoginName"] == null ? null : Request.Cookies["LoginName"].Value;
            return View();
        }
        /// <summary>
        /// 设置Cookies
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="loginPwd"></param>
        private void SetCookies(string loginName, string loginPwd, string checkbox)
        {
            if (checkbox == "on")
            {
                Response.Cookies["LoginName"].Value = loginName;
                Response.Cookies["LoginName"].Expires = DateTime.MaxValue;

                Response.Cookies["pwd"].Value = loginPwd;
                Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(3);

                Response.Cookies["checkbox"].Value = checkbox;
                Response.Cookies["checkbox"].Expires = DateTime.Now.AddDays(3);
            }
            else
            {
                //Response.Cookies.Remove("pwd");
                Response.Cookies["pwd"].Expires = DateTime.Now;
                Response.Cookies["checkbox"].Expires = DateTime.Now;
            }
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Exit()
        {
            Session["CurrentUser"] = null;
            return RedirectToAction("Login", "Login");
        }
    }
}
