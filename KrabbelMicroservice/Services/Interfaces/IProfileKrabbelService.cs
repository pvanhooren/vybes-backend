using KrabbelMicroservice.Models;

namespace KrabbelMicroservice.Services.Interfaces;

public interface IProfileKrabbelService
{
    List<ProfileKrabbel> GetKrabbels();

    ProfileKrabbel? GetKrabbelById(long krabbelId);
    
    List<ProfileKrabbel> GetKrabbelsByProfileId(long profileId);
    
    ProfileKrabbel? AddKrabbel(ProfileKrabbel krabbel);

    ProfileKrabbel? UpdateKrabbel(ProfileKrabbel krabbel);

    bool DeleteKrabbel(ProfileKrabbel krabbel);
}