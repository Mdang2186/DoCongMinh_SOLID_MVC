using DoCongMinh.Models;

namespace DoCongMinh.Repositories.Interfaces
{
    // Lớp này chỉ nói chuyện với CSDL
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}