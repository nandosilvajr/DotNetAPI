using AutoMapper;
using DotNet001API.Data;
using MediatR;
using Product = DotNet001Shared.Models.Product;
namespace DotNet001API.Queries
{
    public partial record GetProductsQuery
    {
        public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<Product>>
        {
            IDataContext _dataContext;

            IMapper _mapper;
            public GetProductsHandler(IDataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }
            public Task<List<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            {
                var query = _dataContext.Products.Skip(request.Page ?? request.PageDefault).Take(request.PageSize ?? request.PageSizeDefault).AsQueryable();

                if (!string.IsNullOrEmpty(request.Search))
                {
                    query = query.Where(x => x.Name.Contains(request.Search) || x.Description.Contains(request.Search));
                }

                var autoMapped = _mapper.Map<List<Product>>(query);


                return Task.FromResult(autoMapped);
            }
        }

    }
}
