using ShopSystem.Domain.Models;

namespace ShopSystem.Services;

public class OrderItem
{
    public Guid Id { get; set; }
    public long Number { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public OrderStatus Status { get; set; }
    public string Description { get; set; }
}