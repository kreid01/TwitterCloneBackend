using System.ComponentModel.DataAnnotations;
using TwitterCloneBackend.Models;

public class User
{
    [Key, Required]
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string UserAt { get; set; }

    public string UserImg { get; set; }

    public string? UserCoverImg { get; set; }

    [Required]
    public string UserEmail { get; set; }

    public DateTime JoinDate { get; set; } 

    public List<int>? LikedPostIds { get; set; }

    public List<int>? RetweetedPostIds { get; set; } 

    public List<int>? PostIds { get; set; }

    public List<Follows>? Followers { get; set; }

    public List<Follows>? Following { get; set; }


}
