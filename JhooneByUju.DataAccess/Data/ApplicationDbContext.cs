using JhooneByUju.Models;
using Microsoft.EntityFrameworkCore;

namespace JhooneByUju.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {                
        }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Hand Bags", DisplayOrder = 0 },
                new Category { Id = 2, Name = "Purses", DisplayOrder = 0 },
                new Category { Id = 3, Name = "Belts", DisplayOrder = 0 },
                new Category { Id = 4, Name = "Arts", DisplayOrder = 0 }
                );
        }

    }
}
