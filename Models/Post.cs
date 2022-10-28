using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Post
{
 
    public int? id { get; set; }

    [Required]
    public string UserAt { get; set; }

    [Required]
    public string PostTextBody { get; set; }

    public string? PostMedia{ get; set; }

    public DateTime? PostDate { get; set; }

    public int LikeCount { get; set; }

    public int RetweetCount { get; set; }
}
