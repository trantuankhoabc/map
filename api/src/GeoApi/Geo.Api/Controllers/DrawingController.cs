using Geo.Api.Business.Abstract;
using Geo.Api.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Features;
using System.Text;

namespace Geo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingController : ControllerBase
    {
        private readonly IGenericService<Building> _buildingService;

        public DrawingController(IGenericService<Building> buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("GetEmpty")]
        public IActionResult GetEmpty()
        {
            return Ok(new Building());
        }

        [HttpPut]
        [Route("ActivateAll")]
        public IActionResult ActivateAll()
        {
            if (!_buildingService.ActivateAll())
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route("RemoveIntersects")]
        public IActionResult RemoveIntersects([FromBody] FeatureCollection featureCollection)
        {
            if (featureCollection == null)
            {
                return BadRequest();
            }
            else if (featureCollection.Count == 0)
            {
                return BadRequest("No Feature Detected");
            }

            _buildingService.Remove(_buildingService.GetIntersectingItems(featureCollection));
            return Ok();
        }

        [HttpPost]
        [Route("GetIntersectingFeatures")]
        public IActionResult GetIntersectingFeatures([FromBody] FeatureCollection featureCollection)
        {
            if (featureCollection == null)
            {
                return BadRequest();
            }
            else if (featureCollection.Count == 0)
            {
                return BadRequest("No Feature Deleted");
            }

            var result = _buildingService.GetIntersectingItems(featureCollection);
            return Ok(result);
        }

        [HttpPost]
        [Route("GetBuilding")]
        public IActionResult GetBuilding(double[] coordinates)
        {
            if (coordinates == null)
            {
                return BadRequest();
            }

            Building building = _buildingService.GetItemFromCoordinates(coordinates);

            return Ok(building);
        }

        [HttpGet]
        [Route("Query")]
        public IActionResult Query(string attribute, string comparisionOperator, string input)
        {
            StringBuilder sql = new StringBuilder();
            //TODO: Fix SQL injection vulnerability
            //sql.AppendFormat($"SELECT * FROM public.buildings WHERE {attribute} {comparisionOperator} '{input}'");
            var result = _buildingService.GetBySqlQuery(attribute, comparisionOperator, input);
            return Ok(result);
        }
    }
}
