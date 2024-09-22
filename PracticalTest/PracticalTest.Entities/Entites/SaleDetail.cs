namespace PracticalTest.Entities.Entites
{
    public class SaleDetail
    {
        public int Id { get; set; }           
        public DateTime SaleDate { get; set; }     
        public string Name { get; set; }   
        public string Phone { get; set; }  
        public string Email { get; set; }  
        public int Quantity { get; set; }          
        public decimal TotalPrice { get; set; }    
    }
}
