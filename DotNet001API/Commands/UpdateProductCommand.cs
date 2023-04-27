using DotNet001API.Models;
using MediatR;
using Product = DotNet001Shared.Models.Product;

namespace DotNet001API.Commands
{
    public record UpdateProductCommand(Product Product, int Id) : IRequest<Product>;

}
