using HealthCare.Api.Data;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using MassTransit;
using Serilog;

namespace HealthCare.Api.Messaging
{
    public class AppointmentBookedConsumer : IConsumer<AppointmentBookedEvent>
    {
        private readonly HealthCareDbContext _context;
       
        public AppointmentBookedConsumer(HealthCareDbContext context)
        {
            _context = context;

        }

        public async Task Consume(ConsumeContext<AppointmentBookedEvent> context)
        {
            Log.Information("Received AppointmentBookedEvent. AppointmentId={AppointmentId}",context.Message.AppointmentId);
            var message = context.Message;

            var notification = new Notification
            {
                DoctorId = message.DoctorId,
                Message = $"New appointment booked by {message.PatientName} on {message.ScheduledDate} at {message.TimeSlot}.",
                IsRead = false,
                CreatedAtUtc = DateTime.UtcNow
            };

            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();

            Log.Information(
                "Notification created for DoctorId {DoctorId} from AppointmentId {AppointmentId}",
                message.DoctorId,
                message.AppointmentId );
        }
    }
}