using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormApp.Models
{
    public class Repository
    {
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();
        public static List<Product> Products
        {
            get { return _products; }
        }
        public static List<Category> Categories
        {
            get { return _categories; }
        }
        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });

            _products.Add(new Product { Id = 1, Name = "Iphone 11", Price = 40000, IsActive = true, Image = "1.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 2, Name = "Iphone 12", Price = 50000, IsActive = true, Image = "2.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 3, Name = "Iphone 13", Price = 60000, IsActive = true, Image = "3.jpg", CategoryId = 1 });
            _products.Add(new Product { Id = 4, Name = "Iphone 14", Price = 70000, IsActive = true, Image = "4.jpg", CategoryId = 1 });

            _products.Add(new Product { Id = 5, Name = "Macbook Air", Price = 50000, IsActive = true, Image = "5.jpg", CategoryId = 2 });
            _products.Add(new Product { Id = 6, Name = "Macbook Pro", Price = 80000, IsActive = true, Image = "6.jpg", CategoryId = 2 });
            ;
        }
        public static void CreateProduct(Product product)
        {
            _products.Add(product);
        }
        public static void EditProduct(Product updateProduct)
        {
            var entity = _products.FirstOrDefault(p => p.Id == updateProduct.Id);
            if (entity != null)
            {
                entity.Name = updateProduct.Name;
                entity.Price = updateProduct.Price;
                entity.IsActive = updateProduct.IsActive;
                entity.Image = updateProduct.Image;
                entity.CategoryId = updateProduct.CategoryId;
            }
        }
        public static void DeleteProduct(Product product)
        {
            var entity = _products.FirstOrDefault(p => p.Id == product.Id);
            if (entity != null)
            {
                _products.Remove(entity);
            }
        }
    }
}