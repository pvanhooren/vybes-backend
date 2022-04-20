namespace ProfileMicroservice.Services.Interfaces;

public interface IProfileService
{
    Profile? AddProfile(Profile profile);

    Profile? UpdateProfile(Profile profile);
    
    Profile? GetProfileByUserId(string userId);

    List<Profile>? GetProfiles();

    List<Profile>? FindProfilesByUserName(string userName);

    List<Profile>? FindProfilesByDisplayName(string displayName);
}