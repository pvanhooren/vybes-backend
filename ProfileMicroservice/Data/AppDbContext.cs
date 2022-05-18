using Microsoft.EntityFrameworkCore;
using ProfileMicroservice.Models;

namespace ProfileMicroservice.Data;

public class AppDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; } = null!;

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
