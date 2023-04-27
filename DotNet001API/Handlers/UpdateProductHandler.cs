using DotNet001API.Commands;
using DotNet001API.Data;
using DotNet001API.Models;
using MediatR;
using Product = DotNet001Shared.Models.Product;

namespace DotNet001API.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        IDataContext _dataContext;
        public UpdateProductHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _dataContext.Products.FirstOrDefault(x => x.Id == request.Id);

            if (product == null)
            {
                return null;
            }else
            {
            
                product.Name = request.Product.Name;
                product.Description = request.Product.Description; 
                product.Category = request.Product.Category;
                product.Price = request.Product.Price;

                await _dataContext.SaveChangesAsync(cancellationToken);

                return request.Product;
            }

        }
    }
}
