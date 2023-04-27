using System.Net;
using AutoMapper;
using DotNet001API.Data;
using MediatR;
using DotNet001API.Models;
using DotNet001Shared;
using Product = DotNet001Shared.Models.Product;

namespace DotNet001API.Queries
{
    public class GetProductQuery : IRequest<OperationObjectResponse<Product>>
    {
        public int Id { get; set; }

        public class GetProductHandle : IRequestHandler<GetProductQuery, OperationObjectResponse<Product>>
        {

            IDataContext _dataContext;
            private IMapper _mapper;

            public GetProductHandle(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public Task<OperationObjectResponse<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {

                var query = _dataContext.Products.Where(x => x.Id == request.Id).FirstOrDefault();
                var autoMapped = _mapper.Map<Product>(query);

                return Task.FromResult(new OperationObjectResponse<Product>
                {
                    Value = autoMapped,
                    HttpResponseMessage = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK
                    }
                });
            }
        }
    }
}
