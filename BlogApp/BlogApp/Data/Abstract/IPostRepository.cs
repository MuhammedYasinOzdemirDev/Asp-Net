using BlogApp.Entity;
namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }//liste alır
        void CreatePost(Post post);
        bool DeletePost(int id);
        // bool EditPost(int id,Post model);
    }
}