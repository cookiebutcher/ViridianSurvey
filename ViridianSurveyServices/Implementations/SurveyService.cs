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
        public SurveyService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<WebSurvey> CreateSurvey(WebSurvey survey)
        {
            var newSurvey = CreateEntityFromWeb(survey);
            newSurvey.CreatedDate = DateTime.Now;
            newSurvey.CreatedBy = unitOfWork.UserAccounts.GetAll().FirstOrDefault();
            unitOfWork.Surveys.Add(newSurvey);
            await unitOfWork.CompleteAsync();

            return CreateWebEntityFromModel(newSurvey);
        }

        public async Task<IEnumerable<WebSurvey>> GetAllSurveysAsync()
        {
            var surveys = await unitOfWork.Surveys.GetAllAsync();
            return surveys.Select(x => CreateWebEntityFromModel(x));            
        }

        public async Task<WebSurvey> GetSurveyByIdAsync(int surveyId)
        {
            var survey = await unitOfWork.Surveys.GetByIdAsync(surveyId);
            if (survey == null)
            {
                return null;
            }

            return CreateWebEntityFromModel(survey);
        }

        private Survey CreateEntityFromWeb(WebSurvey webSurvey)
        {
            return new Survey
            {
                Id = webSurvey.Id,
                Code = webSurvey.Code,
                Title = webSurvey.Title,
                Description = webSurvey.Description,
                WelcomeMessage = webSurvey.WelcomeMessage,
                EndMessage = webSurvey.EndMessage,
                ShowWelcomeScreen = webSurvey.ShowWelcomeScreen,
                AllowBackwardNavigation = webSurvey.AllowBackwardNavigation,
                ShowProgressBar = webSurvey.ShowProgressBar,
                ShowGroupName = webSurvey.ShowGroupName,
                ShowGroupDescription = webSurvey.ShowGroupDescription
            };
        }

        private WebSurvey CreateWebEntityFromModel(Survey survey)
        {
            return new WebSurvey
            {
                Id = survey.Id,
                Code = survey.Code,
                Title = survey.Title,
                Description = survey.Description,
                WelcomeMessage = survey.WelcomeMessage,
                EndMessage = survey.EndMessage,
                ShowWelcomeScreen = survey.ShowWelcomeScreen,
                AllowBackwardNavigation = survey.AllowBackwardNavigation,
                ShowProgressBar = survey.ShowProgressBar,
                ShowGroupName = survey.ShowGroupName,
                ShowGroupDescription = survey.ShowGroupDescription
            };
        }
    }
}
