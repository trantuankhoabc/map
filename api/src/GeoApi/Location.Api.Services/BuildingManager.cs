using Location.Api.Entities.Models;
using Location.Api.Repositories.Contracts;
using Location.Api.Services.Contracts;

namespace Location.Api.Services;

public class BuildingManager : IBuildingService
{
    //DI
    private readonly IRepositoryManager _manager;

    public BuildingManager(IRepositoryManager manager)
    {
        _manager = manager;
    }


    public void DeleteOneBuilding(int id, bool trackChanges)
    {
        // check entity 
        var entity = _manager.Building.GetOneBuildingById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Building with id :{id} could not found. ");

        _manager.Building.DeleteOneBuilding(entity);
        _manager.Save();
    }


    public Building? CreateOneBuilding(Building? building)
    {
        _manager.Building.CreateOneBuilding(building);
        _manager.Save();
        return building;
    }


    public IEnumerable<Building> GetAllBuildings(bool trackChanges)
    {
        return _manager.Building.GetAllBuildings(trackChanges);
    }


    public Building GetOneBuildingById(int id, bool trackChanges)
    {
        return _manager.Building.GetOneBuildingById(id, trackChanges);
    }


    public void UpdateOneBuilding(int id, Building? building, bool trackChanges)
    {
        // check entity 
        var entity = _manager.Building.GetOneBuildingById(id, trackChanges);
        if (entity is null)
            throw new Exception($"Building with id :{id} could not found. ");
        // check params 
        if (building is null)
            throw new ArgumentNullException(nameof(building));

        entity.FKey = building.FKey;
        entity.Block = building.Block;
        entity.Attribute = building.Attribute;
        entity.geom = building.geom;

        _manager.Building.Update(entity);
        _manager.Save();
    }
}