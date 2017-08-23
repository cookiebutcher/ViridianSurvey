using System;

namespace ViridianCode.ViridianSurvey.DataRepository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository Questions { get; }
        ISurveyRepository Surveys { get; }
        int Complete();
    }
}