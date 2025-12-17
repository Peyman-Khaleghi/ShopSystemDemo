using AutoMapper;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;
using ShopSystem.Services.Exceptions;

namespace ShopSystem.Services;

//logic for order
public class OrderService : ApplicationGenericServices<Order, Guid, OrderItem, OrderOutput, OrderInput, NoOrderUpdate>, IApplicationServiceAutoRegister
{
    private readonly IRepository<Order, Guid> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(
        IRepository<Order, Guid> repository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
        : base(repository, unitOfWork, mapper)
    { }
    public async Task AddOrder(OrderInput input)
    {
        var order = _mapper.Map<Order>(input);
        await _repository.AddAsync(order);
        var productRepo = _unitOfWork.GetRepository<Product, int>();
        var product = await productRepo.GetByIdAsync(input.ProductId);
        if (product.Count < 1)
            throw new BusinessRuleException("Product count is not enough!");
        product.Count -= 1;
        await _unitOfWork.CompleteAsync();
    }

}