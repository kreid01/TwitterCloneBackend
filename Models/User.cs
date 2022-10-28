using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key, Required]
    public int id { get; set; }

    [Required]
    public string UserName { get; set; }

    public string UserImg { get; set; }


    public List<Post> Posts { get; set; }

}
