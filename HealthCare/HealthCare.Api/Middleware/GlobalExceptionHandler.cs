using Microsoft.AspNetCore.Diagnostics;
using HealthCare.Api.Exceptions;
using HealthCare.Shared.DTOs;

namespace HealthCare.Api.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An Unexpected Error Occured: {Message}", exception.Message);

            var (statusCode, message) = exception switch
            {
                // Custom Not Found Exceptions
                PatientNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                DoctorNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                AppointmentNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                HealthRecordNotFoundException => (StatusCodes.Status404NotFound, exception.Message),

                InvalidOperationException => (StatusCodes.Status400BadRequest, exception.Message),

                _ => (StatusCodes.Status500InternalServerError, "Internal server error")
            };

            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                TimeStamp = DateTime.UtcNow,
                Path = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}