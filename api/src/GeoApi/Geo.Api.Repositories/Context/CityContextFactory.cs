using Microsoft.EntityFrameworkCore;

namespace PostGIS.Api.Repositories.Context
{
    public interface ICityContextFactory : IDbContextFactory<CityContext>
    {
    }

    public class CityContextFactory : ICityContextFactory
    {
        private readonly DbContextOptions<CityContext> _options;
        public CityContextFactory(DbContextOptions<CityContext> options)
        {
            _options = options;
        }

        public CityContext CreateDbContext()
        {
            var db = new CityContext(_options);

            // todo: config db

            return db;
        }
    }
}
