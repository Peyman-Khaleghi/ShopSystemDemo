using Microsoft.AspNetCore.Mvc;
using ShopSystem.Api;
using ShopSystem.Domain.Models;
using ShopSystem.Services;

[ApiController]
[Route("api/[controller]")]
public abstract class ShopSystemDemoBaseController<TEntity, TId, TItem, TOutput, TInput, TUpdate> : ControllerBase
    where TEntity : class, IBaseEntity<TId>
{
    internal readonly IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate> _service;

    public ShopSystemDemoBaseController(IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ApiResponse<IEnumerable<TItem>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return ApiResponse<IEnumerable<TItem>>.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<TOutput>> GetById(TId id)
    {
        var result = await _service.GetByIdAsync(id);
        return ApiResponse<TOutput>.Ok(result);
    }

    [HttpPost]
    public async Task<ApiResponse<TId>> Create([FromBody] TInput input)
    {
        var newId = await _service.AddAsync(input);
        return ApiResponse<TId>.Ok(newId);
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse<NoContent>> Update(TId id, [FromBody] TUpdate update)
    {
        await _service.UpdateAsync(id, update);
        return ApiResponse<NoContent>.Ok(ShopSystem.Api.NoContent.Value);
    }

    [HttpDelete("{id}")]
    public async Task<ApiResponse<NoContent>> Delete(TId id)
    {
        await _service.DeleteAsync(id);
        return ApiResponse<NoContent>.Ok(ShopSystem.Api.NoContent.Value);
    }
}