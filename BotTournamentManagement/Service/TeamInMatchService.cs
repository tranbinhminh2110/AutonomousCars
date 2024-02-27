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

        //public List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId)
        //{
        //    var listTeamInMatch = _teamInMatchRepository.GetAll().Where(p => p.MatchId.Equals(matchId));
        //    if (!listTeamInMatch.Any())
        //    {
        //        throw new Exception("Empty Team in this match");
        //    }
        //    foreach (var teamInMatch in listTeamInMatch)
        //    {
        //        var team = _teamRepository.GetById(teamInMatch.TeamId);
        //        var teamResponseModel = _mapper.Map<TeamResponseModel>(team);
                
        //    }
        //}

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
