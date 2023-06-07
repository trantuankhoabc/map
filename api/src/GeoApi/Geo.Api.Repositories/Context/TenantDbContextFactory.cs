using Microsoft.EntityFrameworkCore;

namespace Geo.Api.Repositories.Context
{
    public interface ICityDbContextFactory : IDbContextFactory<CityDbContext>
    {
    }

    public class CityDbContextFactory : ICityDbContextFactory
    {
        private readonly DbContextOptions<CityDbContext> _options;
        public CityDbContextFactory(DbContextOptions<CityDbContext> options)
        {
            _options = options;
        }

        public CityDbContext CreateDbContext()
        {
            var db = new CityDbContext(_options);

            // todo: config db

            return db;
        }
    }
}
