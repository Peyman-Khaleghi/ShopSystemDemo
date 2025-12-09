using AutoMapper;
using ShopSystem.Domain.Models;

namespace ShopSystem.Services.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductDto, Product>();
            //.ForMember(p => p.Id , config => config.MapFrom(p =>new Random().Next()))
    }
}