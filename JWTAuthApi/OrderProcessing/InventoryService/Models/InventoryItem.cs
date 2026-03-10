namespace InventoryService.Models;

public class InventoryItem
{
    public string ProductSku { get; set; } = string.Empty;
    public int QuantityAvailable { get; set; }
}

