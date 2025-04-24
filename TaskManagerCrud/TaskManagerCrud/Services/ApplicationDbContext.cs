using Microsoft.EntityFrameworkCore;
using TaskManagerCrud.Models;

namespace TaskManagerCrud.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
            
        }
       public DbSet<TaskModel> Tasks { get; set; }
    }
}
