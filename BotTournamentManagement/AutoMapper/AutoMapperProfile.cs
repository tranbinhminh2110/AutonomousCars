using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            TournamentMappingProfile();
            MapMappingProfile();
            TeamMappingProfile();
            RoundMappingProfile();
            HighSchoolMappingProfile();
            
        }
        public void TournamentMappingProfile()
        {
            CreateMap<TournamentEntity, TournamentCreatedModel>().ReverseMap();
            CreateMap<TournamentEntity, TournamentResponseModel>().ReverseMap();
            CreateMap<TournamentEntity, TournamentUpdateModel>().ReverseMap();
        }
        public void MapMappingProfile() 
        {
            CreateMap<MapEntity, MapCreatedModel>().ReverseMap();
            CreateMap<MapEntity, MapResponseModel>().ReverseMap();
            CreateMap<MapEntity, MapUpdateModel>().ReverseMap();
        }
        public void TeamMappingProfile() 
        {
            CreateMap<TeamEntity, TeamCreatedModel>().ReverseMap();
            CreateMap<TeamEntity, TeamUpdateModel>().ReverseMap();
            CreateMap<TeamEntity, TeamResponseModel>().ReverseMap();
            CreateMap<ActivityTypeEntity, ActivityTypeCreatedModel>().ReverseMap();
            CreateMap<ActivityTypeEntity, ActivityTypeResponseModel>().ReverseMap();
            CreateMap<MatchEntity, MatchCreatedModel>().ReverseMap();
            CreateMap<MatchEntity, MatchResponseModel>().ReverseMap();
        }
        public void HighSchoolMappingProfile()
        {
            CreateMap<HighSchoolEntity, HighSchoolResponseModel>().ReverseMap();
            CreateMap<HighSchoolEntity, HighSchoolCreatedModel>().ReverseMap();
            CreateMap<HighSchoolEntity, HighSchoolUpdateModel>().ReverseMap();
        }
        public void RoundMappingProfile()
        {
            CreateMap<RoundEntity, RoundCreatedModel>().ReverseMap();
            CreateMap<RoundEntity, RoundResponseModel>().ReverseMap();
            CreateMap<RoundEntity, RoundUpdateModel>().ReverseMap();
        }


    }
}
