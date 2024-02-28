using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.MapModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IMapService
    {
        List<MapResponseModel> GetMaps();
        void CreateANewMap(MapCreatedModel mapCreatedModel);
        void UpdateANewMap(string id,MapUpdateModel mapUpdateModel);
        void DeleteAMap(string id);
        MapResponseModel GetMapById(string id);
    }
}
