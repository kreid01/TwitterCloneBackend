using Microsoft.EntityFrameworkCore;
using TwitterCloneBackend.Context;
using TwitterCloneBackend.Models.Users;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            userToUpdate.Followers = user.Followers;
            userToUpdate.Following = user.Following;
            userToUpdate.UserImg = user.UserImg;
            userToUpdate.UserCoverImg = user.UserCoverImg;
            userToUpdate.isAdmin = user.isAdmin;

            await _context.SaveChangesAsync();
        }

        public async Task<User> LoginUser(string email, string password)
        {
            return await _context.Users.Where(_ => _.UserPassword == password && _.UserEmail == email).FirstOrDefaultAsync();

        }
         public async Task<List<User>> SerchUsers(string query)
        {
            return await _context.Users.Where(_ => _.UserAt.Contains(query) || _.UserName.Contains(query)).ToListAsync();
        }

        public async Task<List<User>> GetFollows(int id, string query)
        {
           var user = await _context.Users.Where(_ => _.UserId == id).FirstOrDefaultAsync();

           var users = await _context.Users.ToListAsync();

            var follows = new List<User>();

            if (query == "followers")
            {

                if (user != null)
                {
                    foreach (var follower in user.Followers)
                    {
                        follows.Add(users.Where(_ => _.UserId == follower).FirstOrDefault());
                    }
                }
            } else if (query == "following")
            {
                if (user != null)
                {
                    foreach (var follower in user.Following)
                    {
                        follows.Add(users.Where(_ => _.UserId == follower).FirstOrDefault());
                    }
                }

            }

            return follows;
        }

    }
}
