using System.Collections.Generic;
using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.Services.Interfaces
{
    public interface ISurveyService
    {
        Task<IEnumerable<WebSurvey>> GetAllSurveysAsync();
        Task<WebSurvey> GetSurveyByIdAsync(int surveyId);
        Task<WebSurvey> CreateSurvey(WebSurvey survey);
    }
}
