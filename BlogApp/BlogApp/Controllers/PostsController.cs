using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;
using BlogApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{

    public class PostsController : Controller
    {
        private IPostRepository _postrepository;
        private ITagRepository _tagrepository;
        private IUserRepository _userRepository;

        public PostsController(IPostRepository postrepository, ITagRepository tagRepository, IUserRepository userRepository)
        {//builder services scope ettiğimiz için gelir
            _postrepository = postrepository;
            _tagrepository = tagRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index(string? tag)
        {
            var posts = _postrepository.Posts.ToList();
            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(y => y.Url == tag)).ToList();
            }
            return View(
            new PostsViewModel
            {
                Posts = posts,
                Tags = _tagrepository.Tags.ToList()
            }
            );
        }
        public IActionResult List()
        {
            return View(_postrepository.Posts.Include(x => x.User).ToList());
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Users = new SelectList(await _userRepository.Users.ToListAsync(), "UserId", "UserName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Post model, IFormFile Image)
        {

            int id = _postrepository.Posts.Count() - 1;
            Console.Write("\n\nid" + id + "\n\n");
            if (Image == null)
            {

                ModelState.AddModelError("", "Lutfen bir resim seçiniz");
            }
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };//resim için uzantılar girilir
            var extension = Path.GetExtension(Image.FileName);//girilen dosyanın uzantısı alınır
            var fileName = id.ToString() + extension;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);
            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Gecerli bir resim seçiniz");
            }

            model.User = await _userRepository.Users.FirstOrDefaultAsync(a => a.UserId == model.UserID);
            if (ModelState.IsValid)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);//img ilgilir klasore belirtilen isimde kaydedilir
                }
                model.PublishedOn = DateTime.Now;
                model.Image = fileName;
                _postrepository.CreatePost(model);

                return RedirectToAction("List");
            }
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
                return NotFound();
            if (_postrepository.DeletePost(id))
                return RedirectToAction("List");
            else
                return NotFound();
        }
        /* [HttpGet]
         public IActionResult Edit(int? id)
         {
         if(id == null)
             return NotFound();

         else{
         var model=_postrepository.Posts.FirstOrDefaultAsync(a=>a.PostId == id);
         return View(model);}
         }*/
        public async Task<IActionResult> Details(string url)
        {
            return View(await _postrepository.Posts.FirstOrDefaultAsync(a => a.Url.Equals(url)));
        }

    }


}
