using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp2.Models;

namespace FormApp2.Controllers;

public class HomeController : Controller
{


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    public IActionResult Search(string q)
    {
        string a = "";
        if (q != null)
            a = q;
        ViewBag.aa = a;
        return View();
    }


}
