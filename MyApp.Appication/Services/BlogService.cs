using MyApp.Domain.Entities;
using MyApp.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
          _blogRepository = blogRepository;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
           return await _blogRepository.CreateBlogAsync(blog);
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            
            return await _blogRepository.DeleteBlogAsync(id);
        }

        public async Task<List<Blog>> GetAllblogAsync()
        {
            return await _blogRepository.GetAllblogAsync();
        }

        public async Task<Blog> GetblogByIdAsync(int id)
        {
            
            return await _blogRepository.GetblogByIdAsync(id);
        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            
            return await _blogRepository.UpdateBlogAsync(id, blog);
        }
    }
}
