using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CourseApp.Models;

namespace CourseApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        int saat = DateTime.Now.Hour;

        ViewBag.Greeting = saat > 12 ? "İyi günler" : "Günaydın";
        ViewBag.UserName = "Sadık";

        return View();
    }

    // localhost:5000/home/about => home/about.cshtml
    public IActionResult About()
    {
        return View();
    }

}
