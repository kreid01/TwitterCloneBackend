using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using TwitterCloneBacked.NameSpace;
using TwitterCloneBackend.Context;

namespace TwitterCloneBackend.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IDataContext _context;

        public PostRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }
       
        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Posts.FindAsync(id);
            if (itemToDelete == null)
                throw new NullReferenceException();

            _context.Posts.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<Post> Get(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task Update(Post post)
        {
            var itemToUpdate = await _context.Posts.FindAsync(post.Id);
            if (itemToUpdate == null)
                throw new NullReferenceException();

            itemToUpdate.CommentCount = post.CommentCount;
            itemToUpdate.RetweetCount = post.RetweetCount;
            itemToUpdate.LikeCount = post.LikeCount;
            itemToUpdate.RetweetedBy = post.RetweetedBy;
            itemToUpdate.LikedBy = post.LikedBy;
            itemToUpdate.Comments = post.Comments;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetUsersPosts(int userId, string filterMethod)
        {
            var usersPosts = new List<Post>();



            if (filterMethod == "likes")
            {

                var likedPosts = new List<Post>();

                var posts = await _context.Posts.ToListAsync();


                foreach (var post in posts)
                {
                    if (post.LikedBy != null && post.LikedBy.Contains(userId))
                    {
                        likedPosts.Add(post);
                    }
                }

                usersPosts = likedPosts;
            
            } else if(filterMethod == "media")
            {
                usersPosts = await _context.Posts.Where(_ => _.PostMedia.Length > 1).ToListAsync();
            } else if( filterMethod == "replies")
            {
                var retweetedPosts = new List<Post>();

                var posts = await _context.Posts.ToListAsync();


                foreach (var post in posts)
                {
                    if (post.RetweetedBy != null && post.RetweetedBy.Contains(userId))
                    {
                        retweetedPosts.Add(post);
                    }
                }

                usersPosts = retweetedPosts;

            }
             else if(filterMethod == "tweets")
            { 

             usersPosts = await _context.Posts.Where(_ => _.PosterId == userId).ToListAsync();

            }



            return usersPosts;
        }

    }
}
