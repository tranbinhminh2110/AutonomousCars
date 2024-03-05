using BotTournamentManagement.Constant;
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
        [Route(WebApiEndpoint.Player.GetAllPlayers)]
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
        [Route(WebApiEndpoint.Player.GetPlayersByTeamId)]
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
        [Route(WebApiEndpoint.Player.GetSinglePlayer)]
        public IActionResult GetPlayerById(string id)
        {
            try
            {
                return Ok(_playerService.GetPlayerById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route(WebApiEndpoint.Player.CreatePlayer)]
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
        [Route(WebApiEndpoint.Player.UpdatePlayer)]
        public IActionResult UpdatePlayer(string id, PlayerUpdatedModel playerUpdatedModel)
        {
            try
            {
                _playerService.UpdatePlayer(id, playerUpdatedModel);
                return Ok("Updated Successfully!");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route(WebApiEndpoint.Player.DeletePlayer)]
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
