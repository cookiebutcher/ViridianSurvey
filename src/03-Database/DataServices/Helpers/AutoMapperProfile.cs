using AutoMapper;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataServices.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.DataServices.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<WebUserAccount, UserAccount>();
            CreateMap<UserAccount, WebUserAccount>();

            CreateMap<WebSurvey, Survey>();
            CreateMap<Survey, WebSurvey>();
        }
    }
}
