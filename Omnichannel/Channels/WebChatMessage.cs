namespace OmniChannel.Channels;

// <summary>
// message frame from a browser websocket connection
// </summary>

public record WebChatMessage(
    string SessionId,
    string UserId,
    string Text,
    DateTime TimeStamp
);