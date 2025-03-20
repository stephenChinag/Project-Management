
// Models/DTOs/CreateProductDto.cs
using System.ComponentModel.DataAnnotations;

// namespace ProductApi.Models.DTOs
namespace ProjectManagement.Models.DTOs
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; } = 0;
    }
}