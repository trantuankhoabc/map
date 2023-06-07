using Location.Api.Entities.Models;

namespace Location.Api.Repositories.Contracts;

public interface IBuildingRepository : IRepositoryBase<Building>
{
    IQueryable<Building> GetAllBuildings(bool trackChanges);
    Building GetOneBuildingById(int id, bool trackChanges);

    void CreateOneBuilding(Building building);
    void UpdateOneBuilding(Building building);
    void DeleteOneBuilding(Building building);
}