namespace OmniChannel.Channels;

// <summary>
// Raw payload from sendgrid inbound parse / SMTP email.
// </summary>
public record EmailInbound
(
    string From, // example@gmail.com
    string To,
    string Subject,
    string TextBody, // plain-text part
    string HtmlBody, // Html part
    List<string> AttachmentNames
);