using System.Collections.Generic;
using System.Threading.Tasks;
using ViridianCode.ViridianSurvey.Services.Interfaces.WebModels;

namespace ViridianCode.ViridianSurvey.Services.Interfaces
{
    public interface IUserAccountService
    {
        WebUserAccount Authenticate(string username, string password);

        Task<IEnumerable<WebUserAccount>> GetAllUserAccountsAsync();

        WebUserAccount Create(WebUserAccount user);
    }
}
