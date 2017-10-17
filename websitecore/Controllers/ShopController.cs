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
        private static void AddToViewModel(ProductViewModel productViewModel, string productId, string productName, string productSum, string productPrice, string productImage, string productDescription, string productCategory)
        {
            productViewModel.lstProduct.Add(new Product()
            {
                ProductID = productId,
                ProductName = productName,
                ProductSum = int.Parse(productSum),
                ProductPrice = float.Parse(productPrice),
                ProductImage = productImage,
                ProductDescription = productDescription,
                ProductCategory = productCategory
            });
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

        // GET: Shop
        public ActionResult Shop()
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
                AddToViewModel(productViewModel, productId, productName, productSum, productPrice, productImage, productDescription, productCategory);
            }
            return View(productViewModel);
        }

        //GET PRODUCT BY CATEGORY ID
        public ActionResult ProductByCategory(string Id)
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            string categoryName=null;
            var category = item.Children["Category"];
            foreach (Item categories in category.Children)
            {
                string categoryId = categories.ID.ToString();
                if (categoryId.Equals(Id)|| Id.Equals(categories.Fields["CategoryName"].ToString()))
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
                    var productId = i.ID.ToString();
                    var productName = i.Fields["ProductName"].Value;
                    var productSum = i.Fields["ProductSum"].Value;
                    var productPrice = i.Fields["ProductPrice"].Value;
                    var productImage = GetUrl(i.Fields["ProductImage"]);
                    var productDescription = i.Fields["ProductDescription"].Value;
                    var productCategory = i.Fields["ProductCategory"].Value;
                    AddToViewModel(productViewModel, productId, productName, productSum, productPrice, productImage, productDescription, productCategory);
                }              
            }
            return View(productViewModel);
        }

        public ActionResult DetailProduct()
        {
            return View();
        }

        public ActionResult Search(string name)
        {
            ViewBag.name = name;
            name = name.ToLower();
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var detailProduct = item.Children["Product"];
            var productViewModel = new ProductViewModel();
            productViewModel.lstProduct = new List<Product>();
            foreach (Item i in detailProduct.Children)
            {
                if (i.Fields["ProductName"].ToString().ToLower().Contains(name))
                {
                    var productId = i.ID.ToString();
                    var productName = i.Fields["ProductName"].Value;
                    var productSum = i.Fields["ProductSum"].Value;
                    var productPrice = i.Fields["ProductPrice"].Value;
                    var productImage = GetUrl(i.Fields["ProductImage"]);
                    var productDescription = i.Fields["ProductDescription"].Value;
                    var productCategory = i.Fields["ProductCategory"].Value;
                    AddToViewModel(productViewModel, productId, productName, productSum, productPrice, productImage, productDescription, productCategory);
                }
            }
            return View(productViewModel);
        }

        public ActionResult SideBarProduct()
        {
            return View();
        }

        public ActionResult ContentProduct(string id)
        {
            Sitecore.Data.Items.Item item = context.Items[new ID("{110D559F-DEA5-42EA-9C1C-8A5DF7E70EF9}")];
            var detailProduct = item.Children["Product"];
            var productViewModel = new ProductViewModel();
            productViewModel.lstProduct = new List<Product>();
            foreach (Item i in detailProduct.Children)
            {
                if (i.ID.ToString() == id)
                {
                    var productId = i.ID.ToString();
                    var productName = i.Fields["ProductName"].Value;
                    var productSum = i.Fields["ProductSum"].Value;
                    var productPrice = i.Fields["ProductPrice"].Value;
                    var productImage = GetUrl(i.Fields["ProductImage"]);
                    var productDescription = i.Fields["ProductDescription"].Value;
                    var productCategory = i.Fields["ProductCategory"].Value;
                    AddToViewModel(productViewModel, productId, productName, productSum, productPrice, productImage, productDescription, productCategory);
                }
            }
            return View(productViewModel);
        }
    }
}