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

    [Required]
    public string UserEmail { get; set; }

    public DateTime JoinDate { get; set; } 


    public List<Followers>? Followers { get; set; }

    public List<Following>? Following { get; set; }


}
