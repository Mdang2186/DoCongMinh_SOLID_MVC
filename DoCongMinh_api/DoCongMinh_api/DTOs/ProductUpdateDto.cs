using System.ComponentModel.DataAnnotations;

namespace DoCongMinh_api.DTOs;

public class ProductUpdateDto
{
    [Required, MinLength(3), MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }
}
