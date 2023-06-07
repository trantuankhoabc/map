using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Location.Api.Entities.Models;
using Location.Api.Services.Contracts;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Location.Api.Presentation.Controllers;

[Route("api/Parcels")]
[ApiController]
public class ParcelsController : ControllerBase
{
    /* //DI 
         * 
         //private readonly RepositoryContext _context; 
         public ParcelsController(RepositoryContext context)
         {
            _context = context;
        */


    /*
     // Repository Manager
     private readonly IRepositoryManager _manager; 
     public ParcelsController(IRepositoryManager manager)
     {
         _manager = manager;

    */


    // service manager

    private readonly IServiceManager _manager;

    public ParcelsController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult GetAllParcels()

    {
        //var parcels = _context.Parcels.ToList();

        /* // Repository Manager  
         var parcels = _manager.Parcel.GetAllParcels(false); */

        // service manager
        var parcels = _manager.ParcelService.GetAllParcels(false);
        var geoJsonFeatureCollection = ConvertToGeoJson(parcels);

        // Return the FeatureCollection as a JSON object
        return Ok(geoJsonFeatureCollection);
    }


    [HttpGet("{id:int}")]
    public IActionResult
        GetOneParcel(
            [FromRoute(Name = "id")] int id) //  [FromRoute(Name = "id")] where the id will come from.
    {
        /* LINQ

         var parcel = ApplicationContext
            .Parcels
            .Where(b => b.Id.Equals(id))
            .SingleOrDefault();
         */
        try
        {
            /* var parcel = _context
            .Parcels
            .Where(b => b.Id.Equals(id))
            .SingleOrDefault();// returns null if not found
             if (parcel is null)
                 return NotFound(); //404

             return Ok(parcel);*/


            /*  // Repository Manager
              var parcel = _manager          
             .Parcel
             .GetOneParcelById(id, false); // false: monitor changes*/


            // service manager 
            var parcel = _manager
                .ParcelService
                .GetOneParcelById(id, false);


            if (parcel is null)
                return NotFound(); //404

            var geoJsonFeatureCollection = ConvertToGeoJson(new List<Parcel> { parcel });

            return Ok(geoJsonFeatureCollection);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost] //create source
    public IActionResult CreateOneParcel([FromBody] Parcel parcel)
    {
        try
        {
            if (parcel is null)
                return BadRequest(); // 400 

            /*  _context.Parcels.Add(parcel);
                _context.SaveChanges();// saves permanently*/


            /* // Repository Manager
            _manager.Parcel.CreateOneParcel(parcel);
            _manager.Save();*/


            // service manager
            _manager.ParcelService.CreateOneParcel(parcel);

            var geoJsonFeatureCollection = ConvertToGeoJson(new List<Parcel> { parcel });

            return StatusCode(201, geoJsonFeatureCollection);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneParcel([FromRoute(Name = "id")] int id,
        [FromBody] Parcel parcel)
    {
        try
        {
            if (parcel is null)
                return BadRequest(); // 400 

            /*// check parcel? -
            var entity = _context
                .Parcels
                .Where(b => b.Id.Equals(id))
                .SingleOrDefault();*/


            /* //Repository Manager
             var entity = _manager
             .Parcel
             .GetOneParcelById(id, true); // update changes are monitored
         if (entity is null)
             return NotFound(); // 404

         if (id != parcel.Id)   // check id
             return BadRequest(); // 400

         entity.ParcelNo = parcel.ParcelNo;
            entity.Layout = parcel.Layout;
            entity.Island = parcel.Island;
            entity.Province = parcel.Province;
            entity.District = parcel.District;
            entity.Neighbourhood = parcel.Neighbourhood;
            entity.Attribute = parcel.Attribute;


        // _context.SaveChanges();
           _manager.Save();
        return Ok(parcel);*/


            // service manager 
            _manager.ParcelService.UpdateOneParcel(id, parcel, true);
            return NoContent(); //204
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
            /*var entity = _context 
           .Parcels
           .Where(b => b.Id.Equals(id))
           .SingleOrDefault();*/


            /* //Repository Manager  
             var entity = _manager
             .Parcel
             .GetOneParcelById(id, false); // */


            /*_context.Parcels.Remove(entity);
              _context.SaveChanges();*/

            /* //Repository Manager
             _manager.Parcel.DeleteOneParcel(entity);
             _manager.Save();*/

            // service manager
            _manager.ParcelService.DeleteOneParcel(id, false);

            return NoContent();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPatch("{id:int}")]
    /* PUT > application/json
      PATCH > application/json-patch+json*/
    public IActionResult PartiallyUpdateOneParcel([FromRoute(Name = "id")] int id,
        [FromBody]
        JsonPatchDocument<Parcel> parcelPatch) //[FromBody] JsonPatchDocument<T>  used to bind data with parameters


    {
        try
        {
            /*var entity = _context
                .Parcels
                .FirstOrDefault(b => b.Id.Equals(id));*/

            /*//Repository Manager
            var entity = _manager
                .Parcel
                .GetOneParcelById(id, true);*/

            // service manager
            var entity = _manager
                .ParcelService
                .GetOneParcelById(id, true);


            if (entity is null)
                return NotFound(); // 404

            parcelPatch.ApplyTo(entity);

            //_context.SaveChanges();

            /*//Repository Manager
            _manager.Parcel.Update(entity);*/

            // service manager
            _manager.ParcelService.UpdateOneParcel(id, entity, true);

            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    //convert geojson 
    private static MultiPolygon ConvertGeometryToGeoJson(NetTopologySuite.Geometries.MultiPolygon ntsMultiPolygon)
    {
        var geoJsonMultiPolygon = new MultiPolygon(
            ntsMultiPolygon.Geometries.Select(ntsPolygon =>
                new Polygon(
                    new List<LineString>
                    {
                        new(
                            ntsPolygon.Coordinates.Select(ntsCoordinate =>
                                new Position(ntsCoordinate.Y, ntsCoordinate.X)).ToList()
                        )
                    }
                )).ToList()
        );

        return geoJsonMultiPolygon;
    }

    private static FeatureCollection ConvertToGeoJson(IEnumerable<Parcel> parcels)
    {
        var featureCollection = new FeatureCollection();

        foreach (var parcel in parcels)
        {
            var properties = new Dictionary<string, object>
            {
                { "Id", parcel.Id },
                { "ParcelNo", parcel.ParcelNo },
                { "Layout", parcel.Layout },
                { "Island", parcel.Island },
                { "Province", parcel.Province },
                { "District", parcel.District },
                { "Neighbourhood", parcel.Neighbourhood },
                { "Attribute", parcel.Attribute }
            };
            var geometry = ConvertGeometryToGeoJson(parcel.geom);

            var feature = new Feature(geometry, properties);
            featureCollection.Features.Add(feature);
        }

        return featureCollection;
    }
}