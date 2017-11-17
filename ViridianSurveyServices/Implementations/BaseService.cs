using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianSurveyServices.Implementations
{
    public class BaseService
    {
        protected readonly IUnitOfWork unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
