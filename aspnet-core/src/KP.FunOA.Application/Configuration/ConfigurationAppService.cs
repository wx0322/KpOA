using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using KP.FunOA.Configuration.Dto;

namespace KP.FunOA.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FunOAAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
