using HealthCare.Api.Exceptions;
using HealthCare.Shared.DTOs;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
            _logger.LogError(exception, "An Unexpected Error Occurred:{Message}", exception.Message);


            var (statusCode, message) = exception switch
            {
                PatientNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                DoctorNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                AppointmentNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                HealthRecordNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                UserNotFoundException => (StatusCodes.Status404NotFound, exception.Message),
                NoAvailableSlotsException => (StatusCodes.Status404NotFound, exception.Message),

                ClaimNotFoundException => (StatusCodes.Status401Unauthorized, exception.Message),
                InvalidLoginException => (StatusCodes.Status401Unauthorized, exception.Message),
                UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, exception.Message),

                RoleNotAssignedException => (StatusCodes.Status403Forbidden, exception.Message),

                PastAppointmentException => (StatusCodes.Status400BadRequest, exception.Message),
                InvalidRoleException => (StatusCodes.Status400BadRequest, exception.Message),
                IdentityOperationException => (StatusCodes.Status400BadRequest, exception.Message),
                InvalidOperationException => (StatusCodes.Status400BadRequest, exception.Message),

                EmailAlreadyInUseException => (StatusCodes.Status409Conflict, exception.Message),
                SlotAlreadyBookedException => (StatusCodes.Status409Conflict, exception.Message),

                DbHandleException => (StatusCodes.Status500InternalServerError, exception.Message),
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

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }

    }
}