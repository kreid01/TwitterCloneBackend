using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public int User1 { get; set; }

        public int User2 { get; set; }
        
        public string User1Name { get; set; }

        public string User2Name { get; set; }

        public string User1At { get; set; }

        public string User2At { get; set; }

        public string User1Img { get; set; }

        public string User2Img { get; set; }

    }
}
