using Microsoft.EntityFrameworkCore;
using DoCongMinh_api.Data;
using DoCongMinh_api.DTOs;
using DoCongMinh_api.Models;
using DoCongMinh_api.Repositories.Interfaces;

namespace DoCongMinh_api.Repositories;

public class ProductRepository(AppDbContext db) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync(CancellationToken ct = default)
        => await db.Products.AsNoTracking().OrderBy(p => p.Id).ToListAsync(ct);

    public async Task<Product?> GetByIdAsync(int id, CancellationToken ct = default)
        => await db.Products.FindAsync([id], ct);

    public async Task AddAsync(Product product, CancellationToken ct = default)
        => await db.Products.AddAsync(product, ct);

    public Task UpdateAsync(Product product, CancellationToken ct = default)
    { db.Products.Update(product); return Task.CompletedTask; }

    public Task DeleteAsync(Product product, CancellationToken ct = default)
    { db.Products.Remove(product); return Task.CompletedTask; }

    public Task<bool> ExistsAsync(int id, CancellationToken ct = default)
        => db.Products.AnyAsync(p => p.Id == id, ct);

    public Task<int> SaveChangesAsync(CancellationToken ct = default)
        => db.SaveChangesAsync(ct);

}
