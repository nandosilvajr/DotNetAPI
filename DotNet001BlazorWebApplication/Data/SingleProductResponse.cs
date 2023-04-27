using System.Text.Json.Serialization;
using DotNet001Shared.Models;

namespace DotNet001BlazorWebApplication.Data;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);


public class SingleProductResponse
{
    [JsonPropertyName("value")]
    public Product Product { get; set; }

    [JsonPropertyName("httpResponseMessage")]
    public HttpResponseMessage HttpResponseMessage { get; set; }
}
