using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {

        [HttpGet]
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Apply(String name, string email, bool WillAtend)model yapılmassa
        public IActionResult Apply(UserInfo model)
        {

            Console.WriteLine(model.Name);
            Console.WriteLine(model.Email);
            Console.WriteLine(model.WillAttend);
            Console.WriteLine(model.Phone);
            Repository.CreateUser(model);
            
            if (ModelState.IsValid)
            {//formda form validation kontrol ederiz
                ViewBag.UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();//true olalanır filtreleme ve sayar
                return View("Thanks", model);
            }
            else
            {
                return View(model);//tekrar göndeririz modeli gondeririz asp-for sayesinde value değerleri değişmez
            }
        }
        public IActionResult List()
        {
            return View(Repository.Users);
        }
        public IActionResult Details(int id)
        {
            return View(Repository.GetById(id));
        }
    }
}