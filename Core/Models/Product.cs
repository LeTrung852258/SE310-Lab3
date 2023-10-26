using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public required string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
