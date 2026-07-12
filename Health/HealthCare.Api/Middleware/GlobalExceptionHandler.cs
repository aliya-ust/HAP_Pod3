using HealthCare.Api.Exceptions;
using HealthCare.Api.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace HealthCare.Api.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            // Log business exceptions as Warning
            if (exception is InvalidOperationException)
            {
                _logger.LogWarning(
                    exception,
                    "Business validation failed. RequestId: {RequestId}, Method: {Method}, Path: {Path}",
                    httpContext.TraceIdentifier,
                    httpContext.Request.Method,
                    httpContext.Request.Path);
            }
            else
            {
                // Log unexpected exceptions as Error
                _logger.LogError(
                    exception,
                    "Unhandled exception occurred. RequestId: {RequestId}, Method: {Method}, Path: {Path}",
                    httpContext.TraceIdentifier,
                    httpContext.Request.Method,
                    httpContext.Request.Path);
            }

            var (statusCode, message) = exception switch
            {
                PatientNotFoundException =>
                    (StatusCodes.Status404NotFound, exception.Message),

                DoctorNotFoundException =>
                    (StatusCodes.Status404NotFound, exception.Message),

                AppointmentNotFoundException =>
                    (StatusCodes.Status404NotFound, exception.Message),

                HealthRecordNotFoundException =>
                    (StatusCodes.Status404NotFound, exception.Message),

                InvalidOperationException =>
                    (StatusCodes.Status400BadRequest, exception.Message),

                _ =>
                    (StatusCodes.Status500InternalServerError, "Internal server error")
            };

            var response = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = message,
                TimeStamp = DateTime.UtcNow,
                Path = httpContext.Request.Path
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}