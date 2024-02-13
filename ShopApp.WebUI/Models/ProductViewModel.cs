using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopApp.WebUI.Models;

public class ProductViewModel
{
    public List<Product> products { get; set; }
    public Category category { get; set; }

}
