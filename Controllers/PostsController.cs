using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Models.Posts;
using TwitterCloneBackend.Models.Users;
using TwitterCloneBackend.Repositories;

namespace TwitterCloneBacked.NameSpace
{

    [ApiController]
    [Route("/")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        [Route("posts")] 
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts([FromQuery] PostPagingParameters postPagingParameters)
        {
            var posts = await _postRepository.GetAll();
            
            var pagedPosts = posts.Skip((postPagingParameters.PageNumber - 1) * postPagingParameters.PageSize).Take(postPagingParameters.PageSize).ToList();


            return Ok(pagedPosts);
        }


        [HttpGet]
        [Route("posts/{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postRepository.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }
       
        [HttpPost]
        [Route("posts")]
        public async Task<ActionResult> CreatePost(Post newPost)
        {

            var post = new Post
            {
                UserAt = newPost.UserAt,
                PostMedia = newPost.PostMedia,
                PostTextBody = newPost.PostTextBody,
                UserName = newPost.UserName,
                UserImg = newPost.UserImg,
                PostDate = DateTime.UtcNow,
                Comments = newPost.Comments,
                PosterId = newPost.PosterId,
                LikeCount = 0,
                RetweetCount = 0
            };

            await _postRepository.Add(post);
            return Ok(post);
        }

        [HttpDelete]
        [Route("posts/{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("posts/{id}")]
        public async Task<IActionResult> UpdatePost(UpdatePostDto postToUpdate)
        {
            Post post = new()
            {
                Id = postToUpdate.Id,
                LikeCount = postToUpdate.LikeCount,
                RetweetCount = postToUpdate.RetweetCount,
                CommentCount = postToUpdate.CommentCount,
                RetweetedBy = postToUpdate.RetweetedBy,
                LikedBy = postToUpdate.LikedBy,
            };

            await _postRepository.Update(post);
            return Ok();
        }

        [HttpGet]
        [Route("posts/users/{userId}")]
        public async Task<IActionResult> GetUsersPosts(int userId, string filterMethod, [FromQuery] PostPagingParameters postPagingParameters)
        {
            var posts = await _postRepository.GetUsersPosts(userId, filterMethod);

            var pagedPosts = posts.Skip((postPagingParameters.PageNumber - 1) * postPagingParameters.PageSize).Take(postPagingParameters.PageSize).ToList();

            return Ok(pagedPosts);
        }

    }

}