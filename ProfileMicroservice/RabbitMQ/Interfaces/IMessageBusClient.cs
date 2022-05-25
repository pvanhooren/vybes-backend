namespace ProfileMicroservice.RabbitMQ.Interfaces;

public interface IMessageBusClient
{
    void SendMessage<T> (T message);
}