using EmergencyRoadSideAssistanceService.Model;

namespace EmergencyRoadSideAssistanceService.Interface
{
    public interface IGeoLocationUtility
    {
        double CalculateDistance(GeoLocation point1, GeoLocation point2);
    }
}
