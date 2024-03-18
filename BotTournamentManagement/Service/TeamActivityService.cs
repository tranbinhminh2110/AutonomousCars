using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.TeamActivityModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class TeamActivityService : ITeamActivityService
    {
        private readonly ITeamActivityRepository _teamActivityRepository;
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamInMatchRepository _teamInMatchRepository;
        private readonly IMatchRepository _matchRepository;

        private readonly IMapper _mapper;
        public TeamActivityService(IMapper mapper, ITeamRepository teamRepository, ITeamActivityRepository teamActivityRepository, IActivityTypeRepository activityTypeRepository, ITeamInMatchRepository teamInMatchRepository, IMatchRepository matchRepository)
        {
            _teamActivityRepository = teamActivityRepository;
            _teamRepository = teamRepository;
            _mapper = mapper;
            _activityTypeRepository = activityTypeRepository;
            _teamInMatchRepository = teamInMatchRepository;
            _matchRepository = matchRepository;
        }
        public void AddNewActivity(TeamActivitySubmitModel teamActivitySubmitModel)
        {
            var newActivity = _mapper.Map<TeamActivityEntity>(teamActivitySubmitModel);
            if (newActivity.Duration != null)
            {
                newActivity.Duration = TimeSpan.Parse(teamActivitySubmitModel.Duration);
            }
            _teamActivityRepository.Add(newActivity);
        }

        public List<TeamActivityResponseModel> GetAllActivities()
        {
            var activityList = _teamActivityRepository.GetAll().ToList();
            var responseActivityList = _mapper.Map<List<TeamActivityResponseModel>>(activityList);
            foreach (var activityResponse in responseActivityList)
            {
                var activityTypeEntity = _activityTypeRepository.GetById(activityResponse.ActivityTypeId);
                activityResponse.ActivityTypeName = activityTypeEntity.TypeName;
                var teamInMatch = _teamInMatchRepository.GetById(activityResponse.TeamInMatchId);
                var teamEntity = _teamRepository.GetById(teamInMatch.TeamId);
                activityResponse.TeamId = teamEntity.Id;
                activityResponse.TeamKeyId = teamEntity.KeyId;
                activityResponse.TeamName = teamEntity.TeamName;
                var matchEntity = _matchRepository.GetById(teamInMatch.MatchId);
                activityResponse.MatchId = matchEntity.Id;
                activityResponse.MatchKeyId = matchEntity.KeyId;
            }
            return responseActivityList;
        }

        public List<TeamActivityResponseModel> GetAllActivitiesByTeamInMatchId(string teamInMatchId)
        {
            var chosenTeamActivitiesList = _teamActivityRepository.GetAll().Where(p=>p.TeamInMatchId.Equals(teamInMatchId)).ToList();
            var responseActivityList = _mapper.Map<List<TeamActivityResponseModel>>(chosenTeamActivitiesList);
            foreach (var activityResponse in responseActivityList)
            {
                var activityTypeEntity = _activityTypeRepository.GetById(activityResponse.ActivityTypeId);
                activityResponse.ActivityTypeName = activityTypeEntity.TypeName;
                var teamInMatch = _teamInMatchRepository.GetById(activityResponse.TeamInMatchId);
                var teamEntity = _teamRepository.GetById(teamInMatch.TeamId);
                activityResponse.TeamId = teamEntity.Id;
                activityResponse.TeamKeyId = teamEntity.KeyId;
                activityResponse.TeamName = teamEntity.TeamName;
                var matchEntity = _matchRepository.GetById(teamInMatch.MatchId);
                activityResponse.MatchId = matchEntity.Id;
                activityResponse.MatchKeyId = matchEntity.KeyId;
            }
            return responseActivityList;

        }

        public void RemoveActivity(string id)
        {
            throw new NotImplementedException();
        }
    }
}
