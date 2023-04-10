namespace EmergencyRoadSideAssistanceService.Model
{
    public class GeoLocation
    {
        public double Latitude { get; set;}
        public double Longitude { get; set;}
        public int Distance { get; set; } = 0;

        public GeoLocation() { }

    }
}
