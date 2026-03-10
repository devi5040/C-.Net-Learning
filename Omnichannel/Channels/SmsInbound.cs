namespace OmniChannel.Channels;

// <summary>
// The raw payload shape from Twilio/ Vonage sms webhook(http POST).
// Field names match what Twilio actually sends.
// </summary>

public record SmsInbound
(
    string MessageSid, // Twilio unique ID: SMxxxxxxxx
    string From, // Sender's phone number
    string To, // Your Twilio number
    string Body // raw SMS text (max 160 chars/segment)
);