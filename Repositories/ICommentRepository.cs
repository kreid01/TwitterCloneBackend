using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> Get(int id);

        Task<IEnumerable<Comment>> GetAll();

        Task<IEnumerable<Comment>> GetByPostId(int PostId);

        Task Add(Comment comment);

        Task Delete(int id);

        Task Update(Comment comment);
    }
}