using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("api/[controller]/get-all-user")]
        public IActionResult GetUserList()
        {
            try
            {
                return Ok(_userService.GetUsersList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/[controller]/get-a-user-by-id/")]
        public IActionResult GetUserById(string id)
        {
            try
            {
                return Ok(_userService.GetUserById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("api/[controller]/create-new-user")]
        public IActionResult CreateNewUser(UserRequestModel userRequestModel)
        {
            try
            {
                _userService.AddNewUser(userRequestModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/update-user")]
        public IActionResult UpdateAUser(string id, UserRequestModel userRequestModel)
        {
            try
            {
                _userService.UpdateUser(id, userRequestModel);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-user")]
        public IActionResult DeleteUser(string Id)
        {
            try
            {
                _userService.DeleteUser(Id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("api/[controller]/search-user")]
        public IActionResult SearchUser(string searchKey)
        {
            try
            {
                return Ok(_userService.SearchUser(searchKey));
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }


    }
}
