using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using VSMS.Models.Model;
using VSMS.Models.BLL;

namespace VSMS.Web.MVC.Controllers
{
    public class AJAXController : BaseController
    {
        //
        // GET: /AJAX/
        DepartmentService DService = new DepartmentService();
        [HttpGet]
        public ActionResult GetDepartmentListByEnterpriseID()
        {
            if (Request.QueryString["eid"] != null)
            {
                return Json(DService.GetDepartmentListByEnterpriseID(int.Parse(Request.QueryString["eid"].ToString().Trim())),JsonRequestBehavior.AllowGet);
            }
            else
            {
                ErrorHandle Errorhd = new ErrorHandle();
                Errorhd.Error = "Please input Params:eid";
                return Json(Errorhd, JsonRequestBehavior.AllowGet);
            } 
        }

    }
}
