using Microsoft.AspNetCore.Mvc;
using ViridianCode.ViridianSurvey.Services.Interfaces;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ViridianSurveyWebApp.Controllers
{
    [Authorize]
    [Route("api/v1/surveys")]
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