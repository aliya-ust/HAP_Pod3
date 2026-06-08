using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HealthCareWeb.Controllers
{
    public class HealthRecordController : Controller
    {
        public ActionResult HealthHistory()
        {
            return View();
        }
    }

}