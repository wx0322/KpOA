using System.Threading.Tasks;
using Abp.Application.Services;
using KP.FunOA.Authorization.Accounts.Dto;

namespace KP.FunOA.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
