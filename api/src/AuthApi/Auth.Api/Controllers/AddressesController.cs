using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Auth.Api.Controllers
{
    // [ApiController]
    // [ApiVersion("1.0")]
    // [Route("v{v:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        // GET: api/<AddressesController>
        [HttpGet]
        public IEnumerable<Address> Get()
        {
            List<Address> addresses = new()
            {
                new Address { Name = "Trần Tuấn Khoa", HouseName = "TMT House", City = "Hồ Chí Minh", State = "Việt Nam", Pin = 690574 },
                new Address { Name = "TaBa", HouseName = "TMT House", City = "Hồ Chí Minh", State = "Việt Nam", Pin = 690574 },
                new Address { Name = "TaBa", HouseName = "TMT House", City = "Hồ Chí Minh", State = "Việt Nam", Pin = 690574 },
                new Address { Name = "TaBa", HouseName = "TMT House", City = "Hồ Chí Minh", State = "Việt Nam", Pin = 690574 },
            };
            return addresses;
        }
    }

    public class Address
    {
        public string Name { get; set; }
        public string HouseName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }
    }
}
