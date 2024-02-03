using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IHighSchoolService
    {
        List<HighSchoolResponseModel> GetListHighSchools();
        HighSchoolResponseModel GetHighSchoolById(string id);
        void AddSchool(HighSchoolCreatedModel highSchoolCreatedModel);
        void UpdateSchool(string id, [FromForm] HighSchoolUpdateModel highSchoolUpdateModel);
        void DeleteSchool(string id);


    }
}
