using System.Text;
using Newtonsoft.Json;
using ProfileMicroservice.RabbitMQ.Interfaces;
using RabbitMQ.Client;

namespace ProfileMicroservice.RabbitMQ;

public class MessageBusClient : IMessageBusClient
{
    private readonly IConfiguration _configuration;
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public MessageBusClient(IConfiguration configuration)
    {
        _configuration = configuration;
        var factory = new ConnectionFactory()
        { 
            HostName = _configuration["RabbitMQ:HostName"], UserName = _configuration["RabbitMQ:UserName"], Password = _configuration["RabbitMQ:Password"]
        };
        try
        {
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            
            _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

            _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
            
            Console.WriteLine("--> Connected to MessageBus");
        }
        catch (Exception e)
        {
            Console.WriteLine($"--> Could not connect to RabbitMQ: {e.Message}");
        }
    }

    public void SendMessage<T>(T message)
    {
        var json = JsonConvert.SerializeObject(message);
        var body = Encoding.UTF8.GetBytes(json);

        _channel.BasicPublish(exchange: "trigger",
            routingKey: "orders",
            basicProperties: null,
            body: body);
        Console.WriteLine($"--> We have sent {message}");
    }

    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine("--> RabbitMQ Connection Shutdown");
    }
}
