using Microsoft.EntityFrameworkCore;

namespace TwitterCloneBackend.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
