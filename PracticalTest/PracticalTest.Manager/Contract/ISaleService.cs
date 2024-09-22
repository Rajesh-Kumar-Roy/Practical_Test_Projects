using PracticalTest.Entities.Entites;
using PracticalTest.Manager.EntityDtos;

namespace PracticalTest.Manager.Contract
{
    public interface ISaleService : IBaseService<SaleDto>
    {
        Task<(int SaleId, int CustomerId)> AddWithCustomerAsync(SaleDto dto);
        Task<List<SaleDetail>> GetSaleDetailsAsync();
        Task<SaleDetail> GetSaleDetailByIdAsync(int id);
        Task<List<SaleDetail>> GetSaleDetailsByCustomerNameAsync(string userName);
    }

}
