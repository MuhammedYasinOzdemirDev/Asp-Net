using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ad")]

        public string Name { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required]
        public string Passaword { get; set; }
        public bool Administrator { get; set; }
    }
}