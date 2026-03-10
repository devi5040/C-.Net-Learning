namespace OmniChannel.Models;

// <summary>
// The single domain object that respresents any inbound message, regardless of channel.
// All downstream code (Queue, orchestrator, services) will work with this unified message.
// </summary>

public class UnifiedMessage
{
    public Guid MessageId { get; init; } = Guid.NewGuid();
    public ChannelType Channel { get; init; }
    public string SenderId { get; init; } = string.Empty;
    public string Body { get; init; } = string.Empty;
    public string? Intent { get; set; }
    public Guid? CorrelationId { get; init; }
    public DateTime ReceivedAt { get; init; } = DateTime.UtcNow;
    public string? SourceRef { get; init; }

    // Flexible extras without polluting the core model
    public Dictionary<string, object> Metadata { get; init; } = new();
    public List<string> Attachments { get; init; } = new();
}