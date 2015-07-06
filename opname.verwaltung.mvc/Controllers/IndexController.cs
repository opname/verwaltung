using opname.verwaltung.mvc.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace opname.verwaltung.mvc.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        [Audit]
        public ActionResult Index()
        {
            return View();
        }

    }
}
