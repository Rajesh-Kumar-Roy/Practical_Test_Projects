using AutoMapper;
using PracticalTest.Entities.Entites;
using PracticalTest.Manager.EntityDtos;

namespace PracticalTest.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<SaleItem, SaleItemDto>().ReverseMap();
        }
    }
}
