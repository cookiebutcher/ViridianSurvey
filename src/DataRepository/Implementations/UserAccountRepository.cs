using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(ViridianSurveyContext context) : base(context)
        {

        }

        public ViridianSurveyContext ViridianSurveyContext
        {
            get { return Context as ViridianSurveyContext; }
        }
    }
}