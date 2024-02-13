
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EntityFrameworkApp.Data
{
    public class KursKayit
    {
        [Key]
        [DisplayName("Kayıt No")]
        public int? KayitId { get; set; }
        [DisplayName("Öğrenci")]
        public int? OgrenciId { get; set; }
        public Ogrenci? Ogrenci { get; set; }
        [DisplayName("Kurs")]
        public int? KursId { get; set; }
        public Kurs? Kurs { get; set; }
        [DisplayName("Kayıt Tarihi")]
        public DateTime? KayitTarihi { get; set; }

    }
}