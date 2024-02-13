using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
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
}

