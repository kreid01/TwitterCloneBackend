using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Context;

namespace TwitterCloneBackend.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Users.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Users.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<User> Get(string at)
        {
            return await _context.Users.Where(_ => _.UserAt == at).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task Update(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.UserId);
            if (userToUpdate == null)
                throw new NullReferenceException();


            userToUpdate.UserId = user.UserId;
            userToUpdate.Followers = userToUpdate.Followers;
            userToUpdate.Following = userToUpdate.Following;

            await _context.SaveChangesAsync();
        }
    }
}
