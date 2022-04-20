namespace ProfileMicroservice.Data.Repositories.Interfaces;

public interface IProfileRepository
{
    bool SaveChanges();
    
    Profile AddProfile(Profile profile);

    Profile UpdateProfile(Profile profile);

    bool DeleteProfile(Profile profile);

    bool ProfileExistsByProfileId(long profileId);
    
    bool ProfileExistsByUserId(string userId);
    
    bool ProfileExistsByUserName(string userName);
    
    Profile? GetProfileByUserId(string userId);

    List<Profile>? GetProfiles();

    List<Profile>? FindProfilesByUserName(string userName);
    
    List<Profile>? FindProfilesByDisplayName(string displayName);
}