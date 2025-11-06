using Microsoft.EntityFrameworkCore;
using DoCongMinh_api.Models;

namespace DoCongMinh_api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>().Property(p => p.Name).HasMaxLength(200);
        modelBuilder.Entity<Product>().Property(p => p.Description).HasMaxLength(1000);

        // Seed demo (giúp test nhanh)
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Yamaha Sirius", Price = 18000000m, Stock = 10, Description = "Xe số tiết kiệm" },
            new Product { Id = 2, Name = "Honda Vision", Price = 31000000m, Stock = 5, Description = "Tay ga phổ biến" }
        );
    }
}
