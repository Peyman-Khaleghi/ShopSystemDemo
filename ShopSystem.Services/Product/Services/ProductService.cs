using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;

namespace ShopSystem.Services;

//logic for product
public class ProductService : IApplicationServices
{
    private readonly IRepository<Product, int> _repository;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductItem>> GetAllProductsAsync()
    {
        var query = _repository.Query();

        return await query.ProjectTo<ProductItem>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<ProductOutput> GetProductByIdAsync(int id)
    {
        Product entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProductOutput>(entity);
    }

    public async Task<int> AddProductAsync(ProductInput input)
    {
        var newProduct = _mapper.Map<Product>(input);
        await _repository.AddAsync(newProduct);
        return await _repository.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(int id,ProductUpdate update)
    {
        var productToUpdate = await _repository.GetByIdAsync(id);

        if (productToUpdate == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }
        var replaceProduct = _mapper.Map(update, productToUpdate);
        _repository.Update(replaceProduct);
        await _repository.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
        await _repository.SaveChangesAsync();
    }
}
