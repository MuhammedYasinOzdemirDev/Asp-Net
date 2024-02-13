using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkApp.Controllers
{

    public class KursController : Controller
    {
        private readonly KursContext _context;
        public KursController(KursContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//onlem için token ekler
        public async Task<IActionResult> Create(Kurs model)
        {
            if (ModelState.IsValid)
            {
                _context.Kurslar.Add(model);
                await _context.SaveChangesAsync();
                return Redirect("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kurslar.Include(x => x.ogretmen).ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var model = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.Id == id);
            ViewBag.Ogretmenler = new SelectList(await _context.Ogretmenler.ToListAsync(), "OgretmenId", "AdSoyad");
            var model = await _context.Kurslar.Include(x => x.ogretmen).
            Include(x => x.KursKayitlari).ThenInclude(x => x.Ogrenci).FirstOrDefaultAsync(x => x.KursId == id);
            ;//id gore arama
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Kurs kurs)
        {
            if (id == null)
                return NotFound();
            if (id != kurs.KursId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Kurslar.Update(kurs);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var model = await _context.Kurslar.FirstOrDefaultAsync(p => p.KursId == id);//bu birden fazla sartta arama
                    if (model == null)
                        return NotFound();
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(kurs);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Kurs model = await _context.Kurslar.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)//form içinden gelen id alcam demek çeşitleri var
        {

            Kurs model = await _context.Kurslar.FindAsync(id);
            if (model.KursId != id)
                return NotFound();
            _context.Kurslar.Remove(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}