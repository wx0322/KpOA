using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using KP.FunOA.Roles.Dto;
using KP.FunOA.Users.Dto;

namespace KP.FunOA.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
