using AutoMapper;
using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class TeamInMatchService : ITeamInMatchService
    {
        private readonly ITeamInMatchRepository _teamInMatchRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        public TeamInMatchService(ITeamInMatchRepository teamInMatchRepository, IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamInMatchRepository = teamInMatchRepository;
            _teamRepository = teamRepository;
        }
        public void AddTeamsToMatch()
        {
            throw new NotImplementedException();
        }

        public List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId)
        {
            var listTeamInMatch = _teamInMatchRepository.GetAll().ToList();
            if (!listTeamInMatch.Any())
            {
                throw new Exception("Empty Team in this match");
            }
            var listTeamInMatchResponse = new List<TeamInMatchResponseModel>();
            foreach (var team in listTeamInMatch)
            {
                var teamEntity = _teamRepository.GetById(team.TeamId);
                var teamResponseModel = _mapper.Map<TeamResponseModelWithoutPlayer>(teamEntity);
                TeamInMatchResponseModel responseModel = _mapper.Map<TeamInMatchResponseModel>(team);
                responseModel.teamResponse = teamResponseModel;
                listTeamInMatchResponse.Add(responseModel);
            }
            return listTeamInMatchResponse;

        }

        public void RemoveTeamFromMatch(string teamId)
        {
            throw new NotImplementedException();
        }

        public void UpdateFinalResult(TeamInMatchUpdateModel teamInMatchUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
