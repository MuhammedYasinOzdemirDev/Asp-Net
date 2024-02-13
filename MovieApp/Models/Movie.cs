
namespace MovieApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? LongDescription { get; set; }
        public string? ImageUrl { get; set; }
        public List<int> CategoriesId { get; set; }
    }
}