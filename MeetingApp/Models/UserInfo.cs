using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class UserInfo
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı Zorunlu")]//doldurulması gerek olan belirtilir 
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]

        public string? Email { get; set; }
        [Required]
        public bool? WillAttend { get; set; }

    }
}