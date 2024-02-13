namespace MovieApp.Models
{
    public class ProductCategoryModel
    {
        public IEnumerable<Movie> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Movie Movie { get; set; }
    }
}