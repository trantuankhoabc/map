using Location.Api.Entities.Models;
using Location.Api.Repositories.EfCore.Config;
using Microsoft.EntityFrameworkCore;

namespace Location.Api.Repositories.EfCore;

public class RepositoryContext : DbContext // EfCore exchange 
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) :
        base(options) // RepositoryContext the base to the DbContext i.e. the connection string in the options DbContext
    {
    }


    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Building> Buildings { get; set; }


    // type configuration
    //override - override a method we inherited
    // model while creating

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // use to ignore all classes of specific interface for EF Core:


        // modelBuilder.ApplyConfiguration(new ParcelConfig());
        modelBuilder.ApplyConfiguration(new BuildingConfig());

        // Enable support for PostGIS
        modelBuilder.HasPostgresExtension("postgis");
    }
}