using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {//migrations yoksa uygular
                    context.Database.Migrate();
                }
                if (!context.Tags.Any())
                {//tabloda Tag yoksa ekler
                    context.Tags.AddRange(
                    new Tag { Text = "Web Programlama" ,Url="web"},
                      new Tag { Text = "Mobil Programlama" ,Url="mobil"},
                        new Tag { Text = "Backend Programlama" ,Url="backend"}
                       
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {//tabloda User yoksa ekler
                    context.Users.AddRange(
                    new User { UserName = "Muhammed Yasin" },
                       new User { UserName = "Eyüp" }
                    );
                    context.SaveChanges();
                }
                if (!context.Posts.Any())
                {//tabloda Post yoksa ekler
                    context.Posts.AddRange(
         new Post { Title = "Asp.Net Core", Content = "Asp.Net Core Dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-10), Tags = context.Tags.Take(3).ToList(), UserID = 1, Image = "1.jpg" ,Url="asp"}//zaman olarak 10 gün önce ve Tags olarak veritabnında 3 tanesini aldık
         , new Post { Title = "Php", Content = "Php Dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-20), Tags = context.Tags.Take(2).ToList(), UserID = 1, Image = "2.jpg" ,Url="php"}
         , new Post { Title = "Django", Content = "Django Dersleri", IsActive = true, PublishedOn = DateTime.Now.AddDays(-10), Tags = context.Tags.Take(4).ToList(), UserID = 2, Image = "3.jpg",Url="django" }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}