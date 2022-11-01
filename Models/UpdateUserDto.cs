namespace TwitterCloneBackend.Models
{
    public class UpdateUserDto
    {
     public List<Post>? LikedPosts { get; set; }

    public List<Post>? RetweetedPosts { get; set; } 

    public List<Post> Posts { get; set; }

    public List<Follows>? Followers { get; set; }

    public List<Follows>? Following { get; set; }
    }
}
