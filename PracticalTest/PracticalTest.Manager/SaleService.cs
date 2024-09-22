using AutoMapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;
using PracticalTest.Repository.Contract;

namespace PracticalTest.Manager
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  Task<int> AddAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(SaleDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<(int SaleId, int CustomerId)> AddWithCustomerAsync(SaleDto dto)
        {
            return await _repository.AddWithCustomerAsync(_mapper.Map<Sale>(dto));
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllAsync() => _mapper.Map<List<ProductDto>>(await _repository.GetAllAsync());


        public async Task<ProductDto> GetByIdAsync(int id) => _mapper.Map<ProductDto>(await _repository.GetByIdAsync(id));

        public async Task<SaleDetail> GetSaleDetailByIdAsync(int id)
        {
            return await _repository.GetSaleDetailByIdAsync(id);
        }

        public async Task<List<SaleDetail>> GetSaleDetailsAsync()
        {
            return await _repository.GetSaleDetailsAsync();
        }

        public async Task<List<SaleDetail>> GetSaleDetailsByCustomerNameAsync(string userName)
        {
            return await _repository.GetSaleDetailsByCustomerNameAsync(userName);
        }

        public Task<int> UpdateAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SaleDto entity)
        {
            throw new NotImplementedException();
        }

        Task<List<SaleDto>> IBaseService<SaleDto>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<SaleDto> IBaseService<SaleDto>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
