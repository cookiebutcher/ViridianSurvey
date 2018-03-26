using Microsoft.AspNetCore.Mvc;
using ViridianCode.ViridianSurvey.DataServices.Interfaces;
using ViridianCode.ViridianSurvey.DataServices.Interfaces.WebModels;
using System.Threading.Tasks;

namespace ViridianCode.ViridianSurvey.WebApi.Controllers
{
    [Route("v1/surveys")]
    public class SurveysController : BaseController
    {
        private readonly ISurveyService surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }        

        [HttpGet]
        public async Task<IActionResult> GetAllSurveys()
        {
            return Ok(await surveyService.GetAllSurveysAsync());
        }

        [HttpGet]
        [Route("{surveyId}")]
        public async Task<IActionResult> GetSurveyById(int surveyId)
        {
            return Ok(await surveyService.GetSurveyByIdAsync(surveyId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSurvey([FromBody] WebSurvey survey)
        {
            if (survey == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newSurvey = await surveyService.CreateSurvey(survey);

            return Ok(newSurvey);
        }
    }
}