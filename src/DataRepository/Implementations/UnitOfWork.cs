using System;
using ViridianCode.ViridianSurvey.DataModel;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViridianSurveyContext context;
        
        public UnitOfWork(ViridianSurveyContext viridianSurveyContext)
        {
            context = viridianSurveyContext;
            Surveys = new SurveyRepository(context);
            Questions = new QuestionRepository(context);
        }
        
        public IQuestionRepository Questions { get; private set; }
        public ISurveyRepository Surveys { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }
    }
}