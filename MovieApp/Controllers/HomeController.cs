using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieApp.Data;
using MovieApp.Models;

namespace MovieApp.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Index(int? id)
        {
            var ProductCategoryModel = new ProductCategoryModel();
            ProductCategoryModel.Categories = CategoryRepository.Categories;
            ViewBag.SelectCategory = RouteData.Values["id"];//controller action ve imdexe erişim sağlar
            ViewBag.action = RouteData.Values["action"];
            var movies = ProductRepository.Movies;

            if (id != null)
            {
                int idValue = id.Value;
                movies = movies.Where(i => i.CategoriesId.Contains(idValue)).ToList();
            }
            ProductCategoryModel.Products = movies;
            return View(ProductCategoryModel);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            Console.WriteLine(model.Passaword);
            if (ModelState.IsValid)
            {
                Console.WriteLine("a");
                var a = UserRepository.GetUser(model.UserName, model.Passaword);
                if (a != null)
                {

                    HttpContext.Items["UserName"] = a.UserName;
                    HttpContext.Items["UserId"] = a.Id;
                    HttpContext.Items["Administrator"] = a.Administrator;
                    TempData["SuccessMessage"] = "Hoşgeldin " + a.Name;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Hatalı Giriş...";
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                model.Id = UserRepository.Users.Count;
                UserRepository.AddUser(model);
                TempData["SuccessMessage"] = "Başarılı bir şekilde eklendi.";

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}