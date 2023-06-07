using Geo.Api.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Features;

namespace Geo.Api.Repositories.Context
{
    public class CityDbContext : DbContext
    {
        public CityDbContext(DbContextOptions<CityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("postgis");
            modelBuilder.HasDefaultSchema("public");
        }

        public DbSet<Building> Buildings { get; set; }
    }
}