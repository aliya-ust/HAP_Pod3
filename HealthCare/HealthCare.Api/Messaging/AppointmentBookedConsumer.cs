using HealthCare.Api.Data;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using MassTransit;

namespace HealthCare.Api.Consumers
{
    public class AppointmentBookedConsumer :
        IConsumer<AppointmentBookedEvent>
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

            var notification = new Notification
            {
                DoctorId = message.DoctorId,
                Message =
                    $"New appointment booked by {message.PatientName} " +
                    $"for {message.ScheduledDate} at {message.TimeSlot}",
                IsRead = false
            };

            _context.Notifications.Add(notification);

            await _context.SaveChangesAsync();


            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    "Notification created for DoctorId={DoctorId}",
                    message.DoctorId);
            }

        }
    }
}