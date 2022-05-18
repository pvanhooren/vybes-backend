using KrabbelMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace KrabbelMicroservice.Data;

public class AppDbContext : DbContext
{
    public DbSet<ProfileKrabbel> ProfileKrabbels { get; set; } = null!;

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}