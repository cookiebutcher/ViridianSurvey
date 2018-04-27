using AutoMapper;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataServices.Implementations
{
    public class BaseService
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IMapper mapper;

        protected BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
