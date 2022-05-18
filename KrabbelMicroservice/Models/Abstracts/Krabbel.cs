using System.ComponentModel.DataAnnotations;

namespace KrabbelMicroservice.Models.Abstracts;

public abstract class Krabbel
{
    [Key] public long KrabbelId { get; set; }

    public long FromProfileId { get; set; }
    
    public string Content { get; set; }
    
    public DateTime? CreatedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }
}