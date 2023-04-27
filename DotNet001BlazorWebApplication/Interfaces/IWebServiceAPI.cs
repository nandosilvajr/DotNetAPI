using DotNet001BlazorWebApplication.Data;
using DotNet001BlazorWebApplication.Pages;
using DotNet001Shared;
using DotNet001Shared.Models;
using Refit;

namespace DotNet001BlazorWebApplication.Interfaces
{
    public interface IWebServiceAPI
    {
        [Get("/api/getproducts")]
        public Task<ProductResponse> GetProducts();

        [Get("/api/getproducts/{id}")]
        public Task<SingleProductResponse> GetProductById(int id);

        [Put("/updateproducts/{id}")]
        public Task<Product> UpdateProducts(int id);
    }
}
