using FluentValidation;

namespace ShopSystem.Services.Validations;

public class ProductInputValidator : AbstractValidator<ProductInput>
{
    public ProductInputValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
        RuleFor(p => p.BrandName).MaximumLength(100);
        RuleFor(p => p.Size).MaximumLength(100);
        RuleFor(p => p.Count).NotEmpty();
    }
}

//public class ProductUpdateValidator : AbstractValidator<ProductUpdate>
//{
//    public ProductUpdateValidator()
//    {
//        RuleFor(p => p.Name).NotEmpty().MaximumLength(100);
//        RuleFor(p => p.BrandName).MaximumLength(100);
//        RuleFor(p => p.Size).MaximumLength(100);
//        RuleFor(p => p.Count).NotEmpty();
//    }
//}