using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models
{
    public class Follows
    {
       public int Id { get; set; }

        public string UserName { get; set; }

        public string UserAt { get; set; }

        public string UserImg { get; set; }
    }
}
