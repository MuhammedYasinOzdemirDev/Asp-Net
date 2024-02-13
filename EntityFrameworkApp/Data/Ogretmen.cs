

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogretmen
    {
        [Key]
        [DisplayName("Id")]
        public int? OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        [DataType(DataType.Date)]//tarih ayarlar
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BaslamaTarihi { get; set; }
        [DisplayName("Ad Soyad")]
        public string? AdSoyad
        {
            get
            {
                return this.Ad + " " + this.Soyad;
            }
        }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();//birden fazla kursa derss verebilir
    }
}