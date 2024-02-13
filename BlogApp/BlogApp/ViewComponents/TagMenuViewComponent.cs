using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
    [ViewComponent(Name = "TagsMenu")]
    public class TagMenu : ViewComponent
    {
        private ITagRepository _tagRepository;
        public TagMenu(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public IViewComponentResult Invoke()
        {
            return View(_tagRepository.Tags.ToList());
        }
    }
}