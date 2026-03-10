using InventoryService.Models;

namespace InventoryService.Services;

public class InventoryService : IInventoryService
{
    private readonly Dictionary<string, InventoryItem> _items = new();
    private readonly ILogger<InventoryService> _logger;

    public InventoryService(ILogger<InventoryService> logger)
    {
        _logger = logger;

        // Seed some stock
        _items["SKU-001"] = new InventoryItem { ProductSku = "SKU-001", QuantityAvailable = 100 };
        _items["SKU-002"] = new InventoryItem { ProductSku = "SKU-002", QuantityAvailable = 50 };
    }

    public Task<IEnumerable<InventoryItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<InventoryItem>>(_items.Values);
    }

    public Task HandleOrderCreatedAsync(OrderCreatedEvent evt, CancellationToken cancellationToken = default)
    {
        if (_items.TryGetValue(evt.ProductSku, out var item))
        {
            item.QuantityAvailable -= evt.Quantity;
            _logger.LogInformation("Inventory updated for {Sku}. Remaining: {Qty}", item.ProductSku, item.QuantityAvailable);
        }
        else
        {
            _logger.LogWarning("No inventory item found for SKU {Sku}", evt.ProductSku);
        }

        return Task.CompletedTask;
    }
}

