namespace TwitterCloneBackend.Repositories
{
    public interface IPostRepository
    {
        Task<Post> Get(int id);
        
        Task<IEnumerable<Post>> GetAll();

        Task Add(Post post);

        Task Delete(int id);

        Task Update(Post product);
    }
}
