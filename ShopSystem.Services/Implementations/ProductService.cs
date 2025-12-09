using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ShopSystem.Domain.Interfaces;
using ShopSystem.Domain.Models;

namespace ShopSystem.Services;

//logic for product
public class ProductService : IAutoServiceRegister
{
    private readonly IRepository<Product, int> _repositoy;
    private readonly IMapper _mapper;

    public ProductService(IRepository<Product, int> repositoy, IMapper mapper)
    {
        _repositoy = repositoy;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var query = _repositoy.Query();

        return await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        Product entity = await _repositoy.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(entity);
    }

    public async Task<int> AddProductAsync(ProductDto dto)
    {
        var newProduct = _mapper.Map<Product>(dto);
        await _repositoy.AddAsync(newProduct);
        return await _repositoy.SaveChangesAsync();
    }

    public async Task UpdateProductAsync(ProductDto dto)
    {
        var newProduct = _mapper.Map<Product>(dto);
        _repositoy.Update(newProduct);
        await _repositoy.SaveChangesAsync();
    }
}
