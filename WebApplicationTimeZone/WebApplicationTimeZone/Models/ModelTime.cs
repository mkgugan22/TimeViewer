namespace WebApplicationTimeZone.Models
{
    public class ModelTime
    {
        public string LocalTime { get; set; }
        public string ForeignTime { get; set; }
        public string SelectedCountry { get; set; }
        public List<string> AvailableCountries { get; set; }
    }
}
