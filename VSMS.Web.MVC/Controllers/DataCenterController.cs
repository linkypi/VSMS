using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VSMS.Common.XphpTool;
using VSMS.Models.BLL;
using VSMS.Models.MVCModels;

namespace VSMS.Web.MVC.Controllers
{
    public class DataCenterController : BaseController
    {
        //
        // GET: /DataCenter/
        AnalyseDataServise analyseDataServise = new AnalyseDataServise();

        public DataCenterController()
        {
            //詹佳杭js控制样式setNavigationCSS
            ViewData["LiId"] = "dataAnalyse";
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DayDataAnalyse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DayDataAnalyse(string selectMonth)
        {
            if (String.IsNullOrEmpty(selectMonth))
            {
                XphpTool.ShowMsg("请输入要查询的年月份！");
                return View();
            }

            if (selectMonth.Equals("1"))
            {
                XphpTool.ShowMsg(analyseDataServise.msg);
                return View();
            }

            return Redirect("/DataCenter/DataAnalysePrint/" + selectMonth.Replace("-", ""));

        }

        [HttpGet]
        public ActionResult DataAnalysePrint(int id)
        {
            ViewData["time"] = id.ToString();

            AnalyseDataModel adModel = analyseDataServise.GetAnalyseDataModel(id.ToString());
            return View(adModel);
            
        }

    }
}
