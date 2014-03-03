using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VSMS.Models.Model;
using VSMS.Models.MVCModels;
using VSMS.Models.BLL;
namespace VSMS.Web.MVC.Controllers
{
    public class TakeOrderController : BaseController
    {
        //
        // GET: /TakeOrder/
    #region 实例化MVCModel
        EnterpriseService EService = new EnterpriseService();
        DepartmentService DService = new DepartmentService();
        TakeOrderModles MvcModel = new TakeOrderModles();
        VegetableService VService = new VegetableService();
        ShopingCartService SCService = new ShopingCartService();
        List<Enterprise> EnterpriseList = new List<Enterprise>();
        List<Department> CurrentDepartmentList = new List<Department>();
        AjaxResult ajaxResult = new AjaxResult();
        OrdersService OService = new OrdersService();
    #endregion

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeOrder()
        {
            //詹佳杭js控制样式setNavigationCSS
            ViewData["LiId"] = "orderMain";
            //获得企业列表
            
            MvcModel.EnterpriseList = EService.GetEnterpriseList();
            if (MvcModel.EnterpriseList==null)
                MvcModel.EnterpriseList = new List<Enterprise>();

            if (Request.QueryString["eid"] == null && Request.QueryString["did"] == null)
            {
                MvcModel.CurrentEnterprisesID = MvcModel.EnterpriseList[0].EID;
                MvcModel.CurrentDepartmentID = DService.GetDepartmentListByEnterpriseID(MvcModel.CurrentEnterprisesID)[0].DID;
            }
            else
            {
                MvcModel.CurrentEnterprisesID = int.Parse(Request.QueryString["eid"].ToString().Trim());
                MvcModel.CurrentDepartmentID = int.Parse(Request.QueryString["did"].ToString().Trim());
            }
            MvcModel.Vges = VService.GetUnDeleteVegetables();
            MvcModel.CurrentDepartmentList = DService.GetDepartmentListByEnterpriseID(MvcModel.CurrentEnterprisesID);
            MvcModel.Vges = VService.GetUnDeleteVegetables();
            MvcModel.ShopingCartItems = SCService.GetShopingCartListByDepartmentID(MvcModel.CurrentDepartmentID);
            if (MvcModel.ShopingCartItems == null)
                MvcModel.ShopingCartItems = new List<ShopingCart>();
            //int lc = MvcModel.Vges.FindAll(v => v.Keys == "A").Count;
            ViewData["MvcModel"] = MvcModel;

            return View();
        }

        /// <summary>
        /// 添加一个蔬菜到购物车
        /// </summary>
        /// <param name="vid">蔬菜ID</param>
        /// <param name="vcount">蔬菜数量</param>
        /// <param name="remark">备注</param>
        /// <param name="did">部门ID</param>
        /// <returns></returns>
        public ActionResult AddItemToCart()//int vid, int vcount, string remark, int did
        {
            if (Request.Form["vid"] == null     //蔬菜ID
                || Request.Form["vcount"] ==null//蔬菜数量
                || Request.Form["remark"] == null//备注
                || Request.Form["did"] == null)//部门ID
            {
                ajaxResult.Result = "error";
                return Json(ajaxResult);
            }
            ShopingCart scModel = new ShopingCart();
            scModel.SCID = Request.Form["did"].ToString().Trim() + "-" + Request.Form["vid"].ToString().Trim();
            scModel.VID = int.Parse(Request.Form["vid"]);
            scModel.VCount = decimal.Parse(Request.Form["vcount"]);
            scModel.Remarks = Request.Form["remark"];
            scModel.DID = int.Parse(Request.Form["did"]);

            if (SCService.AddItemToShopingCart(scModel))
                ajaxResult.Result = "OK";
            else
                ajaxResult.Result = "error";
                return Json(ajaxResult);
        }
        /// <summary>
        /// 从购物车删除一个物品
        /// </summary>
        /// <param name="scid"></param>
        public ActionResult DelCartItem(string scid)
        {
            //ajaxResult.Result = "error";
            if (SCService.DeleteShopingCartItem(scid))
            {
                ajaxResult.Result = "OK";
            }else{
                ajaxResult.Result = "error";
            }
            return Json(ajaxResult, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetShopingCartList(int did)
        {
            return Json(SCService.GetShopingCartListByDepartmentID(did), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UpdateShopingCart(string scid,int did,int vid,decimal vcount,string remark)
        {
            if (vcount == 0)
            {
                ajaxResult.Result = "Error";
                return Json(ajaxResult);
            }
            ShopingCart sc = new ShopingCart();
            sc.SCID = scid;
            sc.DID = did;
            sc.VID = vid;
            sc.VCount = vcount;
            sc.Remarks = remark;

            if (SCService.GetUpdateShopingCart(sc))
            {
                ajaxResult.Result = "OK";
            }
            else
            {
                ajaxResult.Result = "Error";
            }
            return Json(ajaxResult);
        }

        [HttpGet]
        public ActionResult SubmitOrder(int did)
        {
            if (OService.Add(SCService.GetShopingCartListByDepartmentID(did)))
            {
                ajaxResult.Result = "OK";
            }
            else
            {
                ajaxResult.Result = "error";
            }
            return Json(ajaxResult, JsonRequestBehavior.AllowGet);
        }
     }
}
