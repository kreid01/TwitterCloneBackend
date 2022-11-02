namespace TwitterCloneBackend.Models
{
    public class UpdateUserDto
    {
     public List<int>? LikedPostIds { get; set; }

    public List<int>? RetweetedPostIds { get; set; } 

    public List<int>? PostIds { get; set; }

    public List<Follows>? Followers { get; set; }

    public List<Follows>? Following { get; set; }
    }
}
