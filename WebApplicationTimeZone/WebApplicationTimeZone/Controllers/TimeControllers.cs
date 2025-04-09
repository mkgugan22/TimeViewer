using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace WebApplicationTimeZone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimeController : ControllerBase
    {
        private  static readonly Dictionary<string, string> CountryTimeZones = new()
        {
            { "USA", "Eastern Standard Time" },
            { "India", "India Standard Time" },
            { "Japan", "Tokyo Standard Time" },
            { "UK", "GMT Standard Time" },
            { "Germany", "W. Europe Standard Time" },
            { "Australia", "AUS Eastern Standard Time" },
            { "Brazil", "E. South America Standard Time" },
            { "China", "China Standard Time" },
            { "South Africa", "South Africa Standard Time" },
            { "Russia", "Russian Standard Time" },
            { "Canada", "Canada Central Standard Time" },
            { "Mexico", "Mexico Standard Time" },
            { "UAE", "Arabian Standard Time" },
            { "Singapore", "Singapore Standard Time" },
            { "New Zealand", "New Zealand Standard Time" }
        };

        [HttpGet("{country}")]
        public IActionResult GetTime(string country)
        {
            if (!CountryTimeZones.TryGetValue(country, out var timeZoneId))
            {
                return BadRequest("Invalid country name.");
            }

            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
                var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
                var formatted = time.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

                return Ok(new { time = formatted });
            }
            catch
            {
                return BadRequest("Unable to convert time.");
            }
        }
    }
}
