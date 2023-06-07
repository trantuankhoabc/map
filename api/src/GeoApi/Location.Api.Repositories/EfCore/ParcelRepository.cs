using Location.Api.Entities.Models;
using Location.Api.Repositories.Contracts;

namespace Location.Api.Repositories.EfCore;

public class ParcelRepository : RepositoryBase<Parcel>, IParcelRepository
{
    public ParcelRepository(RepositoryContext context) : base(context)
    {
    }

    public void CreateOneParcel(Parcel parcel)
    {
        Create(parcel);
    }

    public void DeleteOneParcel(Parcel parcel)
    {
        Delete(parcel);
    }

    public IQueryable<Parcel> GetAllParcels(bool trackChanges)
    {
        return FindAll(trackChanges)
            .OrderBy(p => p.Id);
    }

    public Parcel GetOneParcelById(int id, bool trackChanges)
    {
        return FindByCondition(p => p.Id.Equals(id), trackChanges)
            .SingleOrDefault();
    }

    public void UpdateOneParcel(Parcel parcel)
    {
        Update(parcel);
    }
}