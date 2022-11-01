using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Models;
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
                UserImg = newUser.UserImg,
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
                Posts = userToUpdate.Posts,
                Followers = userToUpdate.Followers,
                Following = userToUpdate.Following,
                LikedPosts = userToUpdate.LikedPosts,
                RetweetedPosts = userToUpdate.LikedPosts

            };

            await _userRepository.Update(user);
            return Ok();
        }
    }

}