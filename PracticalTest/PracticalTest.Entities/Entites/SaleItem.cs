using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Entities.Entites
{
    [Table("SaleItem")]
    public class SaleItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
