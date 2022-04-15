namespace ProfileMicroservice.Data.Repositories.Interfaces;

public interface IProfileRepository
{
    bool SaveChanges();
    
    Profile AddProfile(Profile profile);

    Profile UpdateProfile(Profile profile);

    bool DeleteProfile(Profile profile);

    List<Profile>? GetProfiles();

    Profile? GetProfileByUserId(string userId);
}