using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _1_Asp_Net_Baslangic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace _1_Asp_Net_Baslangic.Controllers
{

    public class CourseController : Controller
    {   //course/index
        //course
        public IActionResult Index()
        {
            Course course = new Course() { Id = 1, title = "Komple Uygulamalı Web Geliştirme Eğitimi", img = "1.jpg", description = "Sıfırdan ileri seviyeye 'Web Geliştirme': Html, Css, Sass, Flexbox, Bootstrap, Javascript, Angular, JQuery, Asp.Net Mvc&Core Mvc" };

            return View(course);
            //return "Index Sayfası";
        }
        //course/list
        public IActionResult List()
        {
            return View("CourseList", Repository.Courses);
            //return "List Sayfası";
        }
        public IActionResult Details(int? id)// id bilgisi otamait gelir //soru işareti olmayabilir
        {
            var course = Repository.GetById(id);
            if (id == null || course == null)
            {
                // return Redirect("/course/list");
                return RedirectToAction("List", "Course");
            }
            return View(course);
            //return "Index Sayfası";
        }
    }
}