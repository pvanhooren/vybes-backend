using System.ComponentModel.DataAnnotations;

namespace ProfileMicroservice;

public class Profile
{
    [Key] public Guid ProfileId { get; set; }
    
    public String UserId { get; set; }
    
    public String DisplayName { get; set; }
    
    public String About { get; set; }

    public String PhoneNumber { get; set; }

    public DateTime Birthday { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
}