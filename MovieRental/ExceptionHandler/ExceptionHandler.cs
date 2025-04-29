using System;
using System.Net;

namespace MovieRental.ExceptionHandler
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _delegate;
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;

        public ExceptionHandler(RequestDelegate requestDelegate, ILogger<ExceptionHandler> logger, IHostEnvironment environment)
        {
            _delegate = requestDelegate;
            _logger = logger;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _delegate(httpContext);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var response = new ApiExceptionResponse
            {
                Message = _environment.IsDevelopment() ? ex.Message : "Internal Server Error",
                StackTrace = _environment.IsDevelopment() ? ex.StackTrace : null
            };

            await httpContext.Response.WriteAsJsonAsync(response);
        }
    }
}
