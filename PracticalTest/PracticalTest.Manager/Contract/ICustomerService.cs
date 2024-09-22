﻿
using PracticalTest.Entities.Entites;
using PracticalTest.Manager.EntityDtos;

namespace PracticalTest.Manager.Contract
{
    public interface ICustomerService : IBaseService<CustomerDto>
    {
        Task<List<Invoice>> GetInvoiceDateByUserId(int userId);
    }

}
