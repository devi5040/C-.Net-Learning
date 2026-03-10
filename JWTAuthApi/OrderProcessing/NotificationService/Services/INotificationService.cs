using NotificationService.Models;

namespace NotificationService.Services;

public interface INotificationService
{
    Task SendOrderCreatedNotificationAsync(OrderCreatedEvent evt, CancellationToken cancellationToken = default);
}

