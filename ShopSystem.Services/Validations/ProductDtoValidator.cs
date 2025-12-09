using FluentValidation;

namespace ShopSystem.Services.Validations;

public class ProductDtoValidator : AbstractValidator<ProductDto>
{
    public ProductDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
        RuleFor(p => p.BrandName).MaximumLength(100);
        RuleFor(p => p.Size).MaximumLength(100);
        RuleFor(p => p.Count).NotEmpty();
    }
}