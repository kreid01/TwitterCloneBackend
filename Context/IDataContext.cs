using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Models.Comments;

namespace TwitterCloneBackend.Context
{
    public interface IDataContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
