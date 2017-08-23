using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ViridianSurveyContext context) : base(context)
        {

        }

        public ViridianSurveyContext ViridianSurveyContext
        {
            get { return Context as ViridianSurveyContext; }
        }
    }
}