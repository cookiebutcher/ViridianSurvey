using Microsoft.AspNetCore.Mvc;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Implementations;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianSurveyWebApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}