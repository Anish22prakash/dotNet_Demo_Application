using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demoPart2.Controllers
{
    public class ownRouteController : Controller
    {
        // GET: ownRoute
        public ActionResult Index()
        {
            return View();
        }

        public String demo() {
            return "this is demo of custom routing class";
        }
    }
}