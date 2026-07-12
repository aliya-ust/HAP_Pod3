using HealthCare.Api.Data;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using MassTransit;

namespace HealthCare.Api.Messaging
{
    public class AppointmentBookedConsumer
        : IConsumer<AppointmentBookedEvent>
    {
        private readonly HealthCareDbContext _context;

        public AppointmentBookedConsumer(
            HealthCareDbContext context)
        {
            _context = context;
        }

        public async Task Consume(
            ConsumeContext<AppointmentBookedEvent> context)
        {
            var message = context.Message;

            var notification = new Notification
            {
                DoctorId = message.DoctorId,
                Message =
                    $"New appointment booked by {message.PatientName} on {message.ScheduledDate} at {message.TimeSlot}",
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);

            await _context.SaveChangesAsync();
        }
    }
}