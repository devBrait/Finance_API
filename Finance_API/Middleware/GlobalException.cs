namespace Finance_API.Middleware;

public class GlobalException
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalException> _logger;

    public GlobalException(RequestDelegate next, ILogger<GlobalException> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception has occurred.");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        var response = new
        {
            message = "An unexpected error occurred.",
            error = exception.Message
        };

        return context.Response.WriteAsJsonAsync(response);
    }
}
