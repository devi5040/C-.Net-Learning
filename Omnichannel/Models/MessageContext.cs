namespace OmniChannel.Models;

// <summary>
// Enriched contexts handed to business services.
// Wraps the raw unified message plus customer or session data loaded by the orchestrator.
// </summary>

public class MessageContext
{
    public UnifiedMessage Message { get; init; } = null!;
    public string CustomerName { get; init; } = "Unknown";
    public string? AccountId { get; init; }
    public bool IsReturningUser { get; init; }
    public List<string> ConversationHistory { get; init; } = new();
}