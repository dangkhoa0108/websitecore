using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using websitecore.Models;
using websitecore.ViewModel;

namespace websitecore.Controllers
{
    public class PageController : Controller
    {
        Sitecore.Data.Database context = Sitecore.Context.Database;
        // GET: Page
        public ActionResult Header()
        {
            Session["auth"] = null;
            FormsAuthenticationTicket authTicket = null;
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];//.ASPXAUTH
            if (authCookie != null)
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket != null) Session["autho"] = authTicket.Name;
            }
            //string email = null;
            //if (authTicket != null)
            //{
            //    email = authTicket.Name;
            //}
            return View("");
        }

        public ActionResult Slider()
        {
            return View();
        }
        public ActionResult TopHeader()
        {
            return View();
        }

        public ActionResult Promo()
        {
            return View();
        }

        public ActionResult Brand()
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var brand = item.Children["Brand"];
            var brandViewModel = new BrandViewModel();
            brandViewModel.lstBrand = new List<Brand>();
            foreach (Item i in brand.Children)
            {
                var brandName = i.Fields["BrandName"].Value;
                var brandImage = GetUrl(i.Fields["Image"]);
                var obj = new Brand()
                {
                    BrandName = brandName,
                    BrandImage = brandImage

                };
                brandViewModel.lstBrand.Add(obj);
            }
            return View(brandViewModel);
        }

        public ActionResult ProductWidget()
        {
            return View();
        }

        public ActionResult TopSellProduct()
        {
            return View();
        }

        public ActionResult RecentlyProduct()
        {
            return View();
        }

        public ActionResult TopNewProduct()
        {

            return View();
        }
        public ActionResult Menu()
        {          
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var menu = item.Children["Menu"];
            var menuViewModel= new MenuViewModel();
            menuViewModel.lstMenu=new List<Menu>();
            foreach (Item i in menu.Children)
            {
                var menuName = i.Fields["MenuTitle"].Value;
                var menuLink = i.Fields["MenuLink"].Value;
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

        // Categories
        public ActionResult Col3TopFooter()
        {
            Sitecore.Data.Items.Item item= context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var category = item.Children["Category"];
            var categoryViewModel = new CategoryViewModel();
            categoryViewModel.lstCategory = new List<Category>();
            foreach (Item i in category.Children)
            {
                var categoryID = i.ID.ToString();
                var categoryName = i.Fields["CategoryName"].Value;
                var obj = new Category()
                {
                    CategoryID = categoryID,
                    CategoryName = categoryName,
                };
                categoryViewModel.lstCategory.Add(obj);
            }
            return View(categoryViewModel);
        }

        public ActionResult Col4TopFooter()
        {
            return View();
        }

        public ActionResult LastestProduct()
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var product = item.Children["Product"];
            var productViewModel = new ProductViewModel();
            productViewModel.lstProduct = new List<Product>();
            foreach (Item i in product.Children)
            {
                var productId = i.ID.ToString();
                var productName = i.Fields["ProductName"].Value;
                var productSum = i.Fields["ProductSum"].Value;
                var productPrice = i.Fields["ProductPrice"].Value;
                var productImage = GetUrl(i.Fields["ProductImage"]);
                var productDescription = i.Fields["ProductDescription"].Value;
                var productCategory = i.Fields["ProductCategory"].Value;
                var obj = new Product()
                {
                   ProductID = productId,
                   ProductName  = productName,
                   ProductSum = int.Parse(productSum),
                   ProductPrice = float.Parse(productPrice),
                   ProductImage = productImage,
                   ProductDescription = productDescription,
                   ProductCategory = productCategory

                };
                productViewModel.lstProduct.Add(obj);
            }
            return View(productViewModel);
        }

        // GET URL IMAGE
        public string GetUrl(Sitecore.Data.Fields.ImageField imgId)
        {
            var imageUrl = string.Empty;

            Sitecore.Data.Fields.ImageField imageField = imgId;
            if (imageField?.MediaItem != null)
            {
                var image = new MediaItem(imageField.MediaItem);
                imageUrl = StringUtil.EnsurePrefix('/', MediaManager.GetMediaUrl(image));
            }
            return imageUrl;
        }
    }
}