using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{

    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var product = new Product { Name = "Iphone X", Price = 6000, Description = "güzel telefon" };

            // ViewData["Category"] = "Telefonlar";
            // ViewData["Product"] = product;

            ViewBag.Category = "Telefonlar";
            // ViewBag.Product = product;

            // ViewBag.Product
            return View(product);
        }
        public IActionResult list()
        {
            var products = new List<Product>()
            {
                new Product {Name="Iphone 7",Price=3000,Description="iyi telefon",IsApproved=false},
                new Product {Name="Iphone 8",Price=4000,Description="çok iyi telefon",IsApproved=true},
                new Product {Name="Iphone X",Price=5000,Description="çok iyi telefon",IsApproved=true},
                new Product {Name="Iphone 11",Price=7000,Description="çok iyi telefon"},
            };

            var productViewModel = new ProductViewModel()
            {
                products = products
            };

            return View(productViewModel);
        }

        public IActionResult Details(int id)
        {
            var product = new Product();

            product.Name = "samsung s6";
            product.Price = 3000;
            product.Description = "iyi telefon";

            return View(product);
        }
    }
}
