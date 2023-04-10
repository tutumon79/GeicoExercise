using EmergencyRoadSideAssistanceService.Model;
using EmergencyRoadSideAssistanceService.Utility;

namespace EmergencyRoadSideAssistanceService.Interface
{
    public interface IRoadsideAssistanceService
    {
        /** * This method is used to update the location of the roadside assistance service provider. 
         * * * @param assistant represents the roadside assistance service provider * 
         * @param assistantLocation represents the location of the roadside assistant */
        void updateAssistantLocation(Assistant assistant, GeoLocation assistantLocation); /**
        /** * This method returns a collection of roadside assistants ordered by their distance from the input geo location. 
        * * @param geoLocation - geoLocation from which to search for assistants 
        * * @param limit - the number of assistants to return * 
        * @return a sorted collection of assistants ordered ascending by distance from geoLocation */
        SortedSet<Assistant> findNearestAssistants(GeoLocation geoLocation, int limit); 
        /** * This method reserves an assistant for a Geico customer that is stranded on the roadside due to a disabled vehicle. 
         * * * @param customer - Represents a Geico customer * @param customerLocation - Location of the customer * 
         * @return The Assistant that is on their way to help */ 
        Optional<Assistant> reserveAssistant(Customer customer, GeoLocation customerLocation); 
        /** * This method releases an assistant either after they have completed work, or the customer no longer needs help. 
         * * * @param customer - Represents a Geico customer * 
         * @param assistant - An assistant that was previously reserved by the customer */ 
        void releaseAssistant(Customer customer, Assistant assistant);
    }
}
