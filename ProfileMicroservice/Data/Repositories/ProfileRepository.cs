using Microsoft.EntityFrameworkCore;
using ProfileMicroservice.Data.Repositories.Interfaces;

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

    public Profile AddProfile(Profile profile)
    {
        _dbContext.Profiles?.Add(profile);
        SaveChanges();

        return profile;
    }

    public Profile UpdateProfile(Profile profile)
    {
        _dbContext.Profiles?.Update(profile);
        SaveChanges();

        return profile;
    }

    public bool DeleteProfile(Profile profile)
    {
        _dbContext.Profiles?.Remove(profile);
        SaveChanges();

        return true;
    }

    public List<Profile>? GetProfiles()
    {
        return _dbContext.Profiles?
            .AsNoTracking()
            .ToList();
    }

    public Profile? GetProfileByUserId(string userId)
    {
        return _dbContext.Profiles?
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .FirstOrDefault();
    }
}