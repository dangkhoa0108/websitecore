using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace websitecore.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Header()
        {
            return View();
        }

        public ActionResult TopHeader()
        {
            return View();
        }

        public ActionResult TopFooter()
        {
            return View();
        }

        public ActionResult BottomFooter()
        {
            return View();
        }
    }
}