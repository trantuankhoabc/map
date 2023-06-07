using _4_EfCore.Models;
using _4_EfCore.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace _4_EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BuildingsController : ControllerBase
{
    //DI
    private readonly RepositoryContext _context;

    public BuildingsController(RepositoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllBuildings()
    {
        var buildings = _context.Buildings.ToList();
        return Ok(buildings);
    }

    [HttpGet("{id:int}")]
    public IActionResult
        GetOneBuilding([FromRoute(Name = "id")] int id) // [FromRoute(Name = "id")] where the id will come from.
    {
        try
        {
            /*
               var building = _context
               .Buildings
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
             */
            var building = _context
                .Buildings
                .SingleOrDefault(b => b.Id.Equals(id)); //returns null if not found
            if (building is null) return NotFound(); //404

            return Ok(building);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    [HttpPost] // create source
    public IActionResult CreateOneBuilding([FromBody] Building building)
    {
        try
        {
            if (building is null) return BadRequest(); // 400
            _context.Buildings.Add(building);
            _context.SaveChanges(); // saves it permanently

            return StatusCode(201, building);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneBuildings([FromRoute(Name = "id")] int id, [FromBody] Building building)
    {
        try
        {
            /*
             var entity = _context
                    .Buildings
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
             */
            var entity = _context
                .Buildings
                .SingleOrDefault(b => b.Id.Equals(id));
            if (entity is null) return NotFound(); //404
            // check id
            // id sent as a parameter match the id of the object to be updated
            if (id != building.Id) return BadRequest(); // 400

            entity.FKey = building.FKey;
            entity.Block = building.Block;
            entity.Attribute = building.Attribute;

            _context.SaveChanges();

            return Ok(building);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneBuilding([FromRoute(Name = "id")] int id)
    {
        try
        {
            /*
              var entity = _context 
               .Buildings
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
             */
            var entity = _context // delete 
                .Buildings
                .SingleOrDefault(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound(
                    new
                    {
                        statusCode = 404,
                        message = $"Building with id:{id} could not found."
                    }); // 404
            _context.Buildings.Remove(entity);
            _context.SaveChanges();

            return NoContent();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPatch("{id:int}")] // update the object partially
    /*
         * 
           PUT > application/json
           PATCH > application/json-patch+json
         */
    public IActionResult PartiallyUpdateOneBuilding([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Building> building)
    //[FromBody] JsonPatchDocument<T> used to bind data with parameters
    {
        try
        {
            var entity = _context
                .Buildings
                .FirstOrDefault(b => b.Id.Equals(id));

            if (entity is null) return NotFound(); // 404

            building.ApplyTo(entity);
            _context.SaveChanges();

            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}