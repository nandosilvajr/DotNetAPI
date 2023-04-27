using System.Text.Json.Serialization;
using DotNet001Shared.Models;

namespace DotNet001BlazorWebApplication.Data;

public class Content
{
    [JsonPropertyName("headers")]
    public List<object> Headers { get; set; }
}

public class HttpResponseMessage
{
    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("content")]
    public Content Content { get; set; }

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("reasonPhrase")]
    public string ReasonPhrase { get; set; }

    [JsonPropertyName("headers")]
    public List<object> Headers { get; set; }

    [JsonPropertyName("trailingHeaders")]
    public List<object> TrailingHeaders { get; set; }

    [JsonPropertyName("requestMessage")]
    public object RequestMessage { get; set; }

    [JsonPropertyName("isSuccessStatusCode")]
    public bool IsSuccessStatusCode { get; set; }
}

public class ProductResponse
{
    [JsonPropertyName("value")]
    public List<Product> Value { get; set; }

    [JsonPropertyName("httpResponseMessage")]
    public HttpResponseMessage HttpResponseMessage { get; set; }
}

