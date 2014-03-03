using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using VSMS.Models.BLL;
using VSMS.Models.Model;
using VSMS.Models.MVCModels;


namespace VSMS.Web.MVC.Controllers
{
    public class OrderManagerController : BaseController
    {
        private readonly OrdersService orderservice = new OrdersService();
        private readonly VegetableService vservice = new VegetableService();

        private readonly OrdersService ordersService = new OrdersService();
        private readonly DepartmentService departmentService = new DepartmentService();
        private readonly EnterpriseService enterpriseService = new EnterpriseService();
        private readonly OrderDetailService orderDetailService = new OrderDetailService();


        private static List<string> listVID = new List<string>(); //蔬菜编号列表
        private static List<string> ircVID = new List<string>();//部门编号列表
        private static List<string> dnVIDs = new List<string>(); //送货单蔬菜编号列表
        // GET: /OrderSearch/
        public ActionResult Index()
        {
            //new Array(Request.Form["vOrder"]);
            return View();
        }

        public ActionResult OrderSearch()
        {

            OrderSearchModel osModel = new OrderSearchModel();
            int Count = 10;

            string currentEnterprise = Request.QueryString["Enterprise"];
            string currentDepartment = Request.QueryString["Department"];
            string currentOrderTime = Request.QueryString["OrderTime"];
            string currentOrderState = Request.QueryString["OrderState"];
            string currentPage = Request.QueryString["Page"];
            if (currentEnterprise != null) osModel.CurrentEnterprise = currentEnterprise;
            if (currentDepartment != null) osModel.CurrentDepartment = currentDepartment;
            if (currentOrderTime != null) osModel.CurrentOrderTime = currentOrderTime;
            if (currentOrderState != null) osModel.CurrentOrderState = currentOrderState;
            if (currentPage != null) osModel.CurrentPage = int.Parse(currentPage);
            

            if (osModel.CurrentEnterprise != "-1")
            {
                int eid = int.Parse(osModel.CurrentEnterprise);
                osModel.CurrentDepartmentList = departmentService.GetDepartmentListByEnterpriseID(eid);
            }

            osModel.EnterpriseList = enterpriseService.GetEnterpriseList();

            osModel.Count = ordersService.GetCountByCondition(currentEnterprise, currentDepartment, currentOrderTime, currentOrderState);
            osModel.TotalPage = (osModel.Count-1) / Count + 1;
            osModel.PageList = PageList(osModel.TotalPage, osModel.CurrentPage);

            if (osModel.CurrentPage < 1) osModel.CurrentPage = 1;//验证，防止越界
            if (osModel.CurrentPage > osModel.TotalPage) osModel.CurrentPage = osModel.TotalPage;//验证，防止越界

            osModel.OrdersList = ordersService.GetListByCondition(currentEnterprise,currentDepartment, currentOrderTime, currentOrderState, osModel.CurrentPage, Count);


            //詹佳杭js控制样式setNavigationCSS
            ViewData["LiId"] = "orderSearch";

			 return View(osModel);
        }

        /// <summary>
        /// 页面导航
        /// </summary>
        /// <param name="TotalPage">页面总数</param>
        /// <param name="CurrentPage">当前页号</param>
        /// <returns>页面导航列表</returns>
        private static List<int> PageList(int TotalPage, int CurrentPage)
        {
            List<int> pagelist = new List<int>();
            if (TotalPage <= 5)
            {
                for (int i = 1; i <= TotalPage; i++)
                {
                    pagelist.Add(i);
                }
            }
            else
            {
                if (CurrentPage == TotalPage)//前四后零
                {
                    for (int i = CurrentPage - 4; i <= CurrentPage; i++)
                    {
                        pagelist.Add(i);
                    }
                }
                else if (TotalPage - CurrentPage == 1)//前三后一
                {
                    for (int i = CurrentPage - 3; i <= CurrentPage + 1; i++)
                    {
                        pagelist.Add(i);
                    }
                }
                else//前二后二,前一后三，前零后四
                {
                    int i = CurrentPage - 2;
                    for (int j = 1; j <= 5; j++)
                    {
                        if (i <= 0) { j--; i++; continue; }
                        pagelist.Add(i);
                        i++;
                    }
                }
            }
            return pagelist;
        }

        /// <summary>
        /// 订单详细，根据orderId
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns></returns>
        public ActionResult OrderDetail(string orderId)
        {
            
            OrderDetailModels orderDetailModels = new OrderDetailModels();

            Orders order = ordersService.GetModel(orderId);
            //如果没有该订单，则定向到订单查询表
            if (order == null) return RedirectToAction("OrderSearch", "OrderManager");

            orderDetailModels.Order = order;
            orderDetailModels.Department = departmentService.GetModel(orderDetailModels.Order.DID);
            orderDetailModels.Enterprise = enterpriseService.GetModel(orderDetailModels.Department.EID);
            orderDetailModels.OrderDetailList = orderDetailService.GetList(orderId);


            if (orderDetailModels.Order == null ||
                orderDetailModels.Department == null ||
                orderDetailModels.Enterprise == null ||
                orderDetailModels.OrderDetailList == null)
            {
                //出错了重定向，待写
                return RedirectToAction("OrderSearch", "OrderManager");
            }

            return View(orderDetailModels);
        }

        /// <summary>
        /// 送货单打印
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DeliveryNote(string oid)
        {
            List<DeliveryNote> list = orderservice.GetDeliveryNoteByOID(oid);
            ViewData["DeliveryNote"] = list ;
            dnVIDs.Clear();
            foreach(DeliveryNote dn in list )
            {
                dnVIDs.Add(dn.VID);
            }
         
            return View();
        }

        /// <summary>
        /// 更新送货单
        /// </summary>
        /// <param name="oid"></param>
        [HttpPost]
        public void UpdateDeliveryNote(string oid)
        {
            List<double> values = new List<double>();

            for (int i = 0; i < dnVIDs.Count; i++)
            {
                string valueStr = Request.Form["input" + dnVIDs[i]];
                if (string.IsNullOrEmpty(valueStr)) continue;
                double value = double.Parse(valueStr);
                values.Add(value);
            }

            //orderservice.ExecuteNoQurey();
        }
        /// <summary>
        ///采购单 打印
        /// </summary>
        ///<param name="id">第几页</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PurchaseNote(int id)
        {
            ViewData["PurchaseNote"] = orderservice.GetPurchaseNote(id);
            return View();
        }

        /// <summary>
        /// 检货单打印
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InspectionSheet()
        {
            List<Enterprise> epList = new List<Enterprise>();
            ViewData["InspectionSheetDetail"] = orderservice.GetInspectionSheet(out epList);
            ViewData["Vegetables"] = vservice.GetInspectionSheetVegetabls();
            return View(epList);
        }


        /// <summary>
        /// 成本价录入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InputPrice()
        {
            //ViewData["IPCurrentPage"] = id; 
            //ViewData["IPTotalPage"]=orderservice.GetPNTotalPage();
        
            List<PurchaseNote> list = orderservice.GetPurchaseNote(0);
            if (list == null) return View(list);

            listVID.Clear();
            //记录当前页的蔬菜标号 
            foreach (PurchaseNote pn in list)
            {
                listVID.Add(pn.VID);
            }

            return View(list);
        }

        /// <summary>
        /// 录入实收量
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult InputRealCount(string oid)
        {
            ViewData["OID"] = oid;
           // ViewData["IRCCurrentPage"] = page;
            //ViewData["IRCTotalPage"] = orderservice.GetDNTotalPage(oid);
            List<DeliveryNote> list = orderservice.GetDeliveryNoteByOID(oid.ToString());

            ircVID.Clear();
            if (list != null)
            {
                //记录当前页的蔬菜标号 
                foreach (DeliveryNote dn in list)
                {
                    ircVID.Add(dn.VID);
                }
            }
            return View(list);
        }



        /// <summary>
        /// 录入成本价
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TypeInWholesalePrice()
        {
            List<double> values = new List<double>();

            if (listVID == null)
            {
                return Redirect("/OrderManager/InputPrice/1");
            }
            for (int i = 0; i < listVID.Count; i++)
            {
                string valueStr = Request.Form["input" + listVID[i]];
                if (string.IsNullOrEmpty(valueStr)) continue;
                double value = double.Parse(valueStr);
                values.Add(value);
            }
            orderservice.TypeInWholesalePrice(listVID, values);

            return  Redirect("/OrderManager/InputPrice/1");
        }

        /// <summary>
        /// 录入实收量
        /// </summary>
        /// <param name="oid">订单编号</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult TypeInRealCount(string oid)
        {
            List<double> counts = new List<double>();

            if (ircVID.Count == 0)
            {
                return Redirect("/OrderManager/InputRealCount/?oid=" + oid );
            }
            for (int i = 0; i < ircVID.Count; i++)
            {
                string countStr = Request.Form["input" + ircVID[i]];
                if (string.IsNullOrEmpty(countStr)) continue;
                double count = double.Parse(countStr);
                counts.Add(count);
            }
            orderservice.TypeInRealCount(oid, ircVID, counts);
            return Redirect("/OrderManager/InputRealCount/?oid=" + oid );
        }
    }
}
