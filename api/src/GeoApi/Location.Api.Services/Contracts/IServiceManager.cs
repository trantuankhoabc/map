namespace Location.Api.Services.Contracts;

public interface IServiceManager
{
    IParcelService ParcelService { get; }
    IBuildingService BuildingService { get; }
}