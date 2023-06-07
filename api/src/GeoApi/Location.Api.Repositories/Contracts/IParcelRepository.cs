using Location.Api.Entities.Models;

namespace Location.Api.Repositories.Contracts;

public interface IParcelRepository : IRepositoryBase<Parcel>
{
    IQueryable<Parcel> GetAllParcels(bool trackChanges);
    Parcel GetOneParcelById(int id, bool trackChanges);

    void CreateOneParcel(Parcel parcel);
    void UpdateOneParcel(Parcel parcel);
    void DeleteOneParcel(Parcel parcel);
}