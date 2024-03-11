using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.TeamModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Authorization;
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
            [Route(WebApiEndpoint.Team.GetAllTeams)]
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
            [Route(WebApiEndpoint.Team.GetSingleTeam)]
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
            [Route(WebApiEndpoint.Team.CreateTeam)]
            [Authorize(Roles = "admin")]
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
            [Route(WebApiEndpoint.Team.UpdateTeam)]
            [Authorize(Roles = "admin")]
        public IActionResult UpdateATeam(string id,TeamUpdateModel model)
            {
                try
                {
                    _teamService.UpdateATeam(id, model);
                    return Ok("Updated Successfully !");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            [HttpDelete]
            [Authorize(Roles = "admin")]
            [Route(WebApiEndpoint.Team.DeleteTeam)]
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

