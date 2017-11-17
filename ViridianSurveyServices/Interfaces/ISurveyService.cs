using System.Collections.Generic;
using System.Threading.Tasks;
using ViridianSurveyServices.Interfaces.WebModels;

namespace ViridianSurveyServices.Interfaces
{
    public interface ISurveyService
    {
        Task<IEnumerable<WebSurvey>> GetAllSurveysAsync();
        Task<WebSurvey> GetSurveyByIdAsync(int surveyId);
        Task<WebSurvey> CreateSurvey(WebSurvey survey);
    }
}
