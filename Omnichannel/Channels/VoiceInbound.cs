namespace OmniChannel.Channels;

// <summary>
// Twilio voice webhook payload.
// Transcription arrives asynchronously on a second callback
// </summary>
public record VoiceInbound(
    string CallSid,
    string From,
    string CallStatus, // ringing|in-progress|completed
    string? TranscriptionText // null until transcription callback fires
);