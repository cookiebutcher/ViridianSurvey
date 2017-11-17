using Microsoft.AspNetCore.Mvc;
using ViridianSurveyServices.Interfaces;
using ViridianSurveyServices.Interfaces.WebModels;
using System.Threading.Tasks;

namespace ViridianSurveyWebApp.Controllers
{
    [Route("api/v1/surveys")]
    public class SurveyController : BaseController
    {
        private readonly ISurveyService surveyService;
        public SurveyController(ISurveyService surveyService)
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
        public async Task<IActionResult> Create([FromBody] WebSurvey survey)
        {
            if(survey == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var newSurvey = await surveyService.CreateSurvey(survey);

            return Ok(newSurvey);
        }
    }
}