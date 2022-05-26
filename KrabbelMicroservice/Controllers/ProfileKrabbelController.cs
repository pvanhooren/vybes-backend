using KrabbelMicroservice.Models;
using KrabbelMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KrabbelMicroservice.Controllers;

[ApiController]
[Route("profile")]
public class ProfileKrabbelController : Controller
{
    private readonly IProfileKrabbelService _krabbelService;
    public ProfileKrabbelController(IProfileKrabbelService krabbelService)
    {
        _krabbelService = krabbelService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<ProfileKrabbel> krabbels = _krabbelService.GetKrabbels();
        
        if (krabbels.Any())
        {
            return Ok(krabbels);
        }

        return NotFound("No krabbels were found");
    }
    
    [HttpGet]
    [Route("kid/{krabbelId}")]
    public IActionResult GetKrabbelById(long krabbelId)
    {
        ProfileKrabbel? profile = _krabbelService.GetKrabbelById(krabbelId);
        
        if (profile != null)
        {
            return Ok(profile);
        }
        
        return NotFound("No ProfileKrabbel was found with the krabbel id " + krabbelId);
    }
    
    [HttpGet]
    [Route("pid/to/{profileId}")]
    public IActionResult GetKrabbelsToProfileId(long profileId)
    {
        List<ProfileKrabbel> krabbels = _krabbelService.GetKrabbelsToProfileId(profileId);
        
        if (krabbels.Any())
        {
            return Ok(krabbels);
        }
        
        return NotFound("No krabbels were found for the profile with profile id " + profileId);
    }
    
    [HttpGet]
    [Route("pid/from/{profileId}")]
    public IActionResult GetKrabbelsFromProfileId(long profileId)
    {
        List<ProfileKrabbel> krabbels = _krabbelService.GetKrabbelsFromProfileId(profileId);
        
        if (krabbels.Any())
        {
            return Ok(krabbels);
        }
        
        return NotFound("No krabbels were found written by the profile with profile id " + profileId);
    }
    
    [HttpGet]
    [Route("pid/with/{profileId}")]
    public IActionResult GetKrabbelsWithProfileId(long profileId)
    {
        List<ProfileKrabbel> krabbelsByProfile = _krabbelService.GetKrabbelsFromProfileId(profileId);
        List<ProfileKrabbel> krabbelsToProfile = _krabbelService.GetKrabbelsToProfileId(profileId);

        if (krabbelsByProfile.Any() || krabbelsToProfile.Any())
        {
            List<ProfileKrabbel> krabbels = krabbelsByProfile.Concat(krabbelsToProfile).DistinctBy(x => x.KrabbelId).ToList();

            return Ok(krabbels);
        }
        
        return NotFound("No krabbels were found related to the profile with profile id " + profileId);
    }

    [HttpPost]
    [Route("new")]
    public IActionResult AddKrabbel(ProfileKrabbel krabbel)
    {
        krabbel.CreatedAt = DateTime.Now;
        krabbel.UpdatedAt = DateTime.Now;
        
        ProfileKrabbel? result = _krabbelService.AddKrabbel(krabbel);
        
        if (result != null)
        {
            return Ok(result);
        } 
        
        return BadRequest("The krabbel could not be created.");
    }
    
    [HttpPut]
    [Route("update")]
    public IActionResult UpdateKrabbel(ProfileKrabbel krabbel)
    {
        ProfileKrabbel? result = _krabbelService.UpdateKrabbel(krabbel);
        
        if (result != null)
        {
            return Ok(result);
        } 
        
        return BadRequest("The krabbel could not be updated.");
    }
    
    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteKrabbel(ProfileKrabbel krabbel)
    {
        bool result = _krabbelService.DeleteKrabbel(krabbel);
        
        if (result)
        {
            return Ok(result);
        } 
        
        return BadRequest("The krabbel could not be deleted.");
    }
}