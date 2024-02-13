using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Data
{
    public class KursContext : DbContext//
    {
        public KursContext(DbContextOptions<KursContext> options) : base(options)
        {
        }
        public DbSet<Kurs> Kurslar => Set<Kurs>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>();
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
    }
}