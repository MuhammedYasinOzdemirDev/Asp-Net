

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogrenci
    {

        [Key]//id primary key egereki Id veya ClassAdıId yazılırsa algılayabilir yazılmassa key belirtilmeli
        public int? Id { get; set; }
        [DisplayName("Ögrenci Ad")]
        public string? Ad { get; set; }
        [DisplayName("Ögrenci Soyad")]
        public string? Soyad { get; set; }
        [DisplayName("Ögrenci Eposta")]
        public string? Eposta { get; set; }
        [DisplayName("Ögrenci Telefon")]
        public string AdSoyad
        {
            get
            {
                return this.Ad + " " + this.Soyad;
            }
        }
        public string? Telefon { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}