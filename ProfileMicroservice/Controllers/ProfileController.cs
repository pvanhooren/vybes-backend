using Microsoft.AspNetCore.Mvc;

namespace ProfileMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        Profile profile = new Profile
        {
            UserId = "Test",
            DisplayName = "Pim",
            About = "Hi my name is Pim",
            PhoneNumber = "06-12345678",
            Birthday = DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
                System.Globalization.CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
            
        return Ok(profile);
    }
}