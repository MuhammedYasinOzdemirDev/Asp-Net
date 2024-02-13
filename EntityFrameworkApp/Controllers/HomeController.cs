using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EntityFrameworkApp.Models;
using EntityFrameworkApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EntityFrameworkApp.Controllers;

public class HomeController : Controller
{
    private readonly KursContext _context;

    public HomeController(KursContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {

        return View(await _context.KursKayitlari.
        Include(x => x.Ogrenci).//ogrenci bilgilerini join ile yuklenir
        Include(x => x.Kurs).//aynı anda kurs incluede edilir
        ToListAsync());
    }
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "Id", "AdSoyad");
        ViewBag.Kurslar = new SelectList(await _context.Kurslar.ToListAsync(), "KursId", "Baslik");

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(KursKayit kayit)
    {
        if (ModelState.IsValid)
        {
            kayit.KayitTarihi = DateTime.Now;
            _context.KursKayitlari.Add(kayit);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View();
    }

}
