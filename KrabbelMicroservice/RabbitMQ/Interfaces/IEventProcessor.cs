namespace KrabbelMicroservice.RabbitMQ.Interfaces;

public interface IEventProcessor
{
    void ProcessEvent(string message);
}
