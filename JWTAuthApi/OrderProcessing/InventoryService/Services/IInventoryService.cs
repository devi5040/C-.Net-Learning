using InventoryService.Models;

namespace InventoryService.Services;

public interface IInventoryService
{
    Task HandleOrderCreatedAsync(OrderCreatedEvent evt, CancellationToken cancellationToken = default);
    Task<IEnumerable<InventoryItem>> GetAllAsync(CancellationToken cancellationToken = default);
}

