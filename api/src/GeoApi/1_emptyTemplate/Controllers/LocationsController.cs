using _1_emptyTemplate.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_emptyTemplate.Controllers
{
    [Route("api/[controller]")] //// to reach the relevant endpoint
    [ApiController] // For Controller to support API structure
    public class LocationsController : ControllerBase
    {
        // [HttpGet]
        // public string Getmessage()
        // {
        //     return "hi !";
        // }

        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new Location()
            {
                HttpStatus = 200,
                Message = "hello map api"
            };

            return Ok(result);
        }

    }
}

