using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1_Asp_Net_Baslangic.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? title { get; set; }//soru işareti null olailir anlamanıda 
        public string? img { get; set; }
        public string? description { get; set; }
        public string[]? Tags { get; set; }
        public bool isHome { get; set; }
        public bool isActive { get; set; }
    }
}