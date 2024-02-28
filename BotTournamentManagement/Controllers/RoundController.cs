using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _roundService;
        public RoundController(IRoundService roundService)
        {
            _roundService = roundService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Round.GetAllRounds)]
        public IActionResult GetRoundList()
        {
            try
            {
                return Ok(_roundService.getAllRoundList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.Round.GetSingleRound)]
        public IActionResult GetRoundById(string id)
        {
            try
            {
                return Ok(_roundService.getRoundById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route(WebApiEndpoint.Round.CreateRound)]
        public IActionResult CreateNewRound(RoundCreatedModel roundCreatedModel)
        {
            try
            {
                _roundService.AddNewRound(roundCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route(WebApiEndpoint.Round.UpdateRound)]
        public IActionResult UpdateAMap(string id, RoundUpdateModel roundUpdateModel)
        {
            try
            {
                _roundService.UpdateRound(id, roundUpdateModel);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route(WebApiEndpoint.Round.DeleteRound)]
        public IActionResult DeleteMap(string Id)
        {
            try
            {
                _roundService.DeleteRound(Id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
