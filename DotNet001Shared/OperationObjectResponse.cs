namespace DotNet001Shared;

public class OperationObjectResponse<T>
{
    public T? Value { get; set; }

    public HttpResponseMessage HttpResponseMessage { get; set; }
}