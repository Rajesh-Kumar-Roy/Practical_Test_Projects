namespace PracticalTest.Entities.Entites
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int? Quantity { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
