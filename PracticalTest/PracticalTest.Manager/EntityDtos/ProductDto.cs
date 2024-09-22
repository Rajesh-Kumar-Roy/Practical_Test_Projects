using System.ComponentModel.DataAnnotations;

namespace PracticalTest.Manager.EntityDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required.")]
        public decimal Price { get; set; }
    }

}
