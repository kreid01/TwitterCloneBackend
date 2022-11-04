namespace TwitterCloneBackend.Models.Comments
{
    public class Comment
    {
        public int Id { get; set; }

        public int? PosterId { get; set; }

        public int PostId { get; set; }

        public string UserAt { get; set; }

        public string UserName { get; set; }

        public string UserImg { get; set; }

        public string CommentBody { get; set; }

        public string? CommentMedia { get; set; }

        public DateTime? CommentDate { get; set; }

    }
}
