using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;
        public MatchService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }
        public void CreateNewMatch(MatchCreatedModel matchCreatedModel)
        {
            var matchList = _matchRepository.GetAll();
            var matchEntity = _mapper.Map<MatchEntity>(matchCreatedModel);
            _matchRepository.Add(matchEntity);
        }

        public void DeleteMatch(string id)
        {
            var chosenMatch = _matchRepository.GetById(id);
            if (chosenMatch is null)
            {
                throw new Exception("This match is not existed");
            }
            else
            {
                _matchRepository.Delete(chosenMatch);
            }
        }

        public List<MatchResponseModel> GetAllMatches()
        {
            var matchList = _matchRepository.GetAll();
            if (!matchList.Any())
            {
                throw new Exception("This match list is empty");
            }
            var responseMatchList = _mapper.Map<List<MatchResponseModel>>(matchList);
            return responseMatchList;
        }

        public MatchResponseModel GetMatchById(string id)
        {
            var chosenMatch = _matchRepository.GetById(id);
            if (chosenMatch is null)
            {
                throw new Exception("This match is not existed");
            }
            var responseMatch = _mapper.Map<MatchResponseModel>(chosenMatch);
            return responseMatch;
        }

        public void UpdateMatch(string id, [FromForm] MatchCreatedModel matchCreatedModel)
        {
            var chosenMatch = _matchRepository.GetById(id);
            if (chosenMatch is null)
            {
                throw new Exception("This match is not existed");
            }
            var matchList = _matchRepository.GetAll();
            _mapper.Map(matchCreatedModel, chosenMatch);
            _matchRepository.Update(chosenMatch);
        }
    }
}
