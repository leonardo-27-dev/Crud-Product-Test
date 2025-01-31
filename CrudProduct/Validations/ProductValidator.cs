using CrudProduct.Models;
using FluentValidation;

namespace CrudProduct.Validations;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.price).GreaterThan(0);
    }
}
