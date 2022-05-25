using System.Text;
using KrabbelMicroservice.RabbitMQ.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace KrabbelMicroservice.RabbitMQ;

public class MessageBusSubscriber : BackgroundService
{
    private readonly IConfiguration _configuration;
    private readonly IEventProcessor _eventProcessor;
    private IConnection _connection;
    private IModel _channel;
    private string queueName;

    public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
    {
        _configuration = configuration;
        _eventProcessor = eventProcessor;
        InitializeServiceBus();
    }

    private void InitializeServiceBus()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost", UserName = "guest", Password = "Pimpas123"
        };
        
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare("trigger", ExchangeType.Fanout);
        queueName = _channel.QueueDeclare("orders", durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null).QueueName;
        _channel.QueueBind(queueName, "trigger", "orders");
        Console.WriteLine("--> Listening on RabbitMQ...");
        
        _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();
        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (ModuleHandle, ea) =>
        {
            Console.WriteLine("--> Event received!");

            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            _eventProcessor.ProcessEvent(message);
        };
        _channel.BasicConsume(queueName, true, consumer);
        return Task.CompletedTask;
    }
    
    public override void Dispose()
    {
        Console.WriteLine("RabbitMQ disposed");
        if (_channel.IsOpen)
        {
            _channel.Close();
            _connection.Close();
        }

        base.Dispose();
    }

    private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        Console.WriteLine("Connection shutdown");
    }
}
