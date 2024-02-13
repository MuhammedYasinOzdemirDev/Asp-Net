using EntityFrameworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Controllers
{

    public class OgrenciController : Controller
    {
        private readonly KursContext _context;
        public OgrenciController(KursContext context)
        {
            _context = context;//otomatik olusturur
        }
        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci ogrenci)// asenkrona cevrilir
        {
            //await ile veri gonderiir
            if (ModelState.IsValid)
            {
                _context.Ogrenciler.Add(ogrenci);
                await _context.SaveChangesAsync(); ;//kaydeder await askenron yaptığımız için bekler
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogrenciler.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var model = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.Id == id);
            var model = await _context.Ogrenciler.Include(x => x.KursKayitlari).//kursun kayitlari join ettiğimizde getirilmesse null gosterir
            ThenInclude(x => x.Kurs)//Erişğimiz kayıtlardan Inclue ederiz eynı anda değil
            .FirstOrDefaultAsync(o => o.Id == id);//id gore arama
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Ogrenci ogrenci)
        {
            if (id == null)
                return NotFound();
            if (id != ogrenci.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ogrenciler.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var model = await _context.Ogrenciler.FirstOrDefaultAsync(p => p.Id == id);//bu birden fazla sartta arama
                    if (model == null)
                        return NotFound();
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(ogrenci);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Ogrenci model = await _context.Ogrenciler.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)//form içinden gelen id alcam demek çeşitleri var
        {

            Ogrenci model = await _context.Ogrenciler.FindAsync(id);
            if (model.Id != id)
                return NotFound();
            _context.Ogrenciler.Remove(model);
            await _context.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}