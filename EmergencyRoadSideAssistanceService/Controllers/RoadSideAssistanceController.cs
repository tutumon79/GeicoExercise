using EmergencyRoadSideAssistanceService.Interface;
using EmergencyRoadSideAssistanceService.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmergencyRoadSideAssistanceService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoadSideAssistanceController : ControllerBase
    {
        private readonly IRoadsideAssistanceService _roadsideAssistanceService;
        private readonly IServiceUtility _serviceUtility;
        private readonly SortedSet<Assistant> _assistantsList;
        private Customer _customer;
        private GeoLocation _newLocation;

        //public RoadSideAssistanceController() { }
        public RoadSideAssistanceController(IRoadsideAssistanceService roadsideAssistanceService, IServiceUtility serviceUtility)
        {
            _roadsideAssistanceService = roadsideAssistanceService;
            _serviceUtility = serviceUtility;
            //Initialize the objects
            _assistantsList = _serviceUtility.CreateAssistants();
            _newLocation = _serviceUtility.CreateLocation();
            _customer = _serviceUtility.CreateCustomer();
        }

        [HttpPut(Name = "updateAssistantLocation")]
        public IActionResult PutAssistantLocation()
        {
            try
            {
                //TODO: Read Model from the body, which is left open. Instead using the pre-initialized Assistants and GeoLocation.
                //Perfrom Validation on the model
                if (!_serviceUtility.ValidateModel(_assistantsList.FirstOrDefault(), _newLocation)){
                    return BadRequest("Invalid Input received");
                }
                _roadsideAssistanceService.updateAssistantLocation(_assistantsList.FirstOrDefault(), _newLocation);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Service Failure");
            }
        }

        [HttpGet(Name = "GetNearestAssistants")]
        public IActionResult GetNearestAssistants()
        {
            //TODO: Read Model from the body, which is left open. Instead using the pre-initialized Assistants and GeoLocation.
            int limit = 5;
            try
            {
                //Perfrom Validation on the model
                if (_newLocation == null)
                {
                    return BadRequest("Invalid Input received");
                }
                var locations = _roadsideAssistanceService.findNearestAssistants(_newLocation, limit);
                return Ok(locations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Service Failure");
            }
        }

        [HttpPut(Name = "ReserveAssistant")]
        public IActionResult ReserveAssistant()
        {
            //TODO: Read Model from the body, which is left open. Instead using the pre-initialized Assistants and GeoLocation.
            
            try
            {
                //Perfrom Validation on the model
                if (_newLocation == null || _customer == null)
                {
                    return BadRequest("Invalid Input received");
                }
                var assistant = _roadsideAssistanceService.reserveAssistant(_customer, _newLocation);
                return Ok(assistant);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Service Failure");
            }
        }

        [HttpPut(Name = "ReleaseAssistant")]
        public IActionResult ReleaseAssistant()
        {
            //TODO: Read Model from the body, which is left open. Instead using the pre-initialized Assistants and GeoLocation.

            try
            {
                //Perfrom Validation on the model
                if (_newLocation == null || _customer == null)
                {
                    return BadRequest("Invalid Input received");
                }
                _roadsideAssistanceService.releaseAssistant(_customer, _assistantsList.FirstOrDefault());
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Service Failure");
            }
        }
    }
}
