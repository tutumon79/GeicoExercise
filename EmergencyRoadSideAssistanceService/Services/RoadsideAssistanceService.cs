using EmergencyRoadSideAssistanceService.Interface;
using EmergencyRoadSideAssistanceService.Model;
using EmergencyRoadSideAssistanceService.Utility;

namespace EmergencyRoadSideAssistanceService.Services
{
    public class RoadsideAssistanceService : IRoadsideAssistanceService
    {
        private readonly IGeoLocationUtility _geoLocationUtility;
        private readonly IServiceUtility _serviceUtility;
        private SortedSet<Assistant> assistantsList;

        public RoadsideAssistanceService() 
        {
            //Initialize the objects
            
        }
        public RoadsideAssistanceService(IGeoLocationUtility geoLocationUtility, IServiceUtility serviceUtility)
        {
            _geoLocationUtility= geoLocationUtility;
            _serviceUtility= serviceUtility;
            assistantsList = _serviceUtility.CreateAssistants();
        }
        public SortedSet<Assistant> findNearestAssistants(GeoLocation geoLocation, int limit)
        {
            foreach(var item in assistantsList)
            {
                var distance = _geoLocationUtility.CalculateDistance(geoLocation, item.CurrentLocation);
                item.CurrentLocation.Distance = Convert.ToInt32(Math.Round(distance));
            }
            //Collect the specified number of items from the sorted list
            var seletedItems = new SortedSet<Assistant>(assistantsList.Reverse().Take(limit));
            return seletedItems;
        }

        public void releaseAssistant(Customer customer, Assistant assistant)
        {
            try
            {
                //Find the assistant assigned to the customer from the assistantList(In memory object)
                var assignedcustomer = assistantsList.FirstOrDefault(x => x.CustomerId == customer.CustomerId);
                if (assignedcustomer != null)
                {
                    assignedcustomer.Customer = null;
                    assignedcustomer.CustomerId = "";
                    assignedcustomer.IsAvailable = true;
                    //TODO : In realworld this state change should be persisted in database, instead of updating the in memory collection
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Optional<Assistant> reserveAssistant(Customer customer, GeoLocation customerLocation)
        {
            Assistant selectedAssistant = new Assistant();
            try
            {
                var availableAssistants = findNearestAssistants(customerLocation, 3);
                if(availableAssistants != null)
                {
                    selectedAssistant = availableAssistants.FirstOrDefault(x => x.IsAvailable);
                    if(selectedAssistant != null)
                    {
                        selectedAssistant.IsAvailable = false;
                        selectedAssistant.Customer = customer;
                        selectedAssistant.CustomerId = customer.CustomerId;
                        //TODO : Persist the selected assistant with updated state into database.
                    }
                }
                return (Optional<Assistant>)selectedAssistant;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void updateAssistantLocation(Assistant assistant, GeoLocation assistantLocation)
        {
            assistant.CurrentLocation = assistantLocation;
            //TODO : Persist the object to DB using EF Core.
        }
    }
}
