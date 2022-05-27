using KrabbelMicroservice.Models;
using KrabbelMicroservice.Models.Enums;
using KrabbelMicroservice.RabbitMQ.Interfaces;
using KrabbelMicroservice.Services.Interfaces;
using Newtonsoft.Json;

namespace KrabbelMicroservice.RabbitMQ;

public class EventProcessor : IEventProcessor
{
    private readonly IProfileKrabbelService _krabbelService;

    public EventProcessor(IProfileKrabbelService krabbelService)
    {
        _krabbelService = krabbelService;
    }

    public void ProcessEvent(string message)
    {
        bool result = false;
        
        EventMessage? eventMessage = JsonConvert.DeserializeObject<EventMessage>(message);

        if(eventMessage?.Type == EventType.ProfileDeletion) {
            result = _krabbelService.DeleteKrabbelsWithProfileId(eventMessage.ProfileId);
        } else {
            result = false;
        }

        if (result)
        {
            Console.WriteLine("--> I Received this lovely event: " + eventMessage.Message);
        }
        else
        {
            Console.WriteLine("--> Something went wrong during the event...");
        }
    }
}