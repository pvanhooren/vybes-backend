using ProfileMicroservice.Models.Enums;

namespace ProfileMicroservice.Models;

public class EventMessage
{
    public EventType Type { get; set; }
    
    public long ProfileId { get; set; }
    
    public string Message { get; set; }
}