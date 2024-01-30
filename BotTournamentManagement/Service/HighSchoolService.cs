using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
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
            var existingHighSchool = _highSchoolRepository.GetAll().Where(p => p.KeyId == highSchoolCreatedModel.KeyId);
            if (existingHighSchool.Any())
            {
                throw new Exception("This High school Id is existed !");
            }
            var newHighSchool = _mapper.Map<HighSchoolEntity>(highSchoolCreatedModel);
            _highSchoolRepository.Add(newHighSchool);
        }

        public void DeleteSchool(int id)
        {
            throw new NotImplementedException();
        }

        public HighSchoolResponseModel GetHighSchoolById(int id)
        {
            throw new NotImplementedException();
        }

        public List<HighSchoolResponseModel> GetListHighSchools()
        {
            throw new NotImplementedException();
        }

        public void UpdateSchool(string id, [FromForm] HighSchoolCreatedModel highSchoolCreatedModel)
        {
            throw new NotImplementedException();
        }
    }
}
