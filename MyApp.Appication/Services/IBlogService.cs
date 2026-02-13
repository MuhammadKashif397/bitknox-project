using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllblogAsync();
        Task<Blog> GetblogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync(int id, Blog blog);
        Task<int> DeleteBlogAsync(int id);
    }
}
