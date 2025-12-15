using Microsoft.AspNetCore.Mvc;
using ShopSystem.Domain.Models;
using ShopSystem.Infrastructure;
using ShopSystem.Services;

namespace ShopSystem.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(IRepository<Product, int> repository, ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductItem>> GetAll()
    {
        return await _service.GetAllProductsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ProductOutput> Get(int id)
    {
        return await _service.GetProductByIdAsync(id);
    }

    [HttpPost]
    public async Task<int> Create(ProductInput product)
    {
        return await _service.AddProductAsync(product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductUpdate product)
    {
        //if (id != product.Id) return BadRequest();
        await _service.UpdateProductAsync(id,product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }


}
