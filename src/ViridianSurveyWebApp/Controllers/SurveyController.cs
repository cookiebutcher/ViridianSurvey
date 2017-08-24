using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Implementations;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianSurveyWebApp.Controllers
{
    [Route("api/[controller]")]
    public class SurveyController : BaseController
    {
        public SurveyController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("[action]")]
        public IEnumerable<Survey> Surveys()
        {
            return unitOfWork.Surveys.GetAll();
        }
    }
}