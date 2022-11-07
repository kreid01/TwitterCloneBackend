using Microsoft.EntityFrameworkCore;
    using TwitterCloneBackend.Context;
using TwitterCloneBackend.Models.Comments;

namespace TwitterCloneBackend.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IDataContext _context;

        public CommentRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Comments.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Comments.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<Comment> Get(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await _context.Comments.ToListAsync();
        }
        public async Task Update(Comment comment)
        {
            var itemToUpdate = await _context.Comments.FindAsync(comment.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetByPostId(int PostId)
        {

            var comments = _context.Comments.Where(_ => _.PostId == PostId).ToList();

            return comments;
        }


    }
}
