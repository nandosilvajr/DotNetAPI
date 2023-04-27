using System.Net;
using AutoMapper;
using DotNet001API.Data;
using DotNet001API.Models;
using DotNet001Shared;
using MediatR;
using Product = DotNet001Shared.Models.Product;
namespace DotNet001API.Queries
{
    public class GetProductsQuery : IRequest<LocalResponse<Product>>
    {
        public string? Search { get; set; }
        public bool? IsDeleted { get; set; }

        public int? Page { get; set; } 
        public int? PageSize { get; set; }

        public int PageDefault = 0;

        public int PageSizeDefault = 1;

        public class GetProductsHandler : IRequestHandler<GetProductsQuery, LocalResponse<Product>>
        {
            IDataContext _dataContext;

            IMapper _mapper;
            public GetProductsHandler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public Task<LocalResponse<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var query = _dataContext.Products.Skip(request.Page ?? request.PageDefault).Take(request.PageSize ?? request.PageSizeDefault).AsQueryable();

                if (!string.IsNullOrEmpty(request.Search))
                {
                    query = query.Where(x => x.Name.Contains(request.Search) || x.Description.Contains(request.Search));
                }

                var autoMapped = _mapper.Map<List<Product>>(query);


                return Task.FromResult(new LocalResponse<Product>
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
