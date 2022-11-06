using System.ComponentModel.DataAnnotations;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Models.Users;

public class User
{
    [Key, Required]
    public int UserId { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string UserAt { get; set; }

    [Required]
    public string UserPassword { get; set; }

    public string? UserImg { get; set; }

    public string? UserCoverImg { get; set; }

    public bool isAdmin { get; set;  }

    [Required]
    public string UserEmail { get; set; }

    public DateTime JoinDate { get; set; } 


    public List<int>? Followers { get; set; }

    public List<int>? Following { get; set; }


}
