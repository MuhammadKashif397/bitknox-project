using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interface;
using MyApp.Infrastrusture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastrusture.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext context;
        public BlogRepository(BlogDbContext _context)
        {
            context = _context;
        }
        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            await context.Blogs.AddAsync(blog);
            await context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlogAsync(int id)
        {
            var data = await context.Blogs.FindAsync(id);

            if (data == null)
            {
                return 0;
            }

            context.Blogs.Remove(data);
            await context.SaveChangesAsync();

            return 1;
        }

        public async Task<List<Blog>> GetAllblogAsync()
        {
            var data = await context.Blogs.ToListAsync();
            return data;
        }

        public async Task<Blog> GetblogByIdAsync(int id)
        {
            return await context.Blogs.FindAsync(id);
        }

        public async Task<int> UpdateBlogAsync(int id, Blog blog)
        {
            var data = await context.Blogs.FindAsync(id);

            if (data == null)
            {
                return 0;
            }
            data.Name = blog.Name;
            data.Description = blog.Description;
            data.ImageUrl = blog.ImageUrl;

            await context.SaveChangesAsync();
            return 1;
        }
    }
}
