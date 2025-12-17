using Microsoft.AspNetCore.Mvc;
using ShopSystem.Domain.Models;
using ShopSystem.Services;

namespace ShopSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ShopSystemDemoBaseController<Order,Guid,OrderItem,OrderOutput,OrderInput,NoOrderUpdate>
{
    public OrderController(OrderService service):base(service)
    {

    }

    [HttpPost("updateInventory")]
    public async Task<ApiResponse<NoContent>> UpdateInventory([FromBody] OrderInput input)
    {
        var orderService = (OrderService)_service;
        await orderService.AddOrder(input);
        return ApiResponse<NoContent>.Ok(ShopSystem.Api.NoContent.Value);
    }
}
