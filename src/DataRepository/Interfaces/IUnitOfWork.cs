using System;
using System.Threading.Tasks;

namespace ViridianCode.ViridianSurvey.DataRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository Questions { get; }
        ISurveyRepository Surveys { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}