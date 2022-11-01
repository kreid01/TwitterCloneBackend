using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Models;

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
    }
}
