using OrderService.Messaging;
using OrderService.Models;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = new();
    private readonly ILogger<OrderService> _logger;
    private readonly RabbitMqPublisher _publisher;

    public OrderService(ILogger<OrderService> logger, RabbitMqPublisher publisher)
    {
        _logger = logger;
        _publisher = publisher;
    }

    public async Task<Order> CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        _orders.Add(order);

        var evt = new OrderCreatedEvent
        {
            OrderId = order.Id,
            ProductSku = order.ProductSku,
            Quantity = order.Quantity
        };

        await _publisher.PublishJsonAsync("orders", "orders.created", evt, cancellationToken);

        _logger.LogInformation("Order {OrderId} created and event published", order.Id);

        return order;
    }

    public Task<IEnumerable<Order>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return Task.FromResult<IEnumerable<Order>>(_orders);
    }
}

