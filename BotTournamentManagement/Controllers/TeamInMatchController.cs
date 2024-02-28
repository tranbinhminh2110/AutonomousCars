using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Interface.IService;
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



    }
}
