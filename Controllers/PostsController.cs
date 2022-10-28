using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.DTOs;
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
        [Route("posts/{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _postRepository.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }
        [HttpGet]
        [Route("posts/{id}")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            var posts = await _postRepository.GetAll();
            return Ok(posts);
        }

        [HttpPost]
        [Route("posts")]
        public async Task<ActionResult> CreatPost([FromBody]PostDTO postDTO)
        {
            var post = new Post
            {
                UserAt = postDTO.UserAt,
                PostTextMedia = postDTO.PostTextMedia,
                PostTextBody = postDTO.PostTextBody,
                PostDate = DateTime.Now,
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
        public async Task<IActionResult> UpdatePost(int id, [FromBody]UpdatePostDTO updatePostDTO)
        {
            Post post = new()
            {
                PostTextBody = updatePostDTO.PostTextBody,
                PostTextMedia = updatePostDTO.PostTextMedia
            };

            await _postRepository.Update(post);
            return Ok();
        }
    }

}