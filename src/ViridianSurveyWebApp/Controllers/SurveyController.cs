using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<Survey>> Surveys()
        {
            return await unitOfWork.Surveys.GetAllAsync();
        }
    }
}