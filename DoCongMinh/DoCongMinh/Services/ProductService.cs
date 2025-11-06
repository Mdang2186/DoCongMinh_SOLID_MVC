using DoCongMinh.Models;
using DoCongMinh.Repositories.Interfaces;
using DoCongMinh.Services.Interfaces;

namespace DoCongMinh.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            // === Logic nghiệp vụ ví dụ ===
            product.Name = product.Name.Trim(); // Luôn chuẩn hóa tên

            if (product.Price < 1000 && product.Stock > 0)
            {
                throw new ArgumentException("Giá không hợp lệ cho sản phẩm có tồn kho.");
            }

            await _repository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            product.Name = product.Name.Trim(); // Logic nghiệp vụ
            await _repository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}