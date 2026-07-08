using HealthCare.Api.Events;

namespace HealthCare.Api.Messaging
{
    public interface IRabbitMqPublisher
    {
        Task PublishAsync(
            AppointmentBookedEvent appointmentBookedEvent);
    }
}