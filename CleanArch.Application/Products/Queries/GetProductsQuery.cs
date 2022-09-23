using CleanArch.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
