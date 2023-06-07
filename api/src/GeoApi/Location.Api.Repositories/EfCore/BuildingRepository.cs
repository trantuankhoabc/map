using Location.Api.Entities.Models;
using Location.Api.Repositories.Contracts;

namespace Location.Api.Repositories.EfCore

{
    public class BuildingRepository : RepositoryBase<Building>, IBuildingRepository
    {
        public BuildingRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneBuilding(Building building)
         => Create(building);

        public void DeleteOneBuilding(Building building)
         => Delete(building);

        public IQueryable<Building> GetAllBuildings(bool trackChanges)
        =>
            FindAll(trackChanges)
            .OrderBy(b => b.Id);

        public Building GetOneBuildingById(int id, bool trackChanges)
      =>
            FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void UpdateOneBuilding(Building building)
        => Update(building);
    }
}