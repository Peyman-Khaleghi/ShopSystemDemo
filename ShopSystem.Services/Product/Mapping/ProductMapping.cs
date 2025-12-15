using AutoMapper;
using ShopSystem.Domain.Models;

namespace ShopSystem.Services.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ProductItem>()
            .ForMember(p => p.CategoryName, config => config.MapFrom(p => p.ProductCategory.Name));
        CreateMap<Product, ProductOutput>()
           .ForMember(p => p.CategoryName, config => config.MapFrom(p => p.ProductCategory.Name));
        CreateMap<ProductInput, Product>();
        CreateMap<ProductUpdate, Product>();
    }
}