using AutoMapper;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;

namespace ShopSystem.Services;

//logic for product
public class ProductService : ApplicationGenericServices<Product, int, ProductItem, ProductOutput, ProductInput, ProductUpdate>, IApplicationServiceAutoRegister
{
    private readonly IRepository<Product, int> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(
        IRepository<Product, int> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(repository, unitOfWork, mapper)
    { }


}
