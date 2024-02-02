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
            CreateMap<TournamentEntity, TournamentCreatedModel>().ReverseMap();
            CreateMap<TournamentEntity, TournamentResponseModel>().ReverseMap();
            CreateMap<TournamentEntity, TournamentUpdateModel>().ReverseMap();
            CreateMap<MapEntity, MapCreatedModel>().ReverseMap();
            CreateMap<MapEntity, MapResponseModel>().ReverseMap();
            CreateMap<MapEntity, MapUpdateModel>().ReverseMap();
            CreateMap<TeamEntity, TeamCreatedModel>().ReverseMap();
            CreateMap<TeamEntity, TeamUpdateModel>().ReverseMap();
            CreateMap<TeamEntity, TeamResponseModel>().ReverseMap();
            CreateMap<HighSchoolEntity, HighSchoolResponseModel>().ReverseMap();
            CreateMap<HighSchoolEntity, HighSchoolCreatedModel>().ReverseMap();
            CreateMap<HighSchoolEntity, HighSchoolUpdateModel>().ReverseMap();
        }
    }
}
