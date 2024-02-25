using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.HighSchoolModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Service
{
    public class HighSchoolService : IHighSchoolService
    {
        private readonly IHighSchoolRepository _highSchoolRepository;
        private readonly IMapper _mapper;
        public HighSchoolService(IHighSchoolRepository highSchoolRepository, IMapper mapper)
        {
            _highSchoolRepository = highSchoolRepository;
            _mapper = mapper;

        }
        public void AddSchool(HighSchoolCreatedModel highSchoolCreatedModel)
        {
            var existingHighSchool = _highSchoolRepository.GetAll().Where(p => p.KeyId == highSchoolCreatedModel.KeyId).FirstOrDefault();
            if (existingHighSchool is not null)
            {
                throw new Exception("This High school Id is existed !");
            }
            var newHighSchool = _mapper.Map<HighSchoolEntity>(highSchoolCreatedModel);
            _highSchoolRepository.Add(newHighSchool);
        }

        public void DeleteSchool(string id)
        {
            var chosenSchool = _highSchoolRepository.GetById(id);
            if (chosenSchool is null)
            {
                throw new Exception("This high school is not existed");
            }
            else
            {
                _highSchoolRepository.Delete(chosenSchool);
            }
        }

        public HighSchoolResponseModel GetHighSchoolById(string id)
        {
            var chosenSchool = _highSchoolRepository.GetById(id);
            if (chosenSchool is null)
            {
                throw new Exception("This high school is not existed");
            }
            var responseSchool = _mapper.Map<HighSchoolResponseModel>(chosenSchool);
            return responseSchool;
        }

        public List<HighSchoolResponseModel> GetListHighSchools()
        {
            var highSchoolList = _highSchoolRepository.GetAll();
            if (!highSchoolList.Any())
            {
                throw new Exception("This high school list is empty");
            }
            var responseHighSchoolList = _mapper.Map<List<HighSchoolResponseModel>>(highSchoolList);
            return responseHighSchoolList;
        }

        public void UpdateSchool(HighSchoolUpdateModel highSchoolUpdateModel)
        {
            var existingSchool = _highSchoolRepository.GetById(highSchoolUpdateModel.Id);
            if (existingSchool is null)
            {
                throw new Exception("This school is not existed");
            }
            var schoolList = _highSchoolRepository.GetAll();
            foreach (var school in schoolList)
            {
                if (highSchoolUpdateModel.KeyId.Equals(school.KeyId))
                {
                    throw new Exception("This school ID existed");
                }
            }
            _mapper.Map(highSchoolUpdateModel, existingSchool);
            _highSchoolRepository.Update(existingSchool);
        }
    }
}
