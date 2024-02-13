using MovieApp.Models;

namespace MovieApp.Data
{
    public static class CategoryRepository
    {
        private static List<Category> _category = null;
        static CategoryRepository()
        {
            _category = new List<Category>(){
        new Category {Id=1,Name = "Macera"},
        new Category {Id=2,Name = "Romantik"},
        new Category {Id=3,Name = "Bilim Kurgu"},
        new Category {Id=4,Name = "Şavaş"},
        new Category {Id=5,Name = "Komedi"},
        new Category {Id=6,Name = "Fantastik"},
            new Category {Id=7,Name = "Aksiyon"},new Category {Id=8,Name = "Dram"}
        };
        }
        public static List<Category> Categories
        {

            get
            {
                return _category;
            }
        }
        public static void AddCategory(Category category)
        {
            _category.Add(category);
        }
        public static Category? GetByID(int id)
        {
            return _category.FirstOrDefault(x => x.Id == id);
        }
    }

}