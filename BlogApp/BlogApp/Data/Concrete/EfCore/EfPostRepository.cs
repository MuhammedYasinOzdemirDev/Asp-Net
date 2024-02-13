using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository//database işlemleri burda yapılır
    {
        private BlogContext _context;

        public EfPostRepository()
        {
        }

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }
        public bool DeletePost(int id)
        {
            var model = _context.Posts.FirstOrDefault(m => m.PostId == id);
            if (model == null)
                return false;
            _context.Posts.Remove(model);
            _context.SaveChanges();
            return true;
        }

        /*public bool EditPost(int id, Post model)
        {
            var a = _context.Posts.FirstOrDefault(m => m.PostId == id);
            if (a == null)
                return false;
            
            _context.Posts.Update(model);
            _context.SaveChanges();
            return true;
        }*/
    }
}