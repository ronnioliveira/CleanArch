using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            var products = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            var product = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task CreateAsync(ProductDTO productDto)
        {
            var productCreate = _mapper.Map<ProductCreateCommand>(productDto);

            await _mediator.Send(productCreate);
        }

        public async Task UpdateAsync(ProductDTO productDto)
        {
            var productUpdate = _mapper.Map<ProductUpdateCommand>(productDto);

            await _mediator.Send(productUpdate);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemove = new ProductRemoveCommand(id.Value);

            if (productRemove == null)
                throw new ApplicationException("Could not load product to remove.");

            await _mediator.Send(productRemove);
        }
    }
}
