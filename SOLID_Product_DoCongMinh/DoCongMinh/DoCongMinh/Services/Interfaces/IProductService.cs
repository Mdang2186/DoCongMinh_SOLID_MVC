using DoCongMinh.Models;

namespace DoCongMinh.Services.Interfaces
{
    // Lớp này chứa logic nghiệp vụ, nói chuyện với Repository
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}