using Microsoft.EntityFrameworkCore;
using TBS.Models;

namespace TBS.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Saurabh", Age = 30, Description = "Developer" },
                new Category { Id = 2, Name = "Anvita", Age = 29, Description = "Professor" },
                new Category { Id = 3, Name = "Surbhit", Age = 28, Description = "Analysist" },
                new Category { Id = 4, Name = "Charu", Age = 29, Description = "Manager" }

                );   
        }
    }
}
