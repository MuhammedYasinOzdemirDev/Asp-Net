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

    public class MovieController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var model = new ProductCategoryModel();
            model.Categories = CategoryRepository.Categories;
            model.Movie = ProductRepository.GetByID(id);
            return View(model);
        }
    }
}