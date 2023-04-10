using EmergencyRoadSideAssistanceService.Model;

namespace EmergencyRoadSideAssistanceService.Interface
{
    public interface IServiceUtility
    {
        bool ValidateModel(Assistant assistant, GeoLocation assistantLocation);
        SortedSet<Assistant> CreateAssistants();
        GeoLocation CreateLocation();
        Customer CreateCustomer();
    }
}
