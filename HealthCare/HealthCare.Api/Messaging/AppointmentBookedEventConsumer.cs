using HealthCare.Api.Events;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HealthCare.Api.Messaging
{
    public class AppointmentBookedEventConsumer : BackgroundService
    {
        private readonly ILogger<AppointmentBookedEventConsumer> _logger;
        private readonly IConfiguration _config;

        private IConnection? _connection;
        private IChannel? _channel;

        public AppointmentBookedEventConsumer(
            ILogger<AppointmentBookedEventConsumer> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        // Called once when the Hosted Service starts
        public override async Task StartAsync(
            CancellationToken cancellationToken)
        {
            var rabbitConfig = _config.GetSection("RabbitMQ");

            var factory = new ConnectionFactory
            {
                HostName = rabbitConfig["HostName"]!,
                Port = int.Parse(rabbitConfig["Port"]!),
                UserName = rabbitConfig["UserName"]!,
                Password = rabbitConfig["Password"]!,
                VirtualHost = rabbitConfig["VirtualHost"]!
            };

            _connection = await factory.CreateConnectionAsync(cancellationToken);
            _channel = await _connection.CreateChannelAsync(null, cancellationToken);

            _logger.LogInformation(
                "AppointmentBookedEventConsumer started. Listening to queue...");

            await base.StartAsync(cancellationToken);
        }

        // Main loop - runs continuously
        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            var queueName =
                _config.GetSection("RabbitMQ")["AppointmentQueue"]!;

            await _channel!.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null,
                cancellationToken: stoppingToken);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (sender, eventArgs) =>
            {
                // Step 1: Read raw bytes
                var body = eventArgs.Body.ToArray();

                // Step 2: Convert bytes to JSON string
                var message = Encoding.UTF8.GetString(body);

                // Step 3: Deserialize JSON to object
                var appointmentEvent =
                    JsonSerializer.Deserialize<AppointmentBookedEvent>(
                        message,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                if (appointmentEvent != null)
                {
                    // Step 4: Process event
                    _logger.LogInformation(
                        "[AUDIT] Appointment Booked | AppointmentId={AppointmentId} | Patient={PatientName} | DoctorId={DoctorId} | Date={ScheduledDate} | Slot={TimeSlot}",
                        appointmentEvent.AppointmentId,
                        appointmentEvent.PatientName,
                        appointmentEvent.DoctorId,
                        appointmentEvent.ScheduledDate,
                        appointmentEvent.TimeSlot);
                }

                // Step 5: Acknowledge message
                await _channel.BasicAckAsync(
                    eventArgs.DeliveryTag,
                    multiple: false);
            };

            await _channel.BasicConsumeAsync(
                queue: queueName,
                autoAck: false,
                consumer: consumer,
                cancellationToken: stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        public override async Task StopAsync(
            CancellationToken cancellationToken)
        {
            if (_channel != null)
                await _channel.CloseAsync();

            if (_connection != null)
                await _connection.CloseAsync();

            await base.StopAsync(cancellationToken);
        }
    }
}