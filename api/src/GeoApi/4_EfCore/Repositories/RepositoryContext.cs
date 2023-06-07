using _4_EfCore.Models;
using _4_EfCore.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace _4_EfCore.Repositories;

public class RepositoryContext : DbContext // EfCore 
{
    public RepositoryContext(DbContextOptions options) :
        base(options) // RepositoryContext base to DbContext, so the connection string in options to DbContext
    {
    }

    public DbSet<Parcel> Parcels { get; set; }
    public DbSet<Building> Buildings { get; set; }


    // type configuration
    // override - override a method we inherited
    // model

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ParcelConfig());
        modelBuilder.ApplyConfiguration(new BuildingConfig());
    }
}