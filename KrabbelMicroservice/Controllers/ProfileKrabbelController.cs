using KrabbelMicroservice.Models;
using KrabbelMicroservice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KrabbelMicroservice.Controllers;

[ApiController]
[Route("krabbels/profile")]
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
    [Route("/id/{krabbelId}")]
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
    [Route("/pid/{profileId}")]
    public IActionResult GetKrabbelsByProfileId(long profileId)
    {
        List<ProfileKrabbel> krabbels = _krabbelService.GetKrabbelsByProfileId(profileId);
        
        if (krabbels.Any())
        {
            return Ok(krabbels);
        }
        
        return NotFound("No krabbels were found for the profile with profile id " + profileId);
    }

    [HttpPost]
    [Route("/new")]
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
    [Route("/update")]
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
    [Route("/delete")]
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