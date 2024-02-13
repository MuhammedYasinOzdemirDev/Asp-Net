using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(string searchstring, string category)
    {
        var Products = Repository.Products;
        if (!string.IsNullOrEmpty(searchstring))
        {//arama yeri bos değilse
            ViewBag.searchstring = searchstring;//arama yapılıyorsa aradığında değer kaybolmasın diye atılır
            Products = Products.Where(p => p.Name.ToLower().Contains(searchstring.ToLower())).ToList();
        }
        if (!string.IsNullOrEmpty(category) && category != "0")
        {
            Products = Products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);//2 inc neye gre filtreleme yapacığı diğeri Name yani gorulcek kısmı category kısmı secili gorunmesi
        return View(Products);
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }
    [HttpPost]
    //Hangi Alanların alıncağına Bind ile filtrelebiliriz
    //public IActionResult Create([Bind("Name","Price")]Product model)
    //async ile task olmalı
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)//Name ismine gore sırayla yazılabilir ama aynı adda olmalı string Name,Decimal Price gibi devam eder
    {//IForm file dosya alır
        if (imageFile == null)
        {

            ModelState.AddModelError("", "Lutfen bir resim seçiniz");
        }
        var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };//resim için uzantılar girilir
        var extension = Path.GetExtension(imageFile.FileName);//girilen dosyanın uzantısı alınır
        var randomfileName = string.Format($"{Guid.NewGuid().ToString()}.{extension}");//rasgele isim ile uzantı birleştirilir
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomfileName);//aynı dizinde klasor ve ismi belirtilir
        if (!allowedExtensions.Contains(extension))
        {//uzantıyı kontrol eder
            ModelState.AddModelError("", "Gecerli bir resim seçiniz");
        }
        if (ModelState.IsValid)//hata varmı kontrol eder yoksa kaydeder validation cağırır 
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);//img ilgilir klasore belirtilen isimde kaydedilir
            }
            model.Image = randomfileName;
            model.Id = Repository.Products.Count;//id ataması yaparız
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if (id == null)
            return NotFound();
        var model = Repository.Products.FirstOrDefault(p => p.Id == id);
        if (model == null)
            return NotFound();
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(int? id, Product model, IFormFile? imageFile)
    {
        if (id != model.Id)
        {
            return NotFound();
        }


        if (ModelState.IsValid)//hata varmı kontrol eder yoksa kaydeder validation cağırır 
        {
            if (imageFile != null)
            {

                var extension = Path.GetExtension(imageFile.FileName);//girilen dosyanın uzantısı alınır
                var randomfileName = string.Format($"{Guid.NewGuid().ToString()}.{extension}");//rasgele isim ile uzantı birleştirilir
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomfileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);//img ilgilir klasore belirtilen isimde kaydedilir
                }
                model.Image = randomfileName;
            }
            Repository.EditProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }
    public IActionResult Delete(int? id)
    {
        if (id == null)
            return NotFound();
        var entity = Repository.Products.FirstOrDefault(p => p.Id == id);
        if (entity == null)
            return NotFound();
        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");
    }
}
