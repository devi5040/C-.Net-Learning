using NotificationService.Models;

namespace NotificationService.Services;

public class NotificationService : INotificationService
{
    private readonly ILogger<NotificationService> _logger;

    public NotificationService(ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public Task SendOrderCreatedNotificationAsync(OrderCreatedEvent evt, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Sending notification for Order {OrderId}: {Quantity} x {Sku}", evt.OrderId, evt.Quantity, evt.ProductSku);
        return Task.CompletedTask;
    }
}

