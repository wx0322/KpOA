using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using KP.FunOA.Authorization;
using KP.FunOA.Authorization.Users;
using KP.FunOA.DailyWorks.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KP.FunOA.DailyWorks
{
    [AbpAuthorize(PermissionNames.Pages_DailyWork)]
    public class DailyWorkAppService : AsyncCrudAppService<DailyWork, DailyWorkDto, Guid, PagedDailyWorkResultRequestDto, CreateDailyWorkDto, DailyWorkDto>
    {
        private readonly UserManager userManager;
        private IRepository<DailyWork, Guid> repository;

        public DailyWorkAppService(IRepository<DailyWork, Guid> repository,
            UserManager userManager
            ) : base(repository)
        {
            this.repository = repository;
            this.userManager = userManager;
        }

        public override async Task<DailyWorkDto> CreateAsync(CreateDailyWorkDto input)
        {
            var entity = ObjectMapper.Map<DailyWork>(input);
            var user = await userManager.GetUserByIdAsync(AbpSession.UserId.Value);
            entity.UserName = user.Surname + user.Name; // 姓+名
            entity.TenantId = AbpSession.TenantId ?? -1;
            var obj = await repository.InsertAsync(entity);
            return MapToEntityDto(obj);
        }

        protected override IQueryable<DailyWork> CreateFilteredQuery(PagedDailyWorkResultRequestDto input)
        {
            return base.CreateFilteredQuery(input)
                .WhereIf(input.isPublished.HasValue, r => r.IsPublished == input.isPublished.Value)
                .WhereIf(input.UserId != -1, r => r.CreatorUserId == AbpSession.UserId.Value)
                .WhereIf(!string.IsNullOrWhiteSpace(input.UserName), t => t.UserName.Contains(input.UserName))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), t => t.Description.Contains(input.Keyword) || t.Title.Contains(input.Keyword));
        }
    }
}