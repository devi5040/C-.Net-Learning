using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace OrderService.Messaging;

public class RabbitMqPublisher : IMessagePublisher, IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqPublisher(IConfiguration configuration)
    {
        var factory = new ConnectionFactory
        {
            Uri = new Uri(configuration.GetConnectionString("RabbitMq") ?? "amqp://guest:guest@localhost:5672")
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.ExchangeDeclare(exchange: "orders", type: ExchangeType.Topic, durable: true);
    }

    public Task PublishAsync(string exchange, string routingKey, byte[] body, CancellationToken cancellationToken = default)
    {
        var properties = _channel.CreateBasicProperties();
        properties.ContentType = "application/json";

        _channel.BasicPublish(exchange, routingKey, basicProperties: properties, body: body);
        return Task.CompletedTask;
    }

    public Task PublishJsonAsync<T>(string exchange, string routingKey, T message, CancellationToken cancellationToken = default)
    {
        var json = JsonSerializer.Serialize(message);
        var bytes = Encoding.UTF8.GetBytes(json);
        return PublishAsync(exchange, routingKey, bytes, cancellationToken);
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}

