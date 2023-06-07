using Location.Api.Repositories.Contracts;
using Location.Api.Services.Contracts;

namespace Location.Api.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IBuildingService> _buildingService;
    private readonly Lazy<IParcelService> _parcelService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _parcelService = new Lazy<IParcelService>(() => new ParcelManager(repositoryManager));
        _buildingService = new Lazy<IBuildingService>(() => new BuildingManager(repositoryManager));
    }

    public IParcelService ParcelService => _parcelService.Value;
    public IBuildingService BuildingService => _buildingService.Value;
}