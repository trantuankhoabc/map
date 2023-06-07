using Location.Api.Repositories.Contracts;

namespace Location.Api.Repositories.EfCore;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IBuildingRepository> _buildingRepository;
    private readonly RepositoryContext _context;
    private readonly Lazy<IParcelRepository> _parcelRepository;

    public RepositoryManager(RepositoryContext context)

    {
        _context = context;
        _parcelRepository = new Lazy<IParcelRepository>(() => new ParcelRepository(_context));
        _buildingRepository = new Lazy<IBuildingRepository>(() => new BuildingRepository(_context));
    }


    public IParcelRepository Parcel => _parcelRepository.Value;
    public IBuildingRepository Building => _buildingRepository.Value;


    public void Save()
    {
        _context.SaveChanges();
    }
}