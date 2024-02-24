using BotTournamentManagement.Data.RequestModel.HighSchoolModel;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Service;
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
        [HttpGet]
        [Route("api/[controller]/get-all-schools")]
        public IActionResult GetMapList()
        {
            try
            {
                return Ok(_highSchoolService.GetListHighSchools());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/[controller]/create-new-school")]
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
        [HttpGet]
        [Route("api/[controller]/get-a-school-by-id/")]
        public IActionResult GetSchoolById(string id)
        {
            try
            {
                return Ok(_highSchoolService.GetHighSchoolById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route("api/[controller]/update-school")]
        public IActionResult UpdateASchool(HighSchoolUpdateModel highSchoolUpdateModel)
        {
            try
            {
                _highSchoolService.UpdateSchool(highSchoolUpdateModel);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-school")]
        public IActionResult DeleteSchool(string Id)
        {
            try
            {
                _highSchoolService.DeleteSchool(Id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



    }
}
