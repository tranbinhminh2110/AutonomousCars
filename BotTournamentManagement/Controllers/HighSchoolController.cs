using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class HighSchoolController : ControllerBase
    {
        private readonly IHighSchoolService _highSchoolService;
        public HighSchoolController(IHighSchoolService highSchoolService)
        {
            _highSchoolService = highSchoolService;
        }
        
        [HttpPost]
        [Route("api/[controller]/create-new-map")]
        public IActionResult CreateNewSchool(HighSchoolCreatedModel highSchoolCreatedModel)
        {
            try
            {
                _highSchoolService.AddSchool(highSchoolCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        


    }
}
