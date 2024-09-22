using AutoMapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Manager.Contract;
using PracticalTest.Manager.EntityDtos;
using PracticalTest.Repository.Contract;

namespace PracticalTest.Manager
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ProductDto entity)
        {
            var product = _mapper.Map<Product>(entity);
            return await _repository.AddAsync(product);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllAsync() => _mapper.Map<List<ProductDto>>(await _repository.GetAllAsync());


        public async Task<ProductDto> GetByIdAsync(int id) => _mapper.Map<ProductDto>(await _repository.GetByIdAsync(id));

        public Task<int> UpdateAsync(ProductDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
