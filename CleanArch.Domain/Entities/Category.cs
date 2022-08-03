using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public ICollection<Product> Products { get; set; }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id");
            
            Id = id;
            
            ValidateDomain(name);
        }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Name is required");
            
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Minimum 3 characters");

            Name = name;
        }
    }
}
