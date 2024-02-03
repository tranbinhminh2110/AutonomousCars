using BotTournamentManagement.Data.RequestModel;
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
        [Route("api/[controller]/get-all-activityTypes")]
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
        [Route("api/[controller]/get-a-activityType-by-id/")]
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
        [Route("api/[controller]/create-activityType")]
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
        [Route("api/[controller]/update-activityType")]
        public IActionResult UpdateActivityType(string id, ActivityTypeCreatedModel model)
        {
            try
            {
                _activityTypeService.UpdateActivityType(id, model);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-activityType")]
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

