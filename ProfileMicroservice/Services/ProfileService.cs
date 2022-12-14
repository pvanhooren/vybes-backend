using System.Globalization;
using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.Models;
using ProfileMicroservice.Models.Enums;
using ProfileMicroservice.RabbitMQ.Interfaces;
using ProfileMicroservice.Services.Interfaces;

namespace ProfileMicroservice.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileRepository _profileRepository;
    private readonly IMessageBusClient _messageBusClient;

    public ProfileService(IProfileRepository profileRepository, IMessageBusClient messageBusClient)
    {
        _profileRepository = profileRepository;
        _messageBusClient = messageBusClient;
    }
    
    public List<Profile> GetProfiles()
    {
        return _profileRepository.GetProfiles();
    }

    public Profile? GetProfileById(long profileId)
    {
        if (profileId != 0)
        {
            return _profileRepository.GetProfileById(profileId);
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
    
    public Profile? GetProfileByUserName(string userName)
    {
        if (userName != "")
        {
            return _profileRepository.GetProfileByUserName(userName);
        }

        return null;
    }

    public Profile? AddProfile(Profile profile)
    {
        profile.CreatedAt = DateTime.Now;
        profile.UpdatedAt = DateTime.Now;
        
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

        var existingProfile = _profileRepository.GetProfileById(profile.ProfileId);

        if (existingProfile != null)
        {
            bool canCreate = true;
            
            if (existingProfile.UserName != profile.UserName)
            {
                bool userNameExists = _profileRepository.ProfileExistsByUserName(profile.UserName);

                if (userNameExists)
                {
                    canCreate = false;
                }
            }

            if (canCreate)
            {
                return _profileRepository.UpdateProfile(profile);
            }
        }
        
        return null;
    }

    public bool DeleteProfile(Profile profile)
    {
        bool profileIdExists = _profileRepository.ProfileExistsByProfileId(profile.ProfileId);

        if (profileIdExists)
        {
            bool success = _profileRepository.DeleteProfile(profile);

            if (success)
            {
                EventMessage message = new EventMessage
                {
                    Type = EventType.ProfileDeletion,
                    ProfileId = profile.ProfileId,
                    Message = "Profile with id " + profile.ProfileId + " was deleted.",
                };

                _messageBusClient.SendMessage(message);
                
                return success;
            }

            return true;
        }

        return false;
    }

    public List<Profile> FindProfilesByUserName(string userName)
    {
        return _profileRepository.FindProfilesByUserName(userName);
    }
    
    public List<Profile> FindProfilesByDisplayName(string displayName)
    {
        return _profileRepository.FindProfilesByDisplayName(displayName);
    }
}