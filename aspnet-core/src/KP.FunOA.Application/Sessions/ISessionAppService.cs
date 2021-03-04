using System.Threading.Tasks;
using Abp.Application.Services;
using KP.FunOA.Sessions.Dto;

namespace KP.FunOA.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
