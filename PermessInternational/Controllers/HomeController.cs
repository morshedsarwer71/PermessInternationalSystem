using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PermessInternational.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var concernId = Convert.ToInt32(Session["ConcernId"]);
            var userId = Convert.ToInt32(Session["UserId"]);
            if (concernId > 0 && userId > 0)
            {
                return RedirectToAction("Index", "GlobalData", new { Area = "Global" });
            }
            return RedirectToAction("Index", "GlobalData", new { Area = "Global" });
        }
    }
}