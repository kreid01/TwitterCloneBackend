using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models.Users
{
    public class UserUpdateDto
    {
        public string? UserImg { get; set; }

        public string? UserCoverImg { get; set; }

        public bool isAdmin { get; set; }

        public List<int>? Followers { get; set; }

        public List<int>? Following { get; set; }
    }
}
