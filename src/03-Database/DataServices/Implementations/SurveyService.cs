using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DataServices.Interfaces;
using ViridianCode.ViridianSurvey.DataServices.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.DataServices.Implementations
{
    public class SurveyService : BaseService, ISurveyService
    {
        //private readonly IMapper mapper;
        public SurveyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<WebSurvey> CreateSurvey(WebSurvey survey)
        {
            Survey newSurvey = Mapper.Map<Survey>(survey);
            newSurvey.CreatedDate = DateTime.Now;
            newSurvey.CreatedBy = UnitOfWork.UserAccounts.GetAll().FirstOrDefault();
            UnitOfWork.Surveys.Add(newSurvey);
            await UnitOfWork.CompleteAsync();

            return Mapper.Map<WebSurvey>(newSurvey);
        }

        public async Task<IEnumerable<WebSurvey>> GetAllSurveysAsync()
        {
            var surveys = await UnitOfWork.Surveys.GetAllAsync();
            return surveys.Select(x => Mapper.Map<WebSurvey>(x));            
        }

        public async Task<WebSurvey> GetSurveyByIdAsync(int surveyId)
        {
            var survey = await UnitOfWork.Surveys.GetByIdAsync(surveyId);
            if (survey == null)
            {
                return null;
            }

            return Mapper.Map<WebSurvey>(survey);
        }
    }
}
