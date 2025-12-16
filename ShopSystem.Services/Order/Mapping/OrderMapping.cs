using AutoMapper;
using ShopSystem.Domain.Models;

namespace ShopSystem.Services.Mapping;

public class OrderMapping : Profile
{
    public OrderMapping()
    {
        CreateMap<Order, OrderItem>()
            .ForMember(p => p.ProductName, config => config.MapFrom(p => p.Product.Name))
            .ForMember(p => p.CustomerName, config => config.MapFrom(p => p.Customer.FullName));
        CreateMap<Order, OrderOutput>()
            .ForMember(p => p.ProductName, config => config.MapFrom(p => p.Product.Name))
            .ForMember(p => p.CustomerName, config => config.MapFrom(p => p.Customer.FullName));
        CreateMap<OrderInput, Order>()
            .ForMember(p => p.Status, config => config.MapFrom(p => OrderStatus.Processing));
    }
}