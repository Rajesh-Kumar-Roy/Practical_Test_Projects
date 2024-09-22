using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Entities.Entites
{
    [Table("Sale")]
    public class Sale
    {
        public int Id { get; set; }
        [Required]
        public DateTime SaleDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<SaleItem> Items { get; set; }
    }
}
