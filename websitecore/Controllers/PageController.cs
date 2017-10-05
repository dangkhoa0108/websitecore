using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Data.Items;
using websitecore.Models;
using websitecore.ViewModel;

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

        public ActionResult Menu()
        {
            Sitecore.Data.Database context = Sitecore.Context.Database;
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var menu = item.Children["Menu"];
            var menuViewModel= new MenuViewModel();
            menuViewModel.lstMenu=new List<Menu>();
            foreach (Item i in menu.Children)
            {
                var menuName = i.Fields["MenuTitle"].Value;
                var menuLink = Sitecore.Context.Database.GetItem(ID).Fields["MenuTitle"].Value;
                var obj = new Menu()
                {
                    MenuTitle = menuName,
                    MenuLink = menuLink
                };
                menuViewModel.lstMenu.Add(obj);
            }
            return View(menuViewModel);
        }

        public ActionResult TopFooter()
        {
            return View();
        }

        public ActionResult BottomFooter()
        {
            return View();
        }

        public ActionResult Col1TopFooter()
        {
            return View();
        }

        public ActionResult Col2TopFooter()
        {
            return View();
        }

        public ActionResult Col3TopFooter()
        {
            return View();
        }

        public ActionResult Col4TopFooter()
        {
            return View();
        }
    }
}