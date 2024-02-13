

using EntityFrameworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Controllers
{
    public class OgretmenController : Controller
    {
        private readonly KursContext _context;

        public OgretmenController(KursContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ogretmenler.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ogretmen model)
        {
            if (ModelState.IsValid)
            {

                await _context.Ogretmenler.AddAsync(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _context.Ogretmenler.FindAsync(id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, Ogretmen model)
        {
            if (id != model.OgretmenId)
                return NotFound();
            Console.WriteLine("ks");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ogretmenler.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    if (!_context.Ogretmenler.Any(o => o.OgretmenId == model.OgretmenId))
                    {
                        return NotFound();
                    }

                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _context.Ogretmenler.FirstOrDefaultAsync(x => x.OgretmenId == id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            var model = await _context.Ogretmenler.FirstOrDefaultAsync(x => x.OgretmenId == id);
            if (model == null)
                return NotFound();
            _context.Ogretmenler.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}