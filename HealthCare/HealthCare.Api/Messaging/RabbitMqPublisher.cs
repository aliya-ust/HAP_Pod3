using HealthCare.Api.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Messaging
{
    public class RabbitMqPublisher : IRabbitMqPublisher,IDisposable
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;
        private string _queueName;

        public RabbitMqPublisher(IConfiguration config)
        {
            var rabbitConfig = config.GetSection("RabbitMq");

            var factory = new ConnectionFactory
            {
                HostName = rabbitConfig["HostName"]!,
                Port = int.Parse(rabbitConfig["Port"]!),
                UserName = rabbitConfig["UserName"]!,
                Password = rabbitConfig["Password"]!,
                VirtualHost = rabbitConfig["VirtualHost"]!
            };

            _queueName = rabbitConfig["HealthCareQueue"]!;
            _connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            _channel = _connection.CreateChannelAsync().GetAwaiter().GetResult();

            _channel.QueueDeclareAsync(
                queue: _queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null).GetAwaiter().GetResult();
        }

        public async Task PublishAsync(AppointmentBookedEvent appointmentBookedEvent)
        {
            var message = JsonSerializer.Serialize(appointmentBookedEvent);
            var body = Encoding.UTF8.GetBytes(message);
            var properties = new BasicProperties { Persistent = true };

            await _channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: _queueName,
                mandatory: false,
                basicProperties: properties,
                body: body);
        }
        public void Dispose()
        {
            _connection.Dispose();
            _channel.Dispose();
        }
    }
}
