using Microsoft.EntityFrameworkCore;

namespace ProfileMicroservice.Data;

public class AppDbContext : DbContext
{
    public DbSet<Profile>? Profiles { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
