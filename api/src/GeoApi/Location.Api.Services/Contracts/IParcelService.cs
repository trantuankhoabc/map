using Location.Api.Entities.Models;

namespace Location.Api.Services.Contracts;

public interface IParcelService
{
    IEnumerable<Parcel> GetAllParcels(bool trackChanges); // Parcel- add reference to entities
    Parcel GetOneParcelById(int id, bool trackChanges);
    Parcel CreateOneParcel(Parcel parcel);
    void UpdateOneParcel(int id, Parcel? parcel, bool trackChanges);
    void DeleteOneParcel(int id, bool trackChanges);
}