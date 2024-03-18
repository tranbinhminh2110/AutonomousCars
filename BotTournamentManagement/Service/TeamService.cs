using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.TeamModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;
        private readonly IHighSchoolRepository _highSchoolRepository;
        private readonly ITeamInMatchRepository _teamInMatchRepository;
        private readonly ITeamActivityRepository _teamActivityRepository;

        public TeamService(ITeamRepository teamRepository, IMapper mapper, IPlayerRepository playerRepository, IHighSchoolRepository highSchoolRepository, ITeamInMatchRepository teamInMatchRepository, ITeamActivityRepository teamActivityRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _playerRepository = playerRepository;
            _highSchoolRepository = highSchoolRepository;
            _teamInMatchRepository = teamInMatchRepository;
            _teamActivityRepository = teamActivityRepository;
        }

        public void CreateANewTeam(TeamCreatedModel teamCreatedModel)
        {
            var teamList = _teamRepository.GetAll().ToList();
            foreach (TeamEntity team in teamList)
            {
                if (team.KeyId.Equals(teamCreatedModel.KeyId))
                {
                    throw new Exception("This team Id is existed !");
                }
            }
            var teamEntity = _mapper.Map<TeamEntity>(teamCreatedModel);
            _teamRepository.Add(teamEntity);
        }

        public void DeleteATeam(string id)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("This team is not existed");
            }
            else
            {
                var playersofteam = _playerRepository.GetAll().Where(x => x.TeamId == id).ToList();
                foreach (var player in playersofteam)
                {
                    _playerRepository.Delete(player);
                }
                var teamInMatchList = _teamInMatchRepository.GetAll().Where(x => x.TeamId == id).ToList();
                foreach (var teamInMatch in teamInMatchList)
                {
                    var teamActivityList = _teamActivityRepository.GetAll().Where(x => x.TeamInMatchId == teamInMatch.Id).ToList();
                    foreach (var activity in teamActivityList)
                    {
                        _teamActivityRepository.Delete(activity);
                    }
                    _teamInMatchRepository.Delete(teamInMatch);
                }
                string deleteKeyId = chosenTeam.KeyId + "_H";
                var deletedList = _teamRepository.GetBothActiveandInactive().Where(x => x.KeyId.Contains(deleteKeyId)).ToList();
                chosenTeam.KeyId = (deleteKeyId + deletedList.Count()).ToString();
                _teamRepository.Update(chosenTeam);
                _teamRepository.Delete(chosenTeam);
            }
        }

        public List<TeamResponseModel> GetAllTeams()
        {
            var teamList = _teamRepository.GetAll().OrderBy(p => p.KeyId).ToList();
            var responseTeamList = _mapper.Map<List<TeamResponseModel>>(teamList);
            foreach (var team in responseTeamList)
            {
                var highSchoolEntity = _highSchoolRepository.GetById(team.HighSchoolId);
                team.HighSchoolName = highSchoolEntity.HighSchoolName;
            }
            return responseTeamList;
        }
        public List<PlayerResponseModel> getPlayerinTeam(string teamId)
        {
            var playerList = _playerRepository.GetAll().Where(p=>p.TeamId.Equals(teamId)).OrderBy(p => p.KeyId).ToList();
            var responsePlayersList = _mapper.Map<List<PlayerResponseModel>>(playerList);
            return responsePlayersList;
        }

        public TeamResponseModel GetTeamById(string id)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("Team doesn't existed"); 
            }
            var responseTeam = _mapper.Map<TeamResponseModel>(chosenTeam);
            var highSchoolEntity = _highSchoolRepository.GetById(chosenTeam.HighSchoolId);
            responseTeam.HighSchoolName = highSchoolEntity.HighSchoolName;
            return responseTeam;
        }

        public void UpdateATeam(string id, TeamUpdateModel teamUpdateModel)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("This team is not existed");
            }
            var teamList = _teamRepository.GetAll().ToList();
            foreach (var team in teamList)
            {
                if (team.KeyId.Equals(teamUpdateModel.KeyId) && !team.KeyId.Equals(chosenTeam.KeyId))
                {
                    throw new Exception("This team ID existed");
                }
            }
            _mapper.Map(teamUpdateModel, chosenTeam);
            _teamRepository.Update(chosenTeam);
        }

    }
}
