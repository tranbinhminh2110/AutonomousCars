using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Service;
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
        [Route("api/[controller]/get-all-tournaments")]
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
        [Route("api/[controller]/get-a-tournament-by-id/")]
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
        [Route("api/[controller]/create-tournament")]
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
        [Route("api/[controller]/update-tournament")]
        public IActionResult UpdateATournament(string id, TournamentUpdateModel model)
        {
            try
            {
                _tournamentService.UpdateTournament(id, model);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-tournament")]
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
