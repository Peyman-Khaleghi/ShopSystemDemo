using AutoMapper;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;

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
        product.Count -= 1;
        await _unitOfWork.CompleteAsync();
    }

}