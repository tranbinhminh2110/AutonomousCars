using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.MatchModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Match.GetAllMatches)]
        public IActionResult GetMatchList()
        {
            try
            {
                return Ok(_matchService.GetAllMatches());
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.Match.GetSingleMatch)]
        public IActionResult GetMatchById(string id)
        {
            try
            {
                return Ok(_matchService.GetMatchById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.Match.CreateMatch)]
        public IActionResult CreateMatch(MatchCreatedModel matchCreatedModel)
        {
            try
            {
                _matchService.CreateNewMatch(matchCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.Match.UpdateMatch)]
        public IActionResult UpdateMatch(string id, MatchUpdateModel matchUpdateModel)
        {
            try
            {
                _matchService.UpdateMatch(id,matchUpdateModel);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.Match.GetAllMatchesInTournament)]
        public IActionResult GetAllMatchesInTournament(string tournamentId) 
        {
            try 
            {
                return Ok(_matchService.GetMatchesInTournament(tournamentId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route(WebApiEndpoint.Match.DeleteMatch)]
        public IActionResult DeleteMatch(string id)
        {
            try
            {
                _matchService.DeleteMatch(id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

