using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApplicationTimeZone.Models;
namespace WebApplicationTimeZone.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Dictionary<string, string> CountryTimeZones = new()
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

        public IActionResult Index()
        {
            var localTime = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

            var defaultCountry = "USA";
            var timeZoneId = CountryTimeZones[defaultCountry];

            var foreignTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.FindSystemTimeZoneById(timeZoneId)
            ).ToString("HH:mm:ss", CultureInfo.InvariantCulture);

            var model = new ModelTime
            {
                LocalTime = localTime,
                ForeignTime = foreignTime,
                SelectedCountry = defaultCountry,
                AvailableCountries = CountryTimeZones.Keys.ToList()
            };

            return View(model);
        }
    }
}
