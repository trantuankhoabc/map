namespace Location.Api.Repositories.Contracts;

public interface IRepositoryManager
{
    //give access to repos via manager
    IParcelRepository Parcel { get; }
    IBuildingRepository Building { get; }
    void Save();
}