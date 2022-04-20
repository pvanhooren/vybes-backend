using System.Globalization;
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

    public Profile? AddProfile(Profile profile)
    {
        bool userIdExists = _profileRepository.ProfileExistsByUserId(profile.UserId);
        bool userNameExists = _profileRepository.ProfileExistsByUserName(profile.UserName);

        if (!userIdExists && !userNameExists)
        {
            return _profileRepository.AddProfile(profile);
        }

        return null;
    }

    public Profile? UpdateProfile(Profile profile)
    {
        profile.UpdatedAt = DateTime.Now;
        
        bool profileIdExists = _profileRepository.ProfileExistsByProfileId(profile.ProfileId);
        bool userNameExists = _profileRepository.ProfileExistsByUserName(profile.UserName);

        if (profileIdExists && !userNameExists)
        {
            return _profileRepository.UpdateProfile(profile);
        }

        return null;
    }
    
    public Profile? GetProfileByUserId(string userId)
    {
        if (userId != "")
        {
            return _profileRepository.GetProfileByUserId(userId);
        }

        return null;
    }
    
    public List<Profile>? GetProfiles()
    {
        return _profileRepository.GetProfiles();
    }

    public List<Profile>? FindProfilesByUserName(string userName)
    {
        return _profileRepository.FindProfilesByUserName(userName);
    }
    
    public List<Profile>? FindProfilesByDisplayName(string displayName)
    {
        return _profileRepository.FindProfilesByDisplayName(displayName);
    }
}