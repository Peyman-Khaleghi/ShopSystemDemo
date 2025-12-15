namespace ShopSystem.Services;

public class ProductItem
{
    public int Id { get; init; }
    public string CategoryName { get; init; }
    public string Name { get; init; }
    public string BrandName { get; init; }
    public string Color { get; init; }
    public string Size { get; init; }
    public decimal Count { get; init; }
    public decimal? Cost { get; init; }
    public string Description { get; init; }
    public bool? HasDiscount { get; init; }
    public string DiscountCode { get; init; }
    public DateTimeOffset? DisCountExpirationDate { get; init; }
}