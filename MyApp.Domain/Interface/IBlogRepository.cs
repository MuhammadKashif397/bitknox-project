using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interface
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllblogAsync();
        Task<Blog> GetblogByIdAsync(int id);
        Task<Blog> CreateBlogAsync(Blog blog);
        Task<int> UpdateBlogAsync(int id, Blog blog);
        Task<int> DeleteBlogAsync(int id);

    }
}
