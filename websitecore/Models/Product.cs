using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace websitecore.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public int ProductSum { get; set; }
        public double ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
    }
}