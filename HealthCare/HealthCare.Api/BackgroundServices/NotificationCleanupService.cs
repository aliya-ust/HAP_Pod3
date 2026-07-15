using HealthCare.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Api.BackgroundServices
{
    public class NotificationCleanupService : BackgroundService
    {
        private readonly ILogger<NotificationCleanupService> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificationCleanupService(
            ILogger<NotificationCleanupService> logger,
            IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationCleanupService started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);

                    if (stoppingToken.IsCancellationRequested)
                        break;

                    await CleanupOldNotifications(stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            _logger.LogInformation("NotificationCleanupService stopped.");
        }

        private async Task CleanupOldNotifications(CancellationToken ct)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<HealthCareDbContext>();

                var cutoff = DateTime.UtcNow.AddDays(-30);

                var deletedCount = await dbContext.Notifications
                    .Where(n => n.CreatedDate < cutoff)
                    .ExecuteDeleteAsync(ct);

                if (deletedCount > 0 && _logger.IsEnabled(LogLevel.Information))
                    _logger.LogInformation(
                        "Deleted {Count} notification(s) older than {Cutoff:yyyy-MM-dd}.",
                        deletedCount, cutoff);
            }
        }
    }
}
