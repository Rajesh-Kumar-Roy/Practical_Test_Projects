using Dapper;
using Microsoft.Data.SqlClient;
using PracticalTest.Entities.Entites;
using PracticalTest.Repository.Context;
using PracticalTest.Repository.Contract;
using System.Data;

namespace PracticalTest.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IDbConnection _db;
        public SaleRepository(DapperContext context) => _db = context.GetDbConnection();

        public Task<int> AddAsync(Sale entity)
        {
            throw new NotImplementedException();
        }


        public async Task<(int SaleId, int CustomerId)> AddWithCustomerAsync(Sale entity)
        {
            using (var db = _db)
            {


                // Table-valued parameter for SaleItems
                var saleItemsTable = new DataTable();
                saleItemsTable.Columns.Add("ProductId", typeof(int));
                saleItemsTable.Columns.Add("Quantity", typeof(int));
                saleItemsTable.Columns.Add("TotalPrice", typeof(decimal));

                // Populate the table-valued parameter with sale items
                foreach (var item in entity.Items)
                {
                    saleItemsTable.Rows.Add(item.ProductId, item.Quantity, item.TotalPrice);
                }

                // Set up Dapper's DynamicParameters
                var parameters = new DynamicParameters();
                // Customer Info (either existing or new)
                parameters.Add("@CustomerId", entity.Customer.Id == 0 ? null : entity.Customer.Id);
                parameters.Add("@CustomerName", entity.Customer.Name);
                parameters.Add("@CustomerEmail", entity.Customer.Email);
                parameters.Add("@CustomerPhone", entity.Customer.Phone);
                parameters.Add("@CustomerAddress", entity.Customer.Address);

                // Sale info
                parameters.Add("@SaleDate", entity.SaleDate);

                // SaleItems as Table-Valued Parameter (TVP)
                parameters.Add("@SaleItems", saleItemsTable.AsTableValuedParameter("SaleItemType"));

                // Output parameters
                parameters.Add("@NewSaleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@NewCustomerId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Call the stored procedure
                await db.ExecuteAsync("SaveSaleWithCustomer", parameters, commandType: CommandType.StoredProcedure);

                // Retrieve output parameters (SaleId and CustomerId)
                var newSaleId = parameters.Get<int>("@NewSaleId");
                var newCustomerId = parameters.Get<int>("@NewCustomerId");

                return (newSaleId, newCustomerId);
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sale>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Sale> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<SaleDetail> GetSaleDetailByIdAsync(int id)
        {
            using (IDbConnection db = _db)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = await db.QuerySingleOrDefaultAsync<SaleDetail>("GetAllSaleWithCustomerById", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public async Task<List<SaleDetail>> GetSaleDetailsByCustomerNameAsync(string userName)
        {
            using (IDbConnection db = _db)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", userName);
                string storedProcedure = "GetASalesWithCustomerByCustomerUserName";
                var result = await db.QueryAsync<SaleDetail>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<List<SaleDetail>> GetSaleDetailsAsync()
        {
            using (IDbConnection db = _db)
            {
                string storedProcedure = "GetAllSaleWithCustomer";
                var result = await db.QueryAsync<SaleDetail>(storedProcedure, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public Task<int> UpdateAsync(Sale entity)
        {
            throw new NotImplementedException();
        }
    }
}
