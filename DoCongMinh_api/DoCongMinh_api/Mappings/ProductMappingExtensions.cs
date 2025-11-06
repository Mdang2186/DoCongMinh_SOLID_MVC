using DoCongMinh_api.DTOs;
using DoCongMinh_api.Models;

namespace DoCongMinh_api.Mappings;

public static class ProductMappingExtensions
{
    public static ProductDto ToDto(this Product p)
        => new(p.Id, p.Name, p.Price, p.Stock, p.Description);

    public static Product ToEntity(this ProductCreateDto dto)
        => new() { Name = dto.Name, Price = dto.Price, Stock = dto.Stock, Description = dto.Description };

    public static void ApplyUpdate(this Product entity, ProductUpdateDto dto)
    {
        entity.Name = dto.Name;
        entity.Price = dto.Price;
        entity.Stock = dto.Stock;
        entity.Description = dto.Description;
    }
}
