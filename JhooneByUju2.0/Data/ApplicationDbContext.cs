using JhooneByUju2._0.Models;
using Microsoft.EntityFrameworkCore;

namespace JhooneByUju2._0.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {                
        }
        public DbSet<Category> Categories { get; set; }

    }
}
