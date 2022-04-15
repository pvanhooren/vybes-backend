namespace ProfileMicroservice.Services.Interfaces;

public interface IProfileService
{
    Profile AddProfile(Profile profile);

    List<Profile>? GetProfiles();

    Profile? GetProfileByUserId(string userId);
}