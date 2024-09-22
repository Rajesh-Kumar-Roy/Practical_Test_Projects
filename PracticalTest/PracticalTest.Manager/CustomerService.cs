using AutoMapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;
using PracticalTest.Repository.Contract;

namespace PracticalTest.Manager
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<int> AddAsync(CustomerDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerDto>> GetAllAsync() => _mapper.Map<List<CustomerDto>>(await _repository.GetAllAsync());

        public Task<CustomerDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Invoice>> GetInvoiceDateByUserId(int userId)
        {
            return await _repository.GetInvoiceDateByUserId(userId);
        }

        public Task<int> UpdateAsync(CustomerDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
