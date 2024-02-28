using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.ActivityModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BotTournamentManagement.Service
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly IActivityTypeRepository _activityTypeRepository;
        private readonly IMapper _mapper;
        public ActivityTypeService(IActivityTypeRepository activityTypeRepository, IMapper mapper)
        {
            _activityTypeRepository = activityTypeRepository;
            _mapper = mapper;
        }

        public void CreateNewActivityType(ActivityTypeCreatedModel activityTypeCreatedModel)
        {
            var activityTypeList = _activityTypeRepository.GetAll();
            foreach (ActivityTypeEntity activityType in activityTypeList)
            {
                if (activityType.TypeName.ToLower().Equals(activityTypeCreatedModel.TypeName.ToLower()))
                {
                    throw new Exception("This Activity type is existed !");
                }
            }
            var activityTypeEntity = _mapper.Map<ActivityTypeEntity>(activityTypeCreatedModel);
            _activityTypeRepository.Add(activityTypeEntity);
        }

        public void DeleteActivityType(string id)
        {
            var chosenActivityType = _activityTypeRepository.GetById(id);
            if (chosenActivityType is null)
            {
                throw new Exception("This Activity type is not existed");
            }
            else
            {
                _activityTypeRepository.Delete(chosenActivityType);
            }
        }

        public ActivityTypeResponseModel GetActivityTypeById(string id)
        {
            var chosenActivityType = _activityTypeRepository.GetById(id);
            if (chosenActivityType is null)
            {
                throw new Exception("This Activity Type is not existed");
            }
            var responseActivityType = _mapper.Map<ActivityTypeResponseModel>(chosenActivityType);
            return responseActivityType;
        }

        public List<ActivityTypeResponseModel> GetAllActivityTypes()
        {
            var activityTypeList = _activityTypeRepository.GetAll();
            if (!activityTypeList.Any())
            {
                throw new Exception("This activityType list is empty");
            }
            var responseActivityTypeList = _mapper.Map<List<ActivityTypeResponseModel>>(activityTypeList);
            return responseActivityTypeList;
        }

        public void UpdateActivityType(ActivityTypeUpdateModel activityTypeUpdateModel)
        {
            var chosenActivityType = _activityTypeRepository.GetById(activityTypeUpdateModel.Id);
            if (chosenActivityType is null)
            {
                throw new Exception("This activityType is not existed");
            }
            var activityTypeList = _activityTypeRepository.GetAll();
            foreach (var activityType in activityTypeList)
            {
                if (activityType.TypeName.ToLower().Equals(activityTypeUpdateModel.TypeName.ToLower()))
                {
                    throw new Exception("This Activity type name existed");
                }
            }
            _mapper.Map(activityTypeUpdateModel, chosenActivityType);
            _activityTypeRepository.Update(chosenActivityType);
        }
    }
}
