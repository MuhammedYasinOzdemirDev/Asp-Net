

using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            int saat = DateTime.Now.Hour;
            var selamlama = saat > 12 ? "İyi Günler" : "Günaydın";
            // return View(model:selamlama);egerki ilk veri string ise karıştırır o yuzden model oldugu belirtilir
            ViewBag.selamlama = selamlama;//değişken kullanabileceğimiz olusturur
            ViewData["Selamlama"] = selamlama;//buda baska sekil
            ViewData["username"] = "Yasin";//boylede birçok olabilir
            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location = "Haliç Kongre Merkezi",
                Date = new DateTime(2024, 01, 20, 20, 0, 0),
                NumberOfPeople = 100
            };
            return View(meetingInfo);
        }
    }
}