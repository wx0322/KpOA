using Abp.Application.Services;
using KP.FunOA.MultiTenancy.Dto;

namespace KP.FunOA.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

