using BotTournamentManagement.Data.RequestModel;
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
        public IActionResult UpdateAMap(string keyId, MapUpdateModel updateMap)
        {
            try
            {
                _mapService.UpdateANewMap(keyId, updateMap);
                return Ok("Updated Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        [Route("api/[controller]/delete-map")]
        public IActionResult Delete(string keyId)
        {
            try
            {
                _mapService.DeleteAMap(keyId);
                return Ok("Deleted Successfully !");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
