using Abp.Application.Services;
using Abp.Application.Services.Dto;
using KP.FunOA.DailyWorks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP.FunOA.DailyWorks
{
    public interface IDailyWorkAppService : IAsyncCrudAppService<DailyWorkDto, Guid, PagedDailyWorkResultRequestDto, CreateDailyWorkDto, DailyWorkDto>
    {
        Task<PagedResultDto<DailyWorkDto>> GetMySelfAllAsync(PagedDailyWorkResultRequestDto input);
    }
}
