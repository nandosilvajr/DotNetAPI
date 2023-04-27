using MediatR;

namespace DotNet001API.Commands
{
    public record DeleteProductCommand(int id) : IRequest;
    
}
