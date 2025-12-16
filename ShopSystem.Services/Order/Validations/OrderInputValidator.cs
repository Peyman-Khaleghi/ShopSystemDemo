using FluentValidation;

namespace ShopSystem.Services.Validations;

public class OrderInputValidator : AbstractValidator<OrderInput>
{
    public OrderInputValidator()
    {
        RuleFor(p => p.Number).NotEmpty().InclusiveBetween(10,20);
        RuleFor(p => p.ProductId).NotEmpty();
        RuleFor(p => p.CustomerId).NotEmpty();
        RuleFor(p => p.Status).NotEmpty();
    }
}