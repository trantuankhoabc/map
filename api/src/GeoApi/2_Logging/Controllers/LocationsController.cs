using _2_Logging.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2_Logging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly ILogger<LocationsController> _logger; //A variable marked readonly can only be initialized by the ctor or  where it is defined. Once initialized, its value cannot be changed

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        /*  DI
   
         * private readonly ILogger<LocationsController> _logger; // generate constructor

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;

        *ILogger<LocationsController> class specifies the source of logs generated in the LocationsController class. In this way, you can access these log messages anywhere in the application and easily identify which Controller or class originates it.
        }
        */

        [HttpGet]
        public IActionResult GetAllLocations()
        {
            var locations = new List<Location>()
            {
                new Location() {Id = 1, LocationName="L1", X= 35.1, Y=42.1},
                new Location() {Id = 2, LocationName="L2", X=35.1, Y= 42.2},
                new Location() {Id = 2, LocationName="L2", X=35.1, Y= 42.2},
            };
            _logger.LogInformation("GetAllLocation action has been called");
            return Ok(locations);
        }

        [HttpPost]
        public IActionResult GetAllLocations([FromBody] Location location)
        {
            _logger.LogWarning("Location has been created");
            return Ok(201);
        }
    }
}