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

    public List<ProfileKrabbel> GetKrabbelsToProfileId(long profileId)
    {
        return _krabbelRepository.GetKrabbelsToProfileId(profileId);
    }
    
    public List<ProfileKrabbel> GetKrabbelsFromProfileId(long profileId)
    {
        return _krabbelRepository.GetKrabbelsFromProfileId(profileId);
    }

    public ProfileKrabbel? AddKrabbel(ProfileKrabbel krabbel)
    {
        krabbel.CreatedAt = DateTime.Now;
        krabbel.UpdatedAt = DateTime.Now;
        
        return _krabbelRepository.AddKrabbel(krabbel);
    }

    public ProfileKrabbel? UpdateKrabbel(ProfileKrabbel krabbel)
    {
        krabbel.UpdatedAt = DateTime.Now;
        
        return _krabbelRepository.UpdateKrabbel(krabbel);
    }

    public bool DeleteKrabbel(ProfileKrabbel krabbel)
    {
        bool krabbelIdExists = _krabbelRepository.KrabbelExists(krabbel.KrabbelId);

        if (krabbelIdExists)
        {
            return _krabbelRepository.DeleteKrabbel(krabbel);
        }

        return false;
    }

    public bool DeleteKrabbelsWithProfileId(long profileId)
    {
        List<ProfileKrabbel> krabbelsByProfile = _krabbelRepository.GetKrabbelsFromProfileId(profileId);
        List<ProfileKrabbel> krabbelsToProfile = _krabbelRepository.GetKrabbelsToProfileId(profileId);

        List<ProfileKrabbel> krabbels = krabbelsByProfile.Union(krabbelsToProfile).DistinctBy(x => x.KrabbelId).ToList();

        foreach (var krabbel in krabbels)
        {
            bool result = _krabbelRepository.DeleteKrabbel(krabbel);

            if (!result)
            {
                return result;
            }
        }

        return true;
    }
}