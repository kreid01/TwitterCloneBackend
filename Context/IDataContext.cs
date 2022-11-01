using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Context
{
    public interface IDataContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Comment> Comments { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
