using KrabbelMicroservice.Data.Repositories.Interfaces;
using KrabbelMicroservice.Models;
using KrabbelMicroservice.Services.Interfaces;

namespace KrabbelMicroservice.Services;

public class ProfileKrabbelService : IProfileKrabbelService
{
    private readonly IProfileKrabbelRepository _krabbelRepository;
    
    public ProfileKrabbelService(IProfileKrabbelRepository krabbelRepository)
    {
        _krabbelRepository = krabbelRepository;
        
    }
    
    public List<ProfileKrabbel> GetKrabbels()
    {
        return _krabbelRepository.GetKrabbels();
    }

    public ProfileKrabbel? GetKrabbelById(long krabbelId)
    {
        if (krabbelId != 0)
        {
            return _krabbelRepository.GetKrabbelById(krabbelId);
        }
        
        return null;
    }

    public List<ProfileKrabbel> GetKrabbelsByProfileId(long profileId)
    {
        return _krabbelRepository.GetKrabbelsByProfileId(profileId);
    }

    public ProfileKrabbel? AddKrabbel(ProfileKrabbel krabbel)
    {
        krabbel.CreatedAt = DateTime.Now;
        krabbel.UpdatedAt = DateTime.Now;

        // Check if profile exists
        
        // if (profileExists)
        // {
            return _krabbelRepository.AddKrabbel(krabbel);
        // }
        //
        // return null;
    }

    public ProfileKrabbel? UpdateKrabbel(ProfileKrabbel krabbel)
    {
        krabbel.UpdatedAt = DateTime.Now;

        // Check if profile exists
        
        // if (existingKrabbel != null)
        // {
            return _krabbelRepository.UpdateKrabbel(krabbel);
        // }
        //
        // return null;
    }

    public bool DeleteKrabbel(ProfileKrabbel krabbel)
    {
        bool profileIdExists = _krabbelRepository.KrabbelExists(krabbel.KrabbelId);

        if (profileIdExists)
        {
            return _krabbelRepository.DeleteKrabbel(krabbel);
        }

        return false;
    }
}