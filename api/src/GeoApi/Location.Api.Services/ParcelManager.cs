using Location.Api.Entities.Models;
using Location.Api.Repositories.Contracts;
using Location.Api.Services.Contracts;

namespace Location.Api.Services;

public class ParcelManager : IParcelService
{
    //DI
    private readonly IRepositoryManager _manager;

    public ParcelManager(IRepositoryManager manager)
    {
        _manager = manager;
    }


    public Parcel CreateOneParcel(Parcel parcel)
    {
        _manager.Parcel.CreateOneParcel(parcel);
        _manager.Save();
        return parcel;
    }


    public void DeleteOneParcel(int id, bool trackChanges)
    {
        // check entity 
        var entity = _manager.Parcel.GetOneParcelById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Parcel with id :{id} could not found. ");

        _manager.Parcel.DeleteOneParcel(entity);
        _manager.Save();
    }


    public IEnumerable<Parcel> GetAllParcels(bool trackChanges)
    {
        return _manager.Parcel.GetAllParcels(trackChanges);
    }


    public Parcel GetOneParcelById(int id, bool trackChanges)
    {
        return _manager.Parcel.GetOneParcelById(id, trackChanges);
    }


    public void UpdateOneParcel(int id, Parcel? parcel, bool trackChanges)
    {
        // check entity 
        var entity = _manager.Parcel.GetOneParcelById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Parcel with id :{id} could not found. ");
        // check params 
        if (parcel is null)
            throw new ArgumentNullException(nameof(parcel));

        entity.ParcelNo = parcel.ParcelNo;
        entity.Layout = parcel.Layout;
        entity.Island = parcel.Island;
        entity.Province = parcel.Province;
        entity.District = parcel.District;
        entity.Neighbourhood = parcel.Neighbourhood;
        entity.geom = parcel.geom;

        _manager.Parcel.Update(entity);
        _manager.Save();
    }
}