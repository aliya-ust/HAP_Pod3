using HealthCare.Api.Data;
using HealthCare.Api.Models;
using HealthCare.Shared.Events;
using MassTransit;

namespace HealthCare.Api.Consumers
{
    public class AppointmentBookedConsumer : IConsumer<AppointmentBookedEvent>
    {
        private readonly ILogger<AppointmentBookedConsumer> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public AppointmentBookedConsumer(
            ILogger<AppointmentBookedConsumer> logger,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task Consume(ConsumeContext<AppointmentBookedEvent> context)
        {
            var message = context.Message;

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation(
                    "Processing AppointmentBooked: {AppointmentId} for Doctor {DoctorId}",
                    message.AppointmentId, message.DoctorId);

            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<HealthCareDbContext>();

                var notification = new Notification
                {
                    UserId = message.DoctorId.ToString(),
                    Message = $"New appointment booked by {message.PatientName} on {message.ScheduledDate:yyyy-MM-dd} at {message.TimeSlot}.",
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                dbContext.Notifications.Add(notification);
                await dbContext.SaveChangesAsync(context.CancellationToken);
            }

            if (_logger.IsEnabled(LogLevel.Information))
                _logger.LogInformation(
                    "Notification created for Appointment {AppointmentId}",
                    message.AppointmentId);
        }
    }
}
