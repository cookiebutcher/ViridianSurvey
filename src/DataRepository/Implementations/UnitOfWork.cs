using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

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
        
        public IQuestionRepository Questions
        {
            get
            {
                if(questionRepository == null)
                {
                    questionRepository = new QuestionRepository(context);
                }

                return questionRepository;
            }             
        }

        public ISurveyRepository Surveys 
        {
            get
            {
                if(surveyRepository == null)
                {
                    surveyRepository = new SurveyRepository(context);
                }

                return surveyRepository;
            }             
        }

        public IUserAccountRepository UserAccounts
        {
            get
            {
                if (userAccountnRepository == null)
                {
                    userAccountnRepository = new UserAccountRepository(context);
                }

                return userAccountnRepository;
            }
        }

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
