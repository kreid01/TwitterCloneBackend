using Microsoft.AspNetCore.Mvc;
using TwitterCloneBackend.Models.Comments;
using TwitterCloneBackend.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace TwitterCloneBacked.NameSpace
{

    [ApiController]
    [Route("/")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        [Route("comments/posts/{PostId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetPostsComments(int PostId)
        {
            var comments = _commentRepository.GetByPostId(PostId);

            return Ok(comments);
        }


        [HttpGet]
        [Route("comments/{id}")]
        public async Task<ActionResult<Post>> GetComment(int id)
        {
            var post = await _commentRepository.Get(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        [Route("comments")]
        public async Task<ActionResult> CreateComment(Comment newComment)
        {

            var comment = new Comment
            {
                UserAt = newComment.UserAt,
                PostId = newComment.PostId,
                CommentMedia = newComment.CommentMedia,
                CommentBody = newComment.CommentBody,
                UserName = newComment.UserName,
                UserImg = newComment.UserImg,
                CommentDate = DateTime.UtcNow,
            };

            await _commentRepository.Add(comment);
            return Ok(comment);
        }

        [HttpDelete]
        [Route("comments/{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentRepository.Delete(id);
            return Ok();
        }

        [HttpPut]
        [Route("comments/{id}")]
        public async Task<IActionResult> Updatecomment(int id)
        {
            Comment comment = new()
            {
                Id = id,
            };

            await _commentRepository.Update(comment);
            return Ok();
        }

    }
}
