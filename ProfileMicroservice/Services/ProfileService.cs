using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.Services.Interfaces;

namespace ProfileMicroservice.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;

    public ProfileService(IProfileRepository profileRepository)
    {
        _profileRepository = profileRepository;
    }

    public Profile AddProfile(Profile profile)
    {
        return _profileRepository.AddProfile(profile);
    }
    
    public List<Profile>? GetProfiles()
    {
        return _profileRepository.GetProfiles();
    }

    public Profile? GetProfileByUserId(string userId)
    {
        if (userId != "")
        {
            return _profileRepository.GetProfileByUserId(userId);
        }

        return null;
    }
}