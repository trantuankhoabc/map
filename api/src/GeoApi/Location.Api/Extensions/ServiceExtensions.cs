using Location.Api.Repositories.Contracts;
using Location.Api.Repositories.EfCore;
using Location.Api.Services;
using Location.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Location.Api.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration
    )
    {
        services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("sqlConnection"),
                x => { x.UseNetTopologySuite(); }));
    }

    //used to configure a service required to access data stores
    public static void ConfigureRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
        services.AddScoped<IServiceManager, ServiceManager>();
    }
}