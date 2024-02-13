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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlogApp.Controllers
{

    public class TagsController : Controller
    {
        private IPostRepository _postrepository;
        private ITagRepository _tagrepository;

        public TagsController(IPostRepository postrepository, ITagRepository tagRepository)
        {//builder services scope ettiğimiz için gelir
            _postrepository = postrepository;
            _tagrepository = tagRepository;
        }


        public IActionResult List()
        {
            return View(_tagrepository.Tags.ToList());
        }


    }
}