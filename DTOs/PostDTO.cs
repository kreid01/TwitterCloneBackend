using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.DTOs
{
    public class PostDTO
    {
        public string UserAt { get; set; }
        
        public string PostTextBody { get; set; }

        public string? PostTextMedia { get; set; }

        public DateTime PostDate { get; set; }

        public int LikeCount { get; set; }

        public int RetweetCount { get; set; }
    }
}
