using ShopSystem.Services.Exceptions;

namespace ShopSystem.Api.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BusinessException ex)
        {
            _logger.LogWarning(ex, ex.Message);

            context.Response.StatusCode = ex.StatusCode;

            var response = ApiResponse<object>.Fail(new ApiError
            {
                Code = ex.ErrorCode,
                Message = ex.Message
            });

            await context.Response.WriteAsJsonAsync(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = ApiResponse<object>.Fail(new ApiError
            {
                Code = "INTERNAL_ERROR",
                Message = "Internal server error"
            });

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}

