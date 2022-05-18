using ProfileMicroservice.Models;

namespace ProfileMicroservice.Data.Repositories.Interfaces;

public interface IProfileRepository
{
    bool SaveChanges();
    
    List<Profile> GetProfiles();

    Profile? GetProfileById(long profileId);
    
    Profile? GetProfileByUserId(string userId);
    
    Profile? GetProfileByUserName(string userName);
    
    Profile AddProfile(Profile profile);

    Profile UpdateProfile(Profile profile);

    bool DeleteProfile(Profile profile);

    bool ProfileExistsByProfileId(long profileId);
    
    bool ProfileExistsByUserId(string userId);

    bool ProfileExistsByUserName(string userName);

    List<Profile> FindProfilesByUserName(string userName);
    
    List<Profile> FindProfilesByDisplayName(string displayName);
}