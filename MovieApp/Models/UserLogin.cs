using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class UserLogin
    {



        [Display(Name = "Kullanıcı Adı")]
        [Required]
        public string UserName { get; set; }
        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required]
        public string Passaword { get; set; }
    }
}