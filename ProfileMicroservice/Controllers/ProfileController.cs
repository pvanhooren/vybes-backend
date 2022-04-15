using Microsoft.AspNetCore.Mvc;
using ProfileMicroservice.Services.Interfaces;

namespace ProfileMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : Controller
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Profile>? profiles = _profileService.GetProfiles();

        if (profiles != null && profiles.Any())
        {
            return Ok(profiles);
        }

        return NotFound("No profiles were found");
    }
    
    [HttpGet]
    [Route("/{userId}")]
    public IActionResult GetProfileByUserId(string userId)
    {
        Profile? profile = _profileService.GetProfileByUserId(userId);
        
        if (profile != null)
        {
            return Ok(profile);
        }

        return NotFound("No profile was found with the user id " + userId);
    }
    
    [HttpPost]
    [Route("/new")]
    public IActionResult AddProfile(string userId)
    {
        Profile profile = new Profile
        {
            UserId = userId,
            DisplayName = "Pim",
            About = "Hi my name is Pim",
            PhoneNumber = "06-12345678",
            Birthday = DateTime.ParseExact("2002-02-07 04:00", "yyyy-MM-dd HH:mm",
                System.Globalization.CultureInfo.InvariantCulture),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        return Ok(_profileService.AddProfile(profile));
    }
}