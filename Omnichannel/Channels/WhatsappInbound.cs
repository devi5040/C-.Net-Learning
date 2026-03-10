namespace OmniChannel.Channels;

// <summary>
// Whatsapp business api webhook
// </summary>
public record WhatsappInbound(
    string MessageSid,
    string From,
    string To,
    string Body,
    string? MediaUrl // image/document if attached
);