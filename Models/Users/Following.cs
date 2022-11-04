using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models.Users
{
    public class Following
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserAt { get; set; }

        public string UserImg { get; set; }
    }
}
