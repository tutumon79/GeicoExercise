using EmergencyRoadSideAssistanceService.Interface;
using EmergencyRoadSideAssistanceService.Model;

namespace EmergencyRoadSideAssistanceService.Utility
{
    public class ServiceUtility : IServiceUtility
    {
        public SortedSet<Assistant> CreateAssistants()
        {
            SortedSet<Assistant> assistantList = new SortedSet<Assistant>();
            var assistant = new Assistant()
            {
                CustomerId = "100",
                IsAvailable = false,
                ProviderdId = "P102",
                ProviderName = "Willis Roadways, Newyork",
                CurrentLocation = new GeoLocation { Latitude = 40.741895, Longitude = -73.989308, Distance = 1 },
                Customer = new Customer { CustomerId = "100", CustomerName = "Dipu Divakaran", CustomerPhone = "754-213-4115", PolicyList = new List<string> { "FRT32213KLD3345" }, VIN = "RTY43246GH4094343" }
            };
            assistantList.Add(assistant);
            assistant = new Assistant()
            {
                CustomerId = "",
                IsAvailable = true,
                ProviderdId = "P101",
                ProviderName = "Mack's Ligtning Service, New Jersey",
                CurrentLocation = new GeoLocation { Latitude = 40.67842773649348, Longitude = -74.13419020214843, Distance = 3 }
            };
            assistantList.Add(assistant);
            assistant = new Assistant()
            {
                CustomerId = "",
                IsAvailable = true,
                ProviderdId = "P103",
                ProviderName = "Tennasy Rockers",
                CurrentLocation = new GeoLocation { Latitude = 36.4293377884943, Longitude = -86.77988587976854, Distance = 4 }
            };
            assistantList.Add(assistant);
            assistant = new Assistant()
            {
                CustomerId = "",
                IsAvailable = true,
                ProviderdId = "P104",
                ProviderName = "Sandy Spring Champions",
                CurrentLocation = new GeoLocation { Latitude = 33.83349277358554, Longitude = -84.46151456827445, Distance = 5 }
            };
            assistantList.Add(assistant);
            assistant = new Assistant()
            {
                CustomerId = "",
                IsAvailable = true,
                ProviderdId = "P105",
                ProviderName = "JacksonVille Roadside Services",
                CurrentLocation = new GeoLocation { Latitude = 30.40795380187907, Longitude = -81.52491090704859, Distance = 2 }
            };
            assistantList.Add(assistant);
            assistant = new Assistant()
            {
                    CustomerId = "",
                    IsAvailable = true,
                    ProviderdId = "P106",
                    ProviderName = "Miami Road Side Assistance",
                    CurrentLocation = new GeoLocation { Latitude = 25.496096328338684, Longitude = -79.68426459307449, Distance = 6 }
            };
            assistantList.Add(assistant);
            return assistantList;
        }

        public GeoLocation CreateLocation()
        {
            return new GeoLocation { Latitude = 32.09105867304369, Longitude = -81.10338885041321 };
        }

        public Customer CreateCustomer()
        {
            return new Customer
            {
                CustomerId = "100",
                CustomerName = "Dipu Divakaran",
                CustomerPhone = "754-213-4115",
                PolicyList = new List<string> { "FRT32213KLD3345" },
                VIN = "RTY43246GH4094343"
            };
        }

        public bool ValidateModel(Assistant assistant, GeoLocation assistantLocation)
        {
            if ((assistant == null) || (string.IsNullOrEmpty(assistant.CustomerId)) || (assistantLocation == null))
                return false;
            return true;
        }
    }
}
