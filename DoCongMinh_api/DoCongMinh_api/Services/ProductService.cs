using DoCongMinh_api.DTOs;
using DoCongMinh_api.Mappings;
using DoCongMinh_api.Repositories.Interfaces;

namespace DoCongMinh_api.Services;

public class ProductService(IProductRepository repo) : DoCongMinh_api.Services.Interfaces.IProductService
{
    public async Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default)
        => (await repo.GetAllAsync(ct)).Select(p => p.ToDto()).ToList();

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default)
        => (await repo.GetByIdAsync(id, ct))?.ToDto();

    public async Task<ProductDto> CreateAsync(DTOs.ProductCreateDto dto, CancellationToken ct = default)
    {
        var entity = dto.ToEntity();
        await repo.AddAsync(entity, ct);
        await repo.SaveChangesAsync(ct);
        return entity.ToDto();
    }

    public async Task<bool> UpdateAsync(int id, DTOs.ProductUpdateDto dto, CancellationToken ct = default)
    {
        var entity = await repo.GetByIdAsync(id, ct);
        if (entity is null) return false;
        entity.ApplyUpdate(dto);
        await repo.UpdateAsync(entity, ct);
        await repo.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await repo.GetByIdAsync(id, ct);
        if (entity is null) return false;
        await repo.DeleteAsync(entity, ct);
        await repo.SaveChangesAsync(ct);
        return true;
    }
}
