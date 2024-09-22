using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Entities.Entites
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
