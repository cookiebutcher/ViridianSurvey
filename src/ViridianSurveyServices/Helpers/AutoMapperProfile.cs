using AutoMapper;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.Services.Helpers
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
