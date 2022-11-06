namespace TwitterCloneBackend.Repositories
{
    public interface IUserRepository
    {
        Task<User> Get(string at);

        Task<IEnumerable<User>> GetAll();

        Task Add(User user);

        Task Delete(int id);

        Task Update(User user);

        Task<User> LoginUser(string email, string password);

        Task<List<User>> SerchUsers(string query);

        Task<List<User>> GetFollows(int id, string query);
    }
}
