using Microsoft.EntityFrameworkCore;

namespace TwitterCloneBackend.Context
{
    public interface IDataContext
    {
        public DbSet<Post> Posts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
