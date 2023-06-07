using Geo.Api.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Geo.Api.Repositories
{
    public class TenantDbContextFactory : IDesignTimeDbContextFactory<CityDbContext>
    {
        public CityDbContext CreateDbContext(string[] args)
        {
            
            var configrationBuilder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PostGIS.Api/"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true);
            
            var configuration = configrationBuilder.Build();
            var connectionString = configuration.GetConnectionString("City");

            var dbContextOptionBuilder = new DbContextOptionsBuilder<CityDbContext>();
            dbContextOptionBuilder.UseNpgsql(connectionString,
                    x => { x.UseNetTopologySuite(); })
                .UseLowerCaseNamingConvention();

            return new CityDbContext(dbContextOptionBuilder.Options);
            
        }
    }
}