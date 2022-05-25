using KrabbelMicroservice.Models;

namespace KrabbelMicroservice.Services.Interfaces;

public interface IProfileKrabbelService
{
    List<ProfileKrabbel> GetKrabbels();

    ProfileKrabbel? GetKrabbelById(long krabbelId);
    
    List<ProfileKrabbel> GetKrabbelsToProfileId(long profileId);
    
    List<ProfileKrabbel> GetKrabbelsFromProfileId(long profileId);
    
    ProfileKrabbel? AddKrabbel(ProfileKrabbel krabbel);

    ProfileKrabbel? UpdateKrabbel(ProfileKrabbel krabbel);

    bool DeleteKrabbel(ProfileKrabbel krabbel);

    bool DeleteKrabbelsWithProfileId(long profileId);
}