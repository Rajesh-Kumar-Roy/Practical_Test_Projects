using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace PracticalTest.Repository.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration) => _configuration = configuration;

        public IDbConnection GetDbConnection() => new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);

    }
}
