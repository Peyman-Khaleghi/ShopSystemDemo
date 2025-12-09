using Microsoft.AspNetCore.Mvc;
using ShopSystem.Domain.Interfaces;
using ShopSystem.Domain.Models;
using ShopSystem.Services;

namespace ShopSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IRepository<Product, int> _repository;
    private readonly ProductService _service;

    public ProductController(IRepository<Product, int> repository, ProductService service)
    {
        _repository = repository;
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        return await _service.GetAllProductsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await _service.GetProductByIdAsync(id);
    }

    [HttpPost]
    public async Task<int> Create(ProductDto product)
    {
        return await _service.AddProductAsync(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductDto product)
    {
        if (id != product.Id) return BadRequest();
        await _service.UpdateProductAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.Delete(id);
        await _repository.SaveChangesAsync();
        return NoContent();
    }


}
