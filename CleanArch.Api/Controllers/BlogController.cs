using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
using System.Transactions;

namespace CleanArch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAllblogAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogService.GetblogByIdAsync(id);
            if (blog == null)
                return NotFound();

            return Ok(blog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog)
        {
            var createdBlog = await _blogService.CreateBlogAsync(blog);

            return CreatedAtAction(
                nameof(GetBlogById),
                new { id = createdBlog.Id },
                createdBlog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, Blog updatedBlog)
        {
            var result = await _blogService.UpdateBlogAsync(id, updatedBlog);
            if (result == 0)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _blogService.DeleteBlogAsync(id);
            if (result == 0)
                return NotFound();

            return Ok();
        }
    }
}
