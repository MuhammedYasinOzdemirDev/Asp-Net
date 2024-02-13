using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _1_Asp_Net_Baslangic;

namespace _1_Asp_Net_Baslangic.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
        //return "home index";
    }

    public IActionResult Privacy()
    {
        return View();
        //return "home privacy";
    }


}
