using blog.api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace blog.api.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
    }
}
