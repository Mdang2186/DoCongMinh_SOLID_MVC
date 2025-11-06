using Microsoft.EntityFrameworkCore;
using DoCongMinh.Models;

namespace DoCongMinh.Data
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

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop Pro",
                    Description = "Laptop cấu hình mạnh cho lập trình",
                    Price = 25000000,
                    Stock = 50 // Đã thêm Stock
                },
                new Product
                {
                    Id = 2,
                    Name = "Bàn phím cơ",
                    Description = "Bàn phím gõ êm, có LED RGB",
                    Price = 1200000,
                    Stock = 150 // Đã thêm Stock
                },
                new Product
                {
                    Id = 3,
                    Name = "Màn hình 4K",
                    Description = "Màn hình 27 inch, 4K sắc nét",
                    Price = 7500000,
                    Stock = 75 // Đã thêm Stock
                }
            );
        }
    }
}