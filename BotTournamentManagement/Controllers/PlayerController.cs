using BotTournamentManagement.Data.RequestModel.PlayModel;
using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpGet]
        [Route("/api/[controller]/get-all-players")]
        public IActionResult GetAllPlayersList()
        {
            try {
                return Ok(_playerService.GetAllPlayers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/get-players-by-team-id")]
        public IActionResult GetPlayerByTeamId(string teamId)
        {
            try
            {
                return Ok(_playerService.GetPlayerByTeamId(teamId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("/api/[controller]/get-players-by-id")]
        public IActionResult GetPlayerById(string Id)
        {
            try
            {
                return Ok(_playerService.GetPlayerById(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("/api/[controller]/create-new-player")]
        public IActionResult CreateNewPlayer(PlayerCreatedModel playerCreatedModel)
        {
            try
            {
                _playerService.CreateNewPlayer(playerCreatedModel);
                return Ok("Created Successfully!");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("/api/[controller]/update-player")]
        public IActionResult UpdateNewPlayer(PlayerUpdatedModel playerUpdatedModel)
        {
            try
            {
                _playerService.UpdatePlayer(playerUpdatedModel);
                return Ok("Updated Successfully!");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("/api/[controller]/delete-player")]
        public IActionResult DeletePlayer(string id)
        {
            try {
                _playerService.DeletePlayer(id);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
