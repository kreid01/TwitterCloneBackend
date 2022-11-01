namespace TwitterCloneBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string at);

        Task<IEnumerable<User>> GetAll();

        Task Add(User user);

        Task Delete(int id);

        Task Update(User user);
    }
}
