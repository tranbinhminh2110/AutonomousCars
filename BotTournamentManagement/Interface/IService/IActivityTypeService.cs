using BotTournamentManagement.Data.RequestModel.ActivityModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IActivityTypeService
    {
        List<ActivityTypeResponseModel> GetAllActivityTypes();
        void CreateNewActivityType(ActivityTypeCreatedModel activityTypeCreatedModel);
        void UpdateActivityType(string id, [FromForm] ActivityTypeUpdateModel activityTypeUpdateModel);
        void DeleteActivityType(string id);
        ActivityTypeResponseModel GetActivityTypeById(string id);
    }
}
