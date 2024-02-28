using BotTournamentManagement.Constant;
using BotTournamentManagement.Data.RequestModel.MapModel;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Controllers
{
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;
        public MapController(IMapService mapService) { 
            _mapService = mapService;
        }
        [HttpGet]
        [Route(WebApiEndpoint.Map.GetAllMap)]
        public IActionResult GetMapList() {
            try
            {
                return Ok(_mapService.GetMaps());
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route(WebApiEndpoint.Map.GetSingleMap)]
        public IActionResult GetMapById(string id)
        {
            try
            {
                return Ok(_mapService.GetMapById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route(WebApiEndpoint.Map.CreateMap)]
        public IActionResult CreateNewMap(MapCreatedModel mapCreatedModel) 
        {
            try
            {
                _mapService.CreateANewMap(mapCreatedModel);
                return Ok("Created Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        [Route(WebApiEndpoint.Map.UpdateMap)]
        public IActionResult UpdateAMap(string id, MapUpdateModel updateMap)
        {
            try
            {
                _mapService.UpdateANewMap(id,updateMap);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route(WebApiEndpoint.Map.DeleteMap)]
        public IActionResult DeleteMap(string id)
        {
            try
            {
                _mapService.DeleteAMap(id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
