using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "An Unexpected Error Occured:{Message}", exception.Message);


            var (statusCode, message) = exception switch
            {
                PatientNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                DoctorNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                AppointmentNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                HealthRecordNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                DbUpdateException => (StatusCodes.Status500InternalServerError, exception.Message),

                _ => (StatusCodes.Status500InternalServerError, "Internal server error")
            };

            var response = new ErrorResponseDto
            {
                StatusCode = statusCode,
                Message = message,
                TimeStamp = DateTime.UtcNow,
                Path = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(response);

            return true;
        }

    }
}