using Location.Api.Entities.Models;

namespace Location.Api.Services.Contracts;

public interface IBuildingService
{
    IEnumerable<Building> GetAllBuildings(bool trackChanges); // Building- add reference to entities
    Building GetOneBuildingById(int id, bool trackChanges);
    Building? CreateOneBuilding(Building? building);
    void UpdateOneBuilding(int id, Building? building, bool trackChanges);
    void DeleteOneBuilding(int id, bool trackChanges);
}