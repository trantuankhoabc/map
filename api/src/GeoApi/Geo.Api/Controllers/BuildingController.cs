using Geo.Api.Business.Abstract;
using Geo.Api.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Geo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IGenericService<Building> _buildingService;

        public BuildingController(IGenericService<Building> buildingService)
        {
            _buildingService = buildingService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllBuildings()
        {
            return Ok(_buildingService.GetAll());
        }
    }
}
