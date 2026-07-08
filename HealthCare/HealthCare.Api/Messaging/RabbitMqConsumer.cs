using HealthCare.Api.Data;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Messaging
{
    public class RabbitMqConsumer : BackgroundService
    {
        private readonly ILogger<RabbitMqConsumer> _logger;
        private readonly IConfiguration _config;
        private readonly IServiceScopeFactory _scopeFactory;

        private IConnection? _connection;
        private IChannel? _channel;

        public RabbitMqConsumer(
            ILogger<RabbitMqConsumer> logger,
            IConfiguration config,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _config = config;
            _scopeFactory = scopeFactory;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            var rabbitConfig = _config.GetSection("RabbitMq");

            var factory = new ConnectionFactory
            {
                HostName = rabbitConfig["HostName"]!,
                Port = int.Parse(rabbitConfig["Port"]!),
                UserName = rabbitConfig["UserName"]!,
                Password = rabbitConfig["Password"]!,
                VirtualHost = rabbitConfig["VirtualHost"]!
            };

            _connection = await factory.CreateConnectionAsync(cancellationToken);
            _channel = await _connection.CreateChannelAsync(cancellationToken: cancellationToken);

            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (_channel == null)
            {
                throw new InvalidOperationException("RabbitMQ channel has not been initialized.");
            }

            var queueName = _config["RabbitMq:HealthCareQueue"]!;

            await _channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (sender, e) =>
            {
                try
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    var appointmentEvent =
                        JsonSerializer.Deserialize<AppointmentBookedEvent>(message);

                    if (appointmentEvent != null)
                    {
                        using var scope = _scopeFactory.CreateScope();

                        var db = scope.ServiceProvider
                            .GetRequiredService<HealthCareDbContext>();

                        var notification = new Notification
                        {
                            UserId = appointmentEvent.DoctorId,

                            Message =
                                $"New appointment booked by {appointmentEvent.PatientName} " +
                                $"for {appointmentEvent.ScheduledDate} at " +
                                $"{appointmentEvent.TimeSlot}",

                            IsRead = false
                        };

                        db.Notifications.Add(notification);

                        await db.SaveChangesAsync(stoppingToken);

                        _logger.LogInformation(
                            "Notification created for DoctorId={DoctorId}",
                            appointmentEvent.DoctorId);
                    }

                    await _channel.BasicAckAsync(
                        deliveryTag: e.DeliveryTag,
                        multiple: false,
                        cancellationToken: stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing RabbitMQ message.");

                    await _channel.BasicNackAsync(
                        deliveryTag: e.DeliveryTag,
                        multiple: false,
                        requeue: true,
                        cancellationToken: stoppingToken);
                }
            };

            await _channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        public override void Dispose()
        {
            _channel?.Dispose();
            _connection?.Dispose();
            base.Dispose();
        }

        public override async Task StopAsync(
    CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Stopping RabbitMQ Consumer...");

            if (_channel != null)
            {
                await _channel.CloseAsync(cancellationToken);
            }

            if (_connection != null)
            {
                await _connection.CloseAsync(cancellationToken);
            }

            await base.StopAsync(cancellationToken);
        }
    }
}