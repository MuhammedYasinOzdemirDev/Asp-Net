using System.Net.Mime;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Entity;

public class Comment
{
    [Key]
    public int CommentId { get; set; }
    public string? Text { get; set; }
    public DateTime PublishedOn { get; set; }
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}
