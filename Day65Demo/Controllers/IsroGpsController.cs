using Day65Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day65Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsroGpsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var random = new Random();
            var gpsResult = new GpsResult { Latitude = random.Next(-90, 90), Longitude = random.Next(-180, 180) };
            return Ok(gpsResult);
        }

        [HttpPost]
        public IActionResult Post(GpsResult gpsResult)
        {
            GpsBoundaryResult result;

            if (gpsResult.Latitude > 0 && gpsResult.Longitude < 0)
                result = new GpsBoundaryResult { IsInsideCountryBorders = true, Level = DangerLevel.Safe };
            else
                result = new GpsBoundaryResult
                {
                    IsInsideCountryBorders = false, 
                    Level = Faker.Enum.Random<DangerLevel>()
                };

            return Ok(result);
        }
    }
}
