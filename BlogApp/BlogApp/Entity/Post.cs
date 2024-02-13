using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlogApp.Entity;

public class Post
{
    [Key]
    [DisplayName("Id")]
    public int PostId { get; set; }
    [DisplayName("Başlık")]
    public string? Title { get; set; }
    [DisplayName("Aciklama")]
    [DataType(DataType.MultilineText)]
    [StringLength(100, MinimumLength = 3)]
    public string? Content { get; set; }
    [DisplayName("Resim")]
    [BindNever]
    public string? Image { get; set; }
    [DisplayName("Tarih")]
    [DataType(DataType.Date)]//tarih ayarlar
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [BindNever]//formda olmucak anlamını taşır
    public DateTime PublishedOn { get; set; }
    [DisplayName("Aktiflik")]
    public bool IsActive { get; set; }
    public int UserID { get; set; }
    [DisplayName("dssd")]

    public User? User { get; set; }
    public List<Tag> Tags { get; set; } = new List<Tag>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public DateTime Published { get; internal set; }
        public string? Url { get; set; }
}
