using System.Threading.Tasks;
using KP.FunOA.Configuration.Dto;

namespace KP.FunOA.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
