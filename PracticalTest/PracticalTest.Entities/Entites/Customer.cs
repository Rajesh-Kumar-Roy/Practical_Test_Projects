using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Entities.Entites
{
    [Table("Customer")]
    public class Customer
    {

        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, MaxLength(255)]
        public string Address { get; set; }
    }
}
