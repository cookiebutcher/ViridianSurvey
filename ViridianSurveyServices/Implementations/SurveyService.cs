using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianSurveyServices.Interfaces;
using ViridianSurveyServices.Interfaces.WebModels;

namespace ViridianSurveyServices.Implementations
{
    public class SurveyService : BaseService, ISurveyService
    {
        private readonly IMapper mapper;
        public SurveyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<WebSurvey, Survey>());
            this.mapper = config.CreateMapper();
        }

        public async Task<WebSurvey> CreateSurvey(WebSurvey survey)
        {
            Survey newSurvey = mapper.Map<Survey>(survey);
            newSurvey.CreatedDate = DateTime.Now;
            newSurvey.CreatedBy = unitOfWork.UserAccounts.GetAll().FirstOrDefault();
            unitOfWork.Surveys.Add(newSurvey);
            await unitOfWork.CompleteAsync();

            return mapper.Map<WebSurvey>(newSurvey);
        }

        public async Task<IEnumerable<WebSurvey>> GetAllSurveysAsync()
        {
            var surveys = await unitOfWork.Surveys.GetAllAsync();
            return surveys.Select(x => mapper.Map<WebSurvey>(x));            
        }

        public async Task<WebSurvey> GetSurveyByIdAsync(int surveyId)
        {
            var survey = await unitOfWork.Surveys.GetByIdAsync(surveyId);
            if (survey == null)
            {
                return null;
            }

            return mapper.Map<WebSurvey>(survey);
        }
    }
}
