using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Models.Users;
using TwitterCloneBackend.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace TwitterCloneBacked.NameSpace
{

    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAll();

            return Ok(users);
        }
        [HttpGet]
        [Route("users/login")]
        public async Task<ActionResult<User>> GetLoginUser(string email, string password)
        {
            var user = await _userRepository.LoginUser(email, password);

            return Ok(user);
        }


        [HttpGet]
        [Route("users/{at}")]
        public async Task<ActionResult<User>> GetUser(string at)
        {
            var user = await _userRepository.Get(at);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("users")]
        public async Task<ActionResult> CreateUser(User newUser)
        {

            var user = new User
            {
                UserAt = newUser.UserAt,
                UserName = newUser.UserName,
                UserPassword = newUser.UserPassword,
                UserEmail = newUser.UserEmail,
                JoinDate = DateTime.UtcNow,
            };

            await _userRepository.Add(user);
            return Ok(user);
        }

        [HttpDelete]
        [Route("users/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto userToUpdate)
        {
            User user = new()
            {
                UserId = id,
                Followers = userToUpdate.Followers,
                Following = userToUpdate.Following

            };

            await _userRepository.Update(user);
            return Ok();
        }

    }

}