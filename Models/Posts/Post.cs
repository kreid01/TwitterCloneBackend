using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwitterCloneBackend.Models.Comments;

public class Post
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserAt { get; set; }

    [Required]
    public string PostTextBody { get; set; }

    public string UserName { get; set; }


    public string UserImg { get; set; }

    public string? PostMedia { get; set; }

    public int PosterId { get; set; }

    public DateTime? PostDate { get; set; }

    public int LikeCount { get; set; }

    public int CommentCount { get; set; }

    public int RetweetCount { get; set; }

    public List<int>? LikedBy { get; set; }

    public List<int>? RetweetedBy { get; set; }

    public List<Comment>? Comments { get; set; }

}
