using KrabbelMicroservice.Data.Repositories.Interfaces;
using KrabbelMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace KrabbelMicroservice.Data.Repositories;

public class ProfileKrabbelRepository : IProfileKrabbelRepository
{
    private readonly AppDbContext _dbContext;
    
    public ProfileKrabbelRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        
    }
    
    public bool SaveChanges()
    {
        bool success = _dbContext.SaveChanges() >= 0;
        
        _dbContext.ChangeTracker.Clear();

        return success;
    }

    public List<ProfileKrabbel> GetKrabbels()
    {
        return _dbContext.ProfileKrabbels
            .AsNoTracking()
            .ToList();
    }

    public ProfileKrabbel? GetKrabbelById(long krabbelId)
    {
        return _dbContext.ProfileKrabbels
            .AsNoTracking()
            .Where(x => x.KrabbelId == krabbelId)
            .FirstOrDefault();
    }

    public List<ProfileKrabbel> GetKrabbelsToProfileId(long profileId)
    {
        return _dbContext.ProfileKrabbels
            .AsNoTracking()
            .Where(x => x.ToProfileId == profileId)
            .ToList();
    }
    
    public List<ProfileKrabbel> GetKrabbelsFromProfileId(long profileId)
    {
        return _dbContext.ProfileKrabbels
            .AsNoTracking()
            .Where(x => x.FromProfileId == profileId)
            .ToList();
    }

    public ProfileKrabbel AddKrabbel(ProfileKrabbel krabbel)
    {
        _dbContext.ProfileKrabbels.Add(krabbel);
        SaveChanges();

        return krabbel;
    }

    public ProfileKrabbel UpdateKrabbel(ProfileKrabbel krabbel)
    {
        _dbContext.ProfileKrabbels.Update(krabbel);
        SaveChanges();

        return krabbel;
    }

    public bool DeleteKrabbel(ProfileKrabbel krabbel)
    {
        _dbContext.ProfileKrabbels.Remove(krabbel);
        SaveChanges();

        return true;
    }
    
    public bool KrabbelExists(long krabbelId)
    {
        return _dbContext.ProfileKrabbels.Any(x => x.KrabbelId == krabbelId);
    }
}