using System;
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

    public class UsersController : Controller
    {
        private IPostRepository _postrepository;
        private ITagRepository _tagrepository;

        public UsersController(IPostRepository postrepository, ITagRepository tagRepository)
        {//builder services scope ettiğimiz için gelir
            _postrepository = postrepository;
            _tagrepository = tagRepository;
        }

        public IActionResult Index()
        {
            return View(
            new PostsViewModel
            {
                Posts = _postrepository.Posts.ToList(),
                Tags = _tagrepository.Tags.ToList()
            }
            );
        }
        public IActionResult List()
        {
            return View(_postrepository.Posts.Include(x => x.User).ToList());
        }
        public async Task<ActionResult> Create()
        {
            ViewBag.Tags = new SelectList(await _tagrepository.Tags.ToListAsync(), "TagId", "Text");
            return View();
        }


    }
}