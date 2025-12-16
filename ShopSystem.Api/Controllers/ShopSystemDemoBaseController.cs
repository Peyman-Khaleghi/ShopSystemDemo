using Microsoft.AspNetCore.Mvc;
using ShopSystem.Domain.Models;
using ShopSystem.Services;

[ApiController]
[Route("api/[controller]")]
public abstract class ShopSystemDemoBaseController<TEntity, TId,TItem,TOutput,TInput, TUpdate> : ControllerBase
    where TEntity : class, IBaseEntity<TId>
{
    internal readonly IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate> _service;

    public ShopSystemDemoBaseController(IApplicationGenericServices<TEntity, TId, TItem, TOutput, TInput, TUpdate> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TItem>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TOutput>> GetById(TId id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<TId>> Create([FromBody] TInput input)
    {
        var newId = await _service.AddAsync(input);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(TId id, [FromBody] TUpdate update)
    {
        await _service.UpdateAsync(id, update);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(TId id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}