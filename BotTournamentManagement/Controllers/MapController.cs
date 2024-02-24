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
        [Route("api/[controller]/get-all-maps")]
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
        [Route("api/[controller]/get-a-map-by-id/")]
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
        [Route("api/[controller]/create-new-map")]
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
        [Route("api/[controller]/update-map")]
        public IActionResult UpdateAMap(MapUpdateModel updateMap)
        {
            try
            {
                _mapService.UpdateANewMap(updateMap);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-map")]
        public IActionResult DeleteMap(string Id)
        {
            try
            {
                _mapService.DeleteAMap(Id);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
