using Fines.Data.Models;
using Fines.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace Fines.Data;

public class FinesDbContext : DbContext
{
    public FinesDbContext(DbContextOptions<FinesDbContext> options) : base(options)
    {
    }

    public DbSet<FinesEntity> Fines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed 25 entries with 5 of each fine type
        modelBuilder.Entity<FinesEntity>().HasData(FinesSeedData.GetSeedData());
    }
}