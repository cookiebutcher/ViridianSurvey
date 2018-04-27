using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.DataRepository.Interfaces;
using ViridianCode.ViridianSurvey.DatabaseContext;

namespace ViridianCode.ViridianSurvey.DataRepository.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ViridianSurveyContext _context;

        private ISurveyRepository _surveyRepository;
        private IQuestionRepository _questionRepository;
        private IUserAccountRepository _userAccountnRepository;

        public UnitOfWork(ViridianSurveyContext viridianSurveyContext)
        {
            _context = viridianSurveyContext;
        }
        
        public IQuestionRepository Questions => _questionRepository ?? (_questionRepository = new QuestionRepository(_context));

        public ISurveyRepository Surveys => _surveyRepository ?? (_surveyRepository = new SurveyRepository(_context));

        public IUserAccountRepository UserAccounts => _userAccountnRepository ?? (_userAccountnRepository = new UserAccountRepository(_context));

        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}