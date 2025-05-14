using System.Net;
using System.Text.Json;


namespace BE_ECommerce.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // tiếp tục middleware pipeline
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ An unhandled exception occurred: {Message}", ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    success = false,
                    message = "Có lỗi xảy ra",
                    detail = ex.Message // Có thể ẩn trong Production
                };

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
