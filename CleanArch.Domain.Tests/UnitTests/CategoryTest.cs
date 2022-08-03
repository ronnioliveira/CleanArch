using System;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArch.Domain.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValidProperties_ResultValidObject()
        {
            Action action = () => new Category(1, "Category test name");

            action.Should()
                  .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_WithNegativeId_ReturnDomainException()
        {
            Action action = () => new Category(-1, "Category test name");

            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid Id.");
        }

        [Fact]
        public void CreateCategory_WithShortName_ReturnDomainException()
        {
            Action action = () => new Category(1, "Ca");

            action.Should()
                  .Throw<DomainExceptionValidation>()
                  .WithMessage("Invalid name. Minimum 3 characters.");
        }

        [Fact]
        public void CreateCategory_WithEmptyName_ReturnDomainException()
        {
            Action action = () => new Category(1, string.Empty);

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNameLikeASingleSpace_ReturnDomainException()
        {
            Action action = () => new Category(1, " ");

            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullName_ReturnDomainException()
        {
            Action action = () => new Category(1, null);

            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
