using AutoMapper;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;

namespace ShopSystem.Services;

//logic for product
public class ProductService : ApplicationGenericServices<Product, int, ProductItem, ProductOutput, ProductInput, ProductUpdate>, IApplicationServiceAutoRegister
{
    public ProductService(
        IRepository<Product, int> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(repository, unitOfWork, mapper)
    { }

}
