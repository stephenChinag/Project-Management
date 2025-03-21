using Microsoft.EntityFrameworkCore;
using ProjectManagement.Models;

namespace ProjectManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
  // Configure decimal precision for Price property
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 digits total, 2 decimal places
            
               // Use fixed DateTime values for seeding
            var fixedDate = new DateTime(2025, 1, 1); // Static date for seeding
            
            // Seed some initial data
            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "Laptop", 
                    Description = "High performance laptop",
                    Price = 1299.99m,
                    StockQuantity = 10,
                    CreatedAt = fixedDate
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Smartphone", 
                    Description = "Latest smartphone with amazing features",
                    Price = 799.99m,
                    StockQuantity = 20,
                    CreatedAt = fixedDate
                }
            );
        }
    }
}
