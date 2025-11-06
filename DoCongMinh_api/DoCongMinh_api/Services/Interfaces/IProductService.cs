using DoCongMinh_api.DTOs;

namespace DoCongMinh_api.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync(CancellationToken ct = default);
    Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<ProductDto> CreateAsync(ProductCreateDto dto, CancellationToken ct = default);
    Task<bool> UpdateAsync(int id, ProductUpdateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);

}
