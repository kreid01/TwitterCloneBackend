using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int ChatId { get; set; }

        public string SenderName { get; set; }

        public string MessageContent { get; set; }

        public DateTime Created { get; set; }
    }
}
