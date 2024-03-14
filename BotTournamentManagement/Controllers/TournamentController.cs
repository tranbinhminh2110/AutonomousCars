using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.TournamentModel;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Tournament.GetAllTournament)]
        public IActionResult GetTournamentList()
        {
            try
            {
                return Ok(_tournamentService.GetAllTournament());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.Tournament.GetSingleTournament)]
        public IActionResult GetTournamentById(string id)
        {
            try
            {
                return Ok(_tournamentService.GetTournamentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.Tournament.CreateTournament)]
        public IActionResult CreateTournament(TournamentCreatedModel tournamentCreatedModel)
        {
            try
            {
                _tournamentService.CreateNewTournament(tournamentCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.Tournament.UpdateTournament)]
        public IActionResult UpdateATournament(string id, TournamentUpdateModel tournamentUpdateModel)
        {
            try
            {
                _tournamentService.UpdateTournament(id,tournamentUpdateModel);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Authorize(Roles = "Organizer")]
        [Route(WebApiEndpoint.Tournament.DeleteTournament)]
        public IActionResult DeleteTournament(string id)
        {
            try
            {
                _tournamentService.DeleteTournament(id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
