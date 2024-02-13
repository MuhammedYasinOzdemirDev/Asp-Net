using BlogApp.Entity;
namespace BlogApp.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; }//liste alır
        void CreateTag(Tag Tag);
    }
}