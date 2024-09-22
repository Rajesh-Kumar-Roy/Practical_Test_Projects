﻿
using PracticalTest.Entities.Entites;

namespace PracticalTest.Repository.Contract
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Invoice>> GetInvoiceDateByUserId(int userId);
    }
}
