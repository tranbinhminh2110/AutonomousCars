using BotTournamentManagement.Data.RequestModel;
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
        [Route("api/[controller]/get-all-rounds")]
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
        [Route("api/[controller]/get-a-round-by-id/")]
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
        [Route("api/[controller]/create-new-round")]
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
        [Route("api/[controller]/update-round")]
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
        [Route("api/[controller]/delete-round")]
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
