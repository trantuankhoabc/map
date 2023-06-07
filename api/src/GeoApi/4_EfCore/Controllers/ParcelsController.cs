using _4_EfCore.Models;
using _4_EfCore.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace _4_EfCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParcelsController : ControllerBase
{
    //DI
    private readonly RepositoryContext _context;

    public ParcelsController(RepositoryContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllParcels()
    {
        var parcels = _context.Parcels.ToList();
        return Ok(parcels);
    }

    [HttpGet("{id:int}")]
    public IActionResult
        GetOneParcel([FromRoute(Name = "id")] int id) // [FromRoute(Name = "id")] where the id will come from.
    {
        /* LINQ

         var parcel = ApplicationContext
            .Parcels
            .Where(b => b.Id.Equals(id))
            .SingleOrDefault();
         */
        try
        {
            /*
               var parcel = _context
               .Parcels
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
             */
            var parcel = _context
                .Parcels
                .SingleOrDefault(b => b.Id.Equals(id)); // returns null if not found

            if (parcel is null) return NotFound(); //404

            return Ok(parcel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost] // 
    public IActionResult CreateOneParcel([FromBody] Parcel parcel)
    {
        try
        {
            if (parcel is null) return BadRequest(); //400
            _context.Parcels.Add(parcel);
            _context.SaveChanges(); // saves it permanently

            return StatusCode(201, parcel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult
        UpdateOneParcel([FromRoute(Name = "id")] int id,
            [FromBody] Parcel parcel) //parcel object created to hold updated data
    {
        try
        {
            // check parcel? // is there a book or not
            /*
                    var entity = _context
                    .Parcels
                    .Where(b => b.Id.Equals(id))
                    .SingleOrDefault();
             */
            var entity = _context
                .Parcels
                .SingleOrDefault(b => b.Id.Equals(id));

            if (entity is null) return NotFound(); // 404
            // check id
            if (id != parcel.Id) return BadRequest(); // 400

            entity.ParcelNo = parcel.ParcelNo;
            entity.Layout = parcel.Layout;
            entity.Island = parcel.Island;
            entity.Province = parcel.Province;
            entity.District = parcel.District;
            entity.Neighbourhood = parcel.Neighbourhood;

            _context.SaveChanges();

            return Ok(parcel);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneParcel([FromRoute(Name = "id")] int id)
    {
        try
        {
            /*
             var entity = _context 
               .Parcels
               .Where(b => b.Id.Equals(id))
               .SingleOrDefault();
             */
            var entity = _context // Does the book you want to delete really exist?
                .Parcels
                .SingleOrDefault(b => b.Id.Equals(id));

            if (entity is null)
                return NotFound(
                    new
                    {
                        statusCode = 404,
                        message = $"Parcel with id:{id} could not found."
                    }); // 404

            _context.Parcels.Remove(entity);
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
       PUT > application/json
       PATCH > application/json-patch+json
     */
    public IActionResult PartiallyUpdateOnParcel([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Parcel> parcelPatch)
        //[FromBody] JsonPatchDocument<T>  used to bind data with parameters
    {
        try
        {
            var entity = _context
                .Parcels
                .SingleOrDefault(b => b.Id.Equals(id));

            if (entity is null) return NotFound(); //404

            parcelPatch.ApplyTo(entity);
            _context.SaveChanges();

            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}