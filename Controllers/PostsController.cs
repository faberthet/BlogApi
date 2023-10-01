using blog.api.Data;
using blog.api.Models.DTO;
using blog.api.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly BlogDbContext dbContext;

        public PostsController(BlogDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts() {
            var posts = await dbContext.Posts.ToListAsync();
            return Ok(posts);
        
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var post = await dbContext.Posts.SingleOrDefaultAsync(x => x.Id==id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);

        }
        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostRequest addPostRequest)
        {
            var post = new Post()
            {
                Title = addPostRequest.Title,
                CategoryId = addPostRequest.CategoryId,
                Content = addPostRequest.Content,
                summary=addPostRequest.summary,
                Visible=addPostRequest.Visible,
                Author=addPostRequest.Author,
                FeaturedImageUrl=addPostRequest.FeaturedImageUrl,
                PublishDate=addPostRequest.PublishDate,
                UpdatedDate=addPostRequest.UpdatedDate,
            };
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPostById), new { post.Id }, post);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, UpdateRequest updatePostRequest)
        {
           
            var post = await dbContext.Posts.FindAsync(id);
            if (post != null) {
                post.Title = updatePostRequest.Title;
                post.CategoryId = updatePostRequest.CategoryId;
                post.Content = updatePostRequest.Content;
                post.summary = updatePostRequest.summary;
                post.Visible = updatePostRequest.Visible;
                post.Author = updatePostRequest.Author;
                post.FeaturedImageUrl = updatePostRequest.FeaturedImageUrl;
                post.PublishDate = updatePostRequest.PublishDate;
                post.UpdatedDate = updatePostRequest.UpdatedDate;
                await dbContext.SaveChangesAsync();
                return Ok(post);
            }
            return NotFound();

        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            var post = await dbContext.Posts.FindAsync(id);
            if(post != null)
            {
               dbContext.Remove(post);
               await dbContext.SaveChangesAsync();
                return Ok(post);
            }
            return NotFound();
        }
       
    }
}
