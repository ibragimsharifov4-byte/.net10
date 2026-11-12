namespace WebApi.Requests;

public class RequestLoggingMiddleWare
{
    private readonly RequestDelegate _next;
    public RequestLoggingMiddleWare(RequestDelegate request)
    {
        _next = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        System.Console.WriteLine($"Request: {context.Request.Path}");
        await _next(context);
        System.Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}
