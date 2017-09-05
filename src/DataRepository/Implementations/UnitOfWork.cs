using System;
using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViridianSurveyContext context; //test

        private ISurveyRepository surveyRepository;
        private IQuestionRepository questionRepository;
        
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