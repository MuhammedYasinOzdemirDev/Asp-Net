using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CourseApp.Models;
using CourseApp.ViewModels;
namespace CourseApp.Controllers
{

    public class CourseController : Controller
    {
        // action method
        // localhost:5000/course/index => course/index.cshtml
        public IActionResult Index()
        {
            var course = new Course();
            course.Name = "Core Mvc Kursu";
            course.description = "güzel bir kurs";
            course.isPublished = true;
            var list = new List<Student2>(){
            new Student2{Name="Muhammed"},
            new Student2{Name="Yasin"},new Student2{Name="Sümeyye"},
            };
            var viewModel = new CourseStudentsViewModel { Course = course, Students = list };
            return View(viewModel);
        }

        // localhost:5000/course/apply
        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }

        // localhost:5000/course/apply method:POST
        // Name=value&Email=value&Phone=value&Confirm=value
        [HttpPost]
        public IActionResult Apply(Student student)
        {
            if (ModelState.IsValid)
            {
                Repository.AddStudent(student);
                return View("Thanks", student);
            }
            else
            {
                return View(student);
            }

        }

        public IActionResult Details()
        {
            var course = new Course();
            course.Name = "Core Mvc Kursu";
            course.description = "güzel bir kurs";
            course.isPublished = true;

            return View(course);
        }

        // localhost:5000/course/list => course/list.cshtml
        public IActionResult List()
        {
            var students = Repository.Students.Where(i => i.Confirm == true);
            return View(students);
        }
        public IActionResult ByRelesead(int year, int month)
        {
            return Content($"year: {year} month: {month}");
        }
    }
}