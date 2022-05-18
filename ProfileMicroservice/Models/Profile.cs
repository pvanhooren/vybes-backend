using System.ComponentModel.DataAnnotations;

namespace ProfileMicroservice.Models;

public class Profile
{
    [Key] public long ProfileId { get; set; }
    
    public String UserId { get; set; }
    
    public String UserName { get; set; }
    
    public String? DisplayName { get; set; }
    
    public String? About { get; set; }

    public String? PhoneNumber { get; set; }

    public DateTime? Birthday { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}