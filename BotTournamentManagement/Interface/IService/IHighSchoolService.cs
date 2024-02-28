using BotTournamentManagement.Data.RequestModel.HighSchoolModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IHighSchoolService
    {
        List<HighSchoolResponseModel> GetListHighSchools();
        HighSchoolResponseModel GetHighSchoolById(string id);
        void AddSchool(HighSchoolCreatedModel highSchoolCreatedModel);
        void UpdateSchool(string id, HighSchoolUpdateModel highSchoolUpdateModel);
        void DeleteSchool(string id);


    }
}
