using BlogApp.Entity;
namespace BlogApp.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }//liste alır
        void CreateUser(User user);
    }
}