using System.ComponentModel.DataAnnotations;

namespace DoCongMinh.Models
{
    public class Product
    {
        // Yêu cầu: PK, tự tăng (Mặc định của EF Core)
        public int Id { get; set; }

        // Yêu cầu: Required, MinLength 3
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [MinLength(3, ErrorMessage = "Tên sản phẩm phải có ít nhất 3 ký tự")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        // Yêu cầu: > 0
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Giá phải lớn hơn 0")]
        public decimal Price { get; set; }

        // Yêu cầu: >= 0
        [Range(0, int.MaxValue, ErrorMessage = "Tồn kho phải lớn hơn hoặc bằng 0")]
        public int Stock { get; set; }

        // Yêu cầu: Optional
        [StringLength(500)]
        public string? Description { get; set; }
    }
}