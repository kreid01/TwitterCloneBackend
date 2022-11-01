using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using TwitterCloneBackend.Context;

namespace TwitterCloneBackend.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IDataContext _context;

        public PostRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
       
        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Posts.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Posts.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<Post> Get(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task Update(Post post)
        {
            var itemToUpdate = await _context.Posts.FindAsync(post.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.CommentCount = post.CommentCount;
            itemToUpdate.RetweetCount = post.RetweetCount;
            itemToUpdate.LikeCount = post.LikeCount;
            itemToUpdate.Comments = post.Comments;
            await _context.SaveChangesAsync();
        }
    }
}
