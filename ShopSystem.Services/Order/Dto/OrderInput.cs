using ShopSystem.Domain.Models;

namespace ShopSystem.Services;

public class OrderInput
{
    public long Number { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public OrderStatus Status { get; set; }
    public string Description { get; set; }
}