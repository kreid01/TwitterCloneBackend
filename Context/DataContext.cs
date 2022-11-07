using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Models;
using TwitterCloneBackend.Models.Comments;

namespace TwitterCloneBackend.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }
        
    }
}
