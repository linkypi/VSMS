using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSMS.Models.Model;
using VSMS.Models.BLL;

namespace VSMS.Web.MVC.Controllers
{
    public class BaseController : Controller
    {
        OrdersService os = new OrdersService();

        // GET: /Base/
        //当前登录用户
        public Admins currentUser
        {
            get
            {
                Admins user = Session["CurrentUser"] as Admins;
                return user;
            }
        }

        //验证当前用户是否已经登录，否则跳转到登录页
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string a = null;
            if (currentUser == null)
            {
                Session["url"] = Request.Url.AbsoluteUri;
                Response.Redirect("~/Login/Login",true);
            }
            else
            {
                ViewData["AllDeliveryNote"] = os.GetAllDeliveryNote();
                //Session["url"] = null;
            }
            base.OnActionExecuting(filterContext);
        }


    }
}
