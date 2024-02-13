

namespace _1_Asp_Net_Baslangic.Models
{
    public static class Repository
    {
        private static readonly List<Course> _courses = new();
        static Repository()
        {
            _courses = new List<Course>(){
               new Course() { Id = 1,
                title = "Komple Uygulamalı Web Geliştirme Eğitimi",
                img = "1.jpg",
                description = "Sıfırdan ileri seviyeye 'Web Geliştirme': Html, Css, Sass, Flexbox, Bootstrap, Javascript, Angular, JQuery, Asp.Net Mvc&Core Mvc"
                ,Tags=new String[] { "Python","Django"},
                isActive=true,
                isHome=false
                },

            new Course() { Id = 2, title = "Python ile Sıfırdan İleri Seviye Python Programlama", img = "2.jpg", description = "Sıfırdan İleri Seviye Python Dersleri.Veritabanı,Veri Analizi,Bot Yazımı,Web Geliştirme(Django)" ,
            Tags=new String[] { "Web Geliştirme","Html", "Css", "Bootstrap", "Javascript",".Net Core"},
                isActive=true,
                isHome=true},
            new Course() { Id = 3, title = "Sıfırdan İleri Seviye Modern Javascript Dersleri ES7+", img = "3.jpg", description = "Modern javascript dersleri ile (ES6 & ES7+) Nodejs, Angular, React ve VueJs için sağlam bir temel oluşturun."
             ,Tags=new String[] {"Javascript","React"},
                isActive=false,
                isHome=true}
    };
        }
        public static List<Course> Courses { get { return _courses; } set { } }
        public static Course GetById(int? id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);//ilk eşiti gonderir

        }

    }
}