using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BotTournamentManagement.Service
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IMapper _mapper;
        public MapService(IMapRepository mapRepository, IMapper mapper) 
        {
            _mapRepository = mapRepository;
            _mapper = mapper;

        }

        public void CreateANewMap(MapCreatedModel mapCreatedModel)
        {
            var existingMap = _mapRepository.GetAll().Where(p=>p.KeyId == mapCreatedModel.KeyId);
            if (existingMap.Any())
            {
                throw new Exception("This map Id is existed !");
            }
            var newMap = _mapper.Map<MapEntity>(mapCreatedModel);
            _mapRepository.Add(newMap);

        }

        public void DeleteAMap(string keyId)
        {
            var chosenMap = _mapRepository.GetAll().Where(p => p.KeyId.Equals(keyId)).FirstOrDefault();
            if (chosenMap is null)
            {
                throw new Exception("This map is not existed");
            }
            else 
            {
                _mapRepository.Delete(chosenMap);
            }
        }

        public List<MapResponseModel> GetMaps()
        {
            var mapList = _mapRepository.GetAll();
            if (!mapList.Any())
            {
                throw new Exception("This list is empty");
            }
            var responseMapList = _mapper.Map<List<MapResponseModel>>(mapList);
            return responseMapList;
        }

        public void UpdateANewMap(string keyId, [FromForm] MapUpdateModel mapUpdateModel)
        {
            var existingMap = _mapRepository.GetAll().Where(_ => _.KeyId == keyId).FirstOrDefault();
            if (existingMap is null) 
            {
                throw new Exception("This map is not existed");
            }
            var mapList = _mapRepository.GetAll();
            foreach (var map in mapList) {
                if (mapUpdateModel.KeyId.Equals(map.KeyId))
                {
                    throw new Exception("This map ID existed");
                }
            }
            _mapper.Map(mapUpdateModel, existingMap);
            _mapRepository.Update(existingMap);
        }

        

        
    }
}
