using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.MapModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace BotTournamentManagement.Service
{
    public class MapService : IMapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;
        public MapService(IMapRepository mapRepository, IMapper mapper, IMatchRepository matchRepository) 
        {
            _mapRepository = mapRepository;
            _mapper = mapper;
            _matchRepository = matchRepository;

        }

        public void CreateANewMap(MapCreatedModel mapCreatedModel)
        {
            var existingMap = _mapRepository.GetAll().Where(p=>p.KeyId == mapCreatedModel.KeyId).FirstOrDefault();
            if (existingMap is not null)
            {
                throw new Exception("This map Id is existed !");
            }
            var newMap = _mapper.Map<MapEntity>(mapCreatedModel);
            _mapRepository.Add(newMap);

        }

        public void DeleteAMap(string id)
        {
            var chosenMap = _mapRepository.GetById(id);
            if (chosenMap is null)
            {
                throw new Exception("This map is not existed");
            }
            else 
            {
                var matchWithMap = _matchRepository.GetAll().Where(x => x.MapId.Equals(id)).ToList();
                if (matchWithMap.Any())
                {
                    throw new Exception("This map is using in some matches");
                }
                string deleteKeyId = chosenMap.KeyId + "_H";
                var deletedList = _mapRepository.GetBothActiveandInactive().Where(x => x.KeyId.Contains(deleteKeyId)).ToList();
                chosenMap.KeyId = (deleteKeyId + deletedList.Count()).ToString();
                _mapRepository.Update(chosenMap);
                _mapRepository.Delete(chosenMap);
            }
        }

        public MapResponseModel GetMapById(string id)
        {
            var chosenMap = _mapRepository.GetById(id);
            if (chosenMap is null)
            {
                throw new Exception("This map is not existed");
            }
            var responseMap = _mapper.Map<MapResponseModel>(chosenMap);
            return responseMap;

        }

        public List<MapResponseModel> GetMaps()
        {
            var mapList = _mapRepository.GetAll().OrderBy(x => x.KeyId).ToList();
            var responseMapList = _mapper.Map<List<MapResponseModel>>(mapList);
            return responseMapList;
        }

        public void UpdateANewMap(string id, MapUpdateModel mapUpdateModel)
        {
            var existingMap = _mapRepository.GetById(id);
            if (existingMap is null) 
            {
                throw new Exception("This map is not existed");
            }
            var mapList = _mapRepository.GetAll().ToList();
            foreach (var map in mapList) {
                if (mapUpdateModel.KeyId.Equals(map.KeyId) && !map.KeyId.Equals(existingMap.KeyId))
                {
                    throw new Exception("This map ID existed");
                }
            }
            _mapper.Map(mapUpdateModel, existingMap);
            _mapRepository.Update(existingMap);
        }

        

        
    }
}
