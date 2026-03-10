namespace NotificationService.Models;

public class OrderCreatedEvent
{
    public Guid OrderId { get; set; }
    public string ProductSku { get; set; } = string.Empty;
    public int Quantity { get; set; }
}

