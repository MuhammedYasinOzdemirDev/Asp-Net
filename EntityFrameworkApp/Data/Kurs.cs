

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Kurs
    {
        [Key]
        [DisplayName("Id")]
        public int? KursId { get; set; }
        [DisplayName("Başlık")]
        public string? Baslik { get; set; }
        public int? OgretmenId { get; set; }//buna gerek yok aslında null tanımlanmassa her zaman olmalı
        public Ogretmen? ogretmen { get; set; }//her kursa 1 öğretmen bakıyor
        public ICollection<KursKayit>? KursKayitlari { get; set; }
    }
}