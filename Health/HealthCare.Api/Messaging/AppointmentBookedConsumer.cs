using HealthCare.Api.Data;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace HealthCare.Api.Messaging
{
    public class AppointmentBookedConsumer : IConsumer<AppointmentBookedEvent>
    {
        private readonly HealthCareDbContext _context;
        private readonly ILogger<AppointmentBookedConsumer> _logger;

        public AppointmentBookedConsumer(
            HealthCareDbContext context,
            ILogger<AppointmentBookedConsumer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Consume(
            ConsumeContext<AppointmentBookedEvent> context)
        {
            var message = context.Message;

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                "Received AppointmentBookedEvent for AppointmentId: {AppointmentId}, DoctorId: {DoctorId}",
                message.AppointmentId,
                message.DoctorId);
            }
            

            var notification = new Notification
            {
                DoctorId = message.DoctorId,
                Message = $"New appointment booked by {message.PatientName} on {message.ScheduledDate} at {message.TimeSlot}",
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);

            await _context.SaveChangesAsync();

            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                "Notification created successfully for DoctorId: {DoctorId} for AppointmentId: {AppointmentId}",
                message.DoctorId,
                message.AppointmentId);
            }
            
        }
    }
}