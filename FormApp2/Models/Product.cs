using System.ComponentModel.DataAnnotations;

namespace FormApp2.Models
{
    //[Bind("Name","Price")]hangi alanların formdan çekilceği belirtilebilir
    public class Product
    {
        [Display(Name = "Urun Id")]//baslık verirken değiken ismine gore alınır display yoksa
        //[BindNever]bu Id çekilememesini sağlar
        public int Id { get; set; }
        [Display(Name = "Urun Adı")]
        [StringLength(100, ErrorMessage = "Maksimum 100 karekter")]
        [Required(ErrorMessage = "Zorunlu alan")]
        public string? Name { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Zorunlu alan")]
        [Range(10, 100000, ErrorMessage = "10 ile 1000000 arası olmalı")]
        public Decimal Price { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }

}