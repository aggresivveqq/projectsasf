using Microsoft.EntityFrameworkCore;
using BlogApi.Models;
namespace BlogApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<BlogModel> Blog { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        
        }
      
    }
}
