namespace TwitterCloneBackend.Models.Users
{
    public class UpdatePostDto
    {
        public int LikeCount { get; set; }

        public int RetweetCount { get; set; }

        public int CommentCount { get; set; }

        public int Id { get; set; }

        public List<int> RetweetedBy { get; set; }

        public List<int> LikedBy { get; set; }

    }
}
