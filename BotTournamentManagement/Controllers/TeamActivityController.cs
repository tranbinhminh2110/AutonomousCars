using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.TeamActivityModel;
using BotTournamentManagement.Data.RequestModel.TeamModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class TeamActivityController : ControllerBase
    {
        private readonly ITeamActivityService _teamActivityService;
        public TeamActivityController(ITeamActivityService teamActivityService)
        {
            _teamActivityService = teamActivityService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.TeamActivity.GetAllActivity)]
        public IActionResult GetAllListActivity()
        {
            try
            {
                return Ok(_teamActivityService.GetAllActivities());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.TeamActivity.GetAllActivityOfTeam)]
        public IActionResult GetAllActivitiesOfATeamInMatch(string teamInMatchId)
        {
            try
            {
                return Ok(_teamActivityService.GetAllActivitiesByTeamInMatchId(teamInMatchId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route(WebApiEndpoint.TeamActivity.SubmitActivity)]
        public IActionResult SubmitActivity(TeamActivitySubmitModel teamActivitySubmitModel)
        {
            try
            {
                _teamActivityService.AddNewActivity(teamActivitySubmitModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
