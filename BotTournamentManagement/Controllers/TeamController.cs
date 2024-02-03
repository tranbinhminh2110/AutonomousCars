using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
        [ApiController]
        public class TeamController : ControllerBase
        {
            private readonly ITeamService _teamService;
            public TeamController(ITeamService teamService)
            {
                _teamService = teamService;
            }
            [HttpGet]
            [Route("api/[controller]/get-all-teams")]
            public IActionResult GetTeamList()
            {
                try
                {
                    return Ok(_teamService.GetAllTeams());
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            [HttpGet]
            [Route("api/[controller]/get-a-team-by-id/")]
            public IActionResult GetTeamById(string id)
            {
                try
                {
                    return Ok(_teamService.GetTeamById(id));
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            [HttpPost]
            [Route("api/[controller]/create-team")]
            public IActionResult CreateTeam(TeamCreatedModel teamCreatedModel)
            {
                try
                {
                    _teamService.CreateANewTeam(teamCreatedModel);
                    return Ok("Created Successfully !");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            [HttpPut]
            [Route("api/[controller]/update-team")]
            public IActionResult UpdateATeam(string id, TeamUpdateModel model)
            {
                try
                {
                    _teamService.UpdateANewTeam(id, model);
                    return Ok("Updated Successfully !");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            [HttpDelete]
            [Route("api/[controller]/delete-team")]
            public IActionResult DeleteTeam(string id)
            {
                try
                {
                    _teamService.DeleteATeam(id);
                    return Ok("Deleted Successfully !");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
}

