namespace TwitterCloneBackend.Models.Users
{
    public class UpdateUserDto
    {
        public List<int>? LikedPostIds { get; set; }

        public List<int>? RetweetedPostIds { get; set; }

        public List<int>? PostIds { get; set; }

        public List<Followers>? Followers { get; set; }

        public List<Following>? Following { get; set; }
    }
}
