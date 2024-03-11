using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class TeamInMatchController : ControllerBase
    {
        private readonly ITeamInMatchService _teamInMatchService;
        public TeamInMatchController(ITeamInMatchService teamInMatchService)
        {
            _teamInMatchService = teamInMatchService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.TeamInMatch.GetAllTeamsInAMatch)]
        public IActionResult GetTeamListInAMatch(string matchId)
        {
            try
            {
                return Ok(_teamInMatchService.GetTeamInAMatch(matchId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.TeamInMatch.GetTeamInMatchById)]
        public IActionResult GetTeamInMatchById(string id)
        {
            try
            {
                return Ok(_teamInMatchService.GetTeamInMatchById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.TeamInMatch.AddATeamToMatch)]
        public IActionResult AddATeamToMatch(TeamInMatchCreatedModel teamInMatchCreatedModel)
        {
            try
            {
                _teamInMatchService.AddTeamToMatch(teamInMatchCreatedModel);
                return Ok("Added successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.TeamInMatch.DeleteTeamFromMatch)]
        public IActionResult DeleteATeamFromMatch(string id)
        {
            try
            {
                _teamInMatchService.RemoveTeamFromMatch(id);
                return Ok("Deleted successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.TeamInMatch.UpdateResultForTeamInMatch)]
        public IActionResult UpdateFinalResultForTeamInMatch(string id, TeamInMatchUpdateModel teamInMatchUpdateModel)
        {
            try
            {
                _teamInMatchService.UpdateFinalResult(id, teamInMatchUpdateModel);
                return Ok("Update successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
