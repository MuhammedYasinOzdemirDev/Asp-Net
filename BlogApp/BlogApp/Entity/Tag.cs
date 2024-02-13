using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity;

public class Tag
{
    [Key]
    [DisplayName("Id")]
    public int TagId { get; set; }
    [DisplayName("Kategori")]
    public string? Text { get; set; }
      public string? Url { get; set; }
}
