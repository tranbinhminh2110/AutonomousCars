using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Service
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IMapper _mapper;
        public RoundService(IRoundRepository roundRepository, IMapper mapper)
        {
            _roundRepository = roundRepository;
            _mapper = mapper;

        }
        public void AddNewRound(RoundCreatedModel roundCreatedModel)
        {
            var existingRound = _roundRepository.GetAll().Where(p=>p.RoundName.Equals(roundCreatedModel.RoundName)).ToList();
            if (existingRound.Any())
            {
                throw new Exception("This round is existed !");
            }
            var newRound = _mapper.Map<RoundEntity>(roundCreatedModel);
            _roundRepository.Add(newRound);
        }

        public void DeleteRound(string id)
        {
            var chosenRound = _roundRepository.GetById(id);
            if (chosenRound is null)
            {
                throw new Exception("This round is not existed");
            }
            else
            {
                _roundRepository.Delete(chosenRound);
            }
        }

        public List<RoundResponseModel> getAllRoundList()
        {
            var roundList = _roundRepository.GetAll().ToList();
            if (!roundList.Any())
            {
                throw new Exception("This list is empty");
            }
            var responseRoundList = _mapper.Map<List<RoundResponseModel>>(roundList);
            return responseRoundList;
        }

        public RoundResponseModel getRoundById(string id)
        {
            var chosenRound = _roundRepository.GetById(id);
            if (chosenRound is null)
            {
                throw new Exception("This round is not existed");
            }
            var responseRound = _mapper.Map<RoundResponseModel>(chosenRound);
            return responseRound;
        }

        public void UpdateRound(string id, RoundUpdateModel roundUpdateModel)
        {
            var existingRound = _roundRepository.GetById(id);
            if (existingRound is null)
            {
                throw new Exception("This round is not existed");
            }
            var roundList = _roundRepository.GetAll();
            foreach (var round in roundList)
            {
                if (roundUpdateModel.RoundName.ToLower().Equals(round.RoundName.ToLower()))
                {
                    throw new Exception("This round is existed");
                }
            }
            _mapper.Map(roundUpdateModel, existingRound);
            _roundRepository.Update(existingRound);
        }
    }
}
