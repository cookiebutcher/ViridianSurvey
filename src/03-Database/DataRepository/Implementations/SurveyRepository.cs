using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class SurveyRepository : Repository<Survey>, ISurveyRepository
    {
        public SurveyRepository(ViridianSurveyContext context) : base(context)
        {

        }

        public ViridianSurveyContext ViridianSurveyContext => Context as ViridianSurveyContext;
    }
}