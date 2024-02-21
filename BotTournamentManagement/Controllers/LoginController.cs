using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Interface.IService;
using DocnetCorePractice.Attribute;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public LoginController(IServiceProvider serviceProvider)
        {
            _authenticationService = serviceProvider.GetRequiredService<IAuthenticationService>();
        }

        [HttpPost]
        [Route("/api/[controller]/login")]
        public IActionResult Login(RequestLoginModel request)
        {
            try
            {
                return Ok(_authenticationService.Authenticator(request));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
