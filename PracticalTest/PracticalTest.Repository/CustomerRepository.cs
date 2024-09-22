using Dapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Repository.Context;
using PracticalTest.Repository.Contract;
using System.Data;

namespace PracticalTest.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _db;
        public CustomerRepository(DapperContext context) => _db = context.GetDbConnection();

        public Task<int> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            using (IDbConnection db = _db)
            {
                string storedProcedure = "GetCustomersProc";
                var result = await db.QueryAsync<Customer>(storedProcedure, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Invoice>> GetInvoiceDateByUserId(int userId)
        {
            using (IDbConnection db = _db)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", userId);
                string storedProcedure = "GetReportDataProc";
                var result = await db.QueryAsync<Invoice>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<int> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
