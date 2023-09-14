using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {            
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId=1, CategoryName="Action", DisplayOrder=2},
                new Category() { CategoryId = 2, CategoryName = "Thriller", DisplayOrder = 1 },
                new Category() { CategoryId = 3, CategoryName = "Romance", DisplayOrder = 3 }
                );
        }
    }
}
