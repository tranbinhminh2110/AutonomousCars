using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IMapService
    {
        List<MapResponseModel> GetMaps();
        void CreateANewMap(MapCreatedModel mapCreatedModel);
        void UpdateANewMap(string keyId,[FromForm] MapUpdateModel mapUpdateModel);
        void DeleteAMap(string keyId);
    }
}
