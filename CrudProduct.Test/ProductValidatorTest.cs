using CrudProduct.Models;
using CrudProduct.Validations;
using FluentValidation.TestHelper;

namespace CrudProduct.Test;

public class ProductValidatorTest
{
    private readonly ProductValidator _validator = new ProductValidator();

    [Fact]
    public void Name_WhenEmpty_MustReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "", price = 10 });
        result.ShouldHaveValidationErrorFor(p => p.name);
    }

    [Fact]
    public void Price_WhenZero_MustReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = 0 });
        result.ShouldHaveValidationErrorFor(p => p.price);
    }

    [Fact]
    public void Price_WhenNegative_MustReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = -1 });
        result.ShouldHaveValidationErrorFor(p => p.price);
    }

    [Fact]
    public void Name_WhenTooLong_MustReturnError()
    {
        var result = _validator.TestValidate(new Product { name = new string('a', 101), price = 10 });
        result.ShouldHaveValidationErrorFor(p => p.name);
    }

    [Fact]
    public void Name_WhenValid_ShouldNotReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = 10 });
        result.ShouldNotHaveValidationErrorFor(p => p.name);
    }

    [Fact]
    public void Price_WhenValid_ShouldNotReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = 10 });
        result.ShouldNotHaveValidationErrorFor(p => p.price);
    }

    [Fact]
    public void Description_WhenValid_ShouldNotReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = 10, description = "Valid Description" });
        result.ShouldNotHaveValidationErrorFor(p => p.description);
    }

    [Fact]
    public void RegistrationDate_WhenDefault_ShouldNotReturnError()
    {
        var result = _validator.TestValidate(new Product { name = "Valid Name", price = 10, registrationDate = default });
        result.ShouldNotHaveValidationErrorFor(p => p.registrationDate);
    }
}
