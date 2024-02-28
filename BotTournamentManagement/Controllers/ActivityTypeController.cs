using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.ActivityModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class ActivityTypeController : ControllerBase
    {
        private readonly IActivityTypeService _activityTypeService;
        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            _activityTypeService = activityTypeService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.ActivityType.GetAllActivity)]
        public IActionResult GetActivityTypeList()
        {
            try
            {
                return Ok(_activityTypeService.GetAllActivityTypes());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.ActivityType.GetSingleActivity)]
        public IActionResult GetActivityTypeById(string id)
        {
            try
            {
                return Ok(_activityTypeService.GetActivityTypeById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route(WebApiEndpoint.ActivityType.CreateActivity)]
        public IActionResult CreateActivityType(ActivityTypeCreatedModel activityTypeCreatedModel)
        {
            try
            {
                _activityTypeService.CreateNewActivityType(activityTypeCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route(WebApiEndpoint.ActivityType.UpdateActivity)]
        public IActionResult UpdateActivityType(ActivityTypeUpdateModel model)
        {
            try
            {
                _activityTypeService.UpdateActivityType(model);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route(WebApiEndpoint.ActivityType.DeleteActivity)]
        public IActionResult DeleteActivityType(string id)
        {
            try
            {
                _activityTypeService.DeleteActivityType(id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

