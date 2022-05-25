using Microsoft.AspNetCore.Mvc;
using ProfileMicroservice.Models;
using ProfileMicroservice.RabbitMQ.Interfaces;
using ProfileMicroservice.Services.Interfaces;

namespace ProfileMicroservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : Controller
{
    private readonly IProfileService _profileService;
    private readonly IMessageBusClient _messageBusClient;

    public ProfileController(IProfileService profileService, IMessageBusClient messageBusClient)
    {
        _profileService = profileService;
        _messageBusClient = messageBusClient;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<Profile> profiles = _profileService.GetProfiles();

        if (profiles.Any())
        {
            return Ok(profiles);
        }

        return NotFound("No profiles were found");
    }
    
    [HttpGet]
    [Route("/id/{profileId}")]
    public IActionResult GetProfileById(long profileId)
    {
        Profile? profile = _profileService.GetProfileById(profileId);
        
        if (profile != null)
        {
            return Ok(profile);
        }

        return NotFound("No profile was found with the profile id " + profileId);
    }
    
    [HttpGet]
    [Route("/uid/{userId}")]
    public IActionResult GetProfileByUserId(string userId)
    {
        Profile? profile = _profileService.GetProfileByUserId(userId);
        
        if (profile != null)
        {
            return Ok(profile);
        }

        return NotFound("No profile was found with the user id " + userId);
    }
    
    [HttpGet]
    [Route("/un/{userName}")]
    public IActionResult GetProfileByUserName(string userName)
    {
        Profile? profile = _profileService.GetProfileByUserId(userName);
        
        if (profile != null)
        {
            return Ok(profile);
        }

        return NotFound("No profile was found with the username " + userName);
    }
    
    [HttpPost]
    [Route("/new")]
    public IActionResult AddProfile(Profile profile)
    {
        Profile? result = _profileService.AddProfile(profile);

        if (result != null)
        {
            return Ok(result);
        } 
        
        return BadRequest("The profile could not be created.");
    }
    
    [HttpPut]
    [Route("/update")]
    public IActionResult UpdateProfile(Profile profile)
    {
        Profile? result = _profileService.UpdateProfile(profile);

        if (result != null)
        {
            return Ok(result);
        } 
        
        return BadRequest("The profile could not be updated.");
    }
    
    [HttpDelete]
    [Route("/delete")]
    public IActionResult DeleteProfile(Profile profile)
    {
        bool result = _profileService.DeleteProfile(profile);

        if (result)
        {
            return Ok(result);
        } 
        
        return BadRequest("The profile could not be deleted.");
    }

    [HttpGet]
    [Route("/search/un/{userName}")]
    public IActionResult FindProfilesByUserName(string userName)
    {
        List<Profile> profiles = _profileService.FindProfilesByUserName(userName);

        if (profiles.Any())
        {
            return Ok(profiles);
        }

        return NotFound("No profiles were found with the username " + userName);
    }

    [HttpGet]
    [Route("/search/dn/{displayName}")]
    public IActionResult FindProfilesByDisplayName(string displayName)
    {
        List<Profile>? profiles = _profileService.FindProfilesByDisplayName(displayName);

        if (profiles.Any())
        {
            return Ok(profiles);
        }

        return NotFound("No profiles were found with the display name " + displayName);
    }
}