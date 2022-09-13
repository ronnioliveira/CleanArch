using System;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Tests.UnitTests
{
    public class ProductTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11, 33, "Product Image");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNegativeIdValue_ReturnDomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 11, 33, "Product Image");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid id value");
        }


        [Fact]
        public void CreateProduct_WithShortNameValue_ReturnDomainExceptionShortName()
        {
            Action action = () => new Product(1, "P", "Product Description", 11, 33, "Product Image");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_WithLongImageName_ReturnDomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11, 33, "Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image Product Image ");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_ReturnNoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11, 33, null);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_ReturnNoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11, 33, string.Empty);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidStockValue_ReturnDomainExceptionInvalidStockValue()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 11, -3, "");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid stock value");
            ;
        }

        [Fact]
        public void CreateProduct_InvalidPrice_ReturnDomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 33, "");

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid price value");
            ;
        }
    }
}
