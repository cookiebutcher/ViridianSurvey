using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(ViridianSurveyContext context) : base(context)
        {

        }

        public ViridianSurveyContext ViridianSurveyContext => Context as ViridianSurveyContext;
    }
}