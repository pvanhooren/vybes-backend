using ProfileMicroservice.Models;

namespace ProfileMicroservice.Services.Interfaces;

public interface IProfileService
{
    List<Profile> GetProfiles();

    Profile? GetProfileById(long profileId);
    
    Profile? GetProfileByUserId(string userId);
    
    Profile? GetProfileByUserName(string userName);
    
    Profile? AddProfile(Profile profile);

    Profile? UpdateProfile(Profile profile);

    bool DeleteProfile(Profile profile);

    List<Profile> FindProfilesByUserName(string userName);

    List<Profile> FindProfilesByDisplayName(string displayName);
}