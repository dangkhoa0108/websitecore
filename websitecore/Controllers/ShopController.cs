using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using websitecore.Models;
using websitecore.ViewModel;
using System.Data.Entity;

namespace websitecore.Controllers
{
    public class ShopController : Controller
    {
        Sitecore.Data.Database context = Sitecore.Context.Database;
        // GET: Shop
        public ActionResult Shop()
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var product = item.Children["Product"];
            var productViewModel = new ProductViewModel();
            productViewModel.lstProduct = new List<Product>();
            foreach (Item i in product.Children)
            {
                var productName = i.Fields["ProductName"].Value;
                var productSum = i.Fields["ProductSum"].Value;
                var productPrice = i.Fields["ProductPrice"].Value;
                var productImage = GetUrl(i.Fields["ProductImage"]);
                var productDescription = i.Fields["ProductDescription"].Value;
                var productCategory = i.Fields["ProductCategory"].Value;               
                productViewModel.lstProduct.Add(new Product()
                {
                    ProductName = productName,
                    ProductSum = int.Parse(productSum),
                    ProductPrice = float.Parse(productPrice),
                    ProductImage = productImage,
                    ProductDescription = productDescription,
                    ProductCategory = productCategory
                });              
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

        public ActionResult DetailProduct()
        {
            return View();
        }


        //GET PRODUCT BY CATEGORY
        public ActionResult ProductByCategory(string id)
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            string categoryName=null;
            var category = item.Children["Category"];
            foreach (Item categories in category.Children)
            {
                string categoryId = categories.ID.ToString();
                if (categoryId.Equals(id))
                {
                    categoryName = categories.Fields["CategoryName"].ToString();
                    break;
                }
            }           
            var product = item.Children["Product"];
            var productViewModel = new ProductViewModel();
            productViewModel.lstProduct = new List<Product>();
            foreach (Item i in product.Children)
            {           
                if (i.Fields["ProductCategory"].ToString()==categoryName)
                {
                    var productName = i.Fields["ProductName"].Value;
                    var productSum = i.Fields["ProductSum"].Value;
                    var productPrice = i.Fields["ProductPrice"].Value;
                    var productImage = GetUrl(i.Fields["ProductImage"]);
                    var productDescription = i.Fields["ProductDescription"].Value;
                    var productCategory = i.Fields["ProductCategory"].Value;
                    productViewModel.lstProduct.Add(new Product()
                    {
                        ProductName = productName,
                        ProductSum = int.Parse(productSum),
                        ProductPrice = float.Parse(productPrice),
                        ProductImage = productImage,
                        ProductDescription = productDescription,
                        ProductCategory = productCategory
                    });
                }              
            }
            return View(productViewModel);
        }
    }
}