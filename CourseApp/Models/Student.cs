using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Student
    {
        [Required(ErrorMessage = "isminizi giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email adresi giriniz")]
        [EmailAddress(ErrorMessage = "Email adresinizi düzgün giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon giriniz.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Katılma durumunuz nedir ?")]
        public bool? Confirm { get; set; } // true, false, null
    }
}