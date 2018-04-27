using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViridianSurveyContext context;

        private ISurveyRepository surveyRepository;
        private IQuestionRepository questionRepository;
        private IUserAccountRepository userAccountnRepository;

        public UnitOfWork(ViridianSurveyContext viridianSurveyContext)
        {
            context = viridianSurveyContext;
        }
        
        public IQuestionRepository Questions => questionRepository ?? (questionRepository = new QuestionRepository(context));

        public ISurveyRepository Surveys => surveyRepository ?? (surveyRepository = new SurveyRepository(context));

        public IUserAccountRepository UserAccounts => userAccountnRepository ?? (userAccountnRepository = new UserAccountRepository(context));

        public int Complete()
        {
            return context.SaveChanges();
        }
        
        public async Task<int> CompleteAsync()
        {
            return await context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}