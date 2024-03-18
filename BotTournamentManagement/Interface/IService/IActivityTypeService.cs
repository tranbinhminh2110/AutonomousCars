using BotTournamentManagement.Data.RequestModel.ActivityModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface IActivityTypeService
    {
        List<ActivityTypeResponseModel> GetAllActivityTypes();
        void CreateNewActivityType(ActivityTypeCreatedModel activityTypeCreatedModel);
        void UpdateActivityType(string id, ActivityTypeUpdateModel activityTypeUpdateModel);
        void DeleteActivityType(string id);
        ActivityTypeResponseModel GetActivityTypeById(string id);
    }
}
