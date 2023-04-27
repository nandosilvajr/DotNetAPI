using AutoMapper;
using DotNet001API.Commands;
using DotNet001API.Data;
using DotNet001API.Models;
using MediatR;
using Product = DotNet001Shared.Models.Product;
namespace DotNet001API.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        IDataContext _dataContext;
        private IMapper _mapper;

        public AddProductHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dataContext.Products;

            if (product == null)
            {
                return null;
            }else
            {
                try
                {

                    var automapped = _mapper.Map<DotNet001API.Models.Product>(request.product);
                    await product.AddAsync(automapped);
                    await _dataContext.SaveChangesAsync(cancellationToken);

                    return request.product;
                }
                catch (Exception e)
                {

                    throw;
                }
            }

        }
    }
}
