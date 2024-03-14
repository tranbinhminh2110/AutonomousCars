using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Authorization;
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
        [Route(WebApiEndpoint.User.GetAllUser)]
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
        [Route(WebApiEndpoint.User.GetSingleUser)]
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
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.User.CreateUser)]
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
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.User.UpdateUser)]
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
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.User.DeleteUser)]
        public IActionResult DeleteUser(string id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.User.SearchUser)]
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
