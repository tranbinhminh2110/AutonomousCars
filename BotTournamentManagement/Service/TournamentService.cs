using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IMapper _mapper;
        public TournamentService(ITournamentRepository tournamentRepository, IMapper mapper) 
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public void CreateNewTournament(TournamentCreatedModel tournamentCreatedModel)
        {
            var tournamentList = _tournamentRepository.GetAll();
            foreach (TournamentEntity tournament in tournamentList)
            {
                if (tournament.KeyId.Equals(tournamentCreatedModel.KeyId))
                {
                    throw new Exception("This tournament Id is existed !");
                }
            }
            var tournamentEntity = _mapper.Map<TournamentEntity>(tournamentCreatedModel);
            _tournamentRepository.Add(tournamentEntity);
        }

        public List<TournamentResponseModel> GetAllTournament()
        {
            var tournamentList = _tournamentRepository.GetAll();
            if (!tournamentList.Any())
            {
                throw new Exception("This tournament list is empty");
            }
            var responseTnmList = _mapper.Map<List<TournamentResponseModel>>(tournamentList);
            return responseTnmList;
        }
    }
}
