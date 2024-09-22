using PracticalTest.Entities.Entites;

namespace PracticalTest.Repository.Contract
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<(int SaleId, int CustomerId)> AddWithCustomerAsync(Sale entity);
        Task<List<SaleDetail>> GetSaleDetailsAsync();
        Task<SaleDetail> GetSaleDetailByIdAsync(int id);
        Task<List<SaleDetail>> GetSaleDetailsByCustomerNameAsync(string userName);
    }
}
