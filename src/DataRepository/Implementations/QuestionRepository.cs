using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ViridianSurveyContext context) : base(context)
        {

        }
    }
}