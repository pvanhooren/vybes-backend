using KrabbelMicroservice.Models;

namespace KrabbelMicroservice.Data.Repositories.Interfaces;

public interface IProfileKrabbelRepository
{
    List<ProfileKrabbel> GetKrabbels();

    ProfileKrabbel? GetKrabbelById(long krabbelId);
    
    List<ProfileKrabbel> GetKrabbelsToProfileId(long profileId);
    
    List<ProfileKrabbel> GetKrabbelsFromProfileId(long profileId);
    
    ProfileKrabbel AddKrabbel(ProfileKrabbel krabbel);

    ProfileKrabbel UpdateKrabbel(ProfileKrabbel krabbel);

    bool DeleteKrabbel(ProfileKrabbel krabbel);

    bool KrabbelExists(long krabbelId);
}