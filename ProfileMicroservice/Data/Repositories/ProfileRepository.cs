using Microsoft.EntityFrameworkCore;
using ProfileMicroservice.Data.Repositories.Interfaces;
using ProfileMicroservice.Models;

namespace ProfileMicroservice.Data.Repositories;

public class ProfileRepository : IProfileRepository
{
    private readonly AppDbContext _dbContext;

    public ProfileRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool SaveChanges()
    {
        return (_dbContext.SaveChanges() >= 0);
    }
    
    public List<Profile> GetProfiles()
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .ToList();
    }

    public Profile? GetProfileById(long profileId)
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .Where(x => x.ProfileId == profileId)
            .FirstOrDefault();
    }

    public Profile? GetProfileByUserId(string userId)
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .FirstOrDefault();
    }
    
    public Profile? GetProfileByUserName(string userName)
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .Where(x => x.UserName == userName)
            .FirstOrDefault();
    }

    public Profile AddProfile(Profile profile)
    {
        _dbContext.Profiles.Add(profile);
        SaveChanges();

        return profile;
    }

    public Profile UpdateProfile(Profile profile)
    {
        _dbContext.Profiles.Update(profile);
        SaveChanges();

        return profile;
    }

    public bool DeleteProfile(Profile profile)
    {
        _dbContext.Profiles.Remove(profile);
        return SaveChanges();
    }

    public bool ProfileExistsByProfileId(long profileId)
    {
        return _dbContext.Profiles.Any(x => x.ProfileId == profileId);
    }

    public bool ProfileExistsByUserId(string userId)
    {
        return _dbContext.Profiles.Any(x => x.UserId == userId);
    }

    public bool ProfileExistsByUserName(string userName)
    {
        return _dbContext.Profiles.Any(x => x.UserName == userName);
    }

    public List<Profile> FindProfilesByUserName(string userName)
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .Where(x => x.UserName.ToLower().Contains(userName.ToLower()))
            .ToList();
    }
    
    public List<Profile> FindProfilesByDisplayName(string displayName)
    {
        return _dbContext.Profiles
            .AsNoTracking()
            .Where(x => x.DisplayName.ToLower().Contains(displayName.ToLower()))
            .ToList();
    }
}