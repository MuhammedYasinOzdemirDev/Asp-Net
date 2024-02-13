using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [Range(0.0, Double.MaxValue, ErrorMessage = "Değer 0'dan büyük olmalıdır.")]
    public double Price { get; set; }
    public string? Description { get; set; }
    public bool IsApproved { get; set; }

}
