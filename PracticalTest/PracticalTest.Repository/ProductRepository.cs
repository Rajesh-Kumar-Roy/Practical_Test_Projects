using Dapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Repository.Context;
using PracticalTest.Repository.Contract;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PracticalTest.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _db;
        public ProductRepository(DapperContext context) => _db = context.GetDbConnection();

        public async Task<int> AddAsync(Product entity)
        {
            using (IDbConnection db = _db)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Price", entity.Price);
                parameters.Add("@NewId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await db.ExecuteAsync("AddProductProc", parameters, commandType: CommandType.StoredProcedure); 
                int newId = parameters.Get<int>("@NewId");
                return newId; // Return new Product ID
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            using (IDbConnection db = _db)
            {
                string storedProcedure = "GetProductsProc";
                var result = await db.QueryAsync<Product>(storedProcedure, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (IDbConnection db = _db)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var product = await db.QuerySingleOrDefaultAsync<Product>("GetProductByIdProc", parameters, commandType: CommandType.StoredProcedure);
                return product;
            }
        }

        public Task<int> UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
