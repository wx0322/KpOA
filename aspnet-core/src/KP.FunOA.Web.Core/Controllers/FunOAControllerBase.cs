using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace KP.FunOA.Controllers
{
    public abstract class FunOAControllerBase: AbpController
    {
        protected FunOAControllerBase()
        {
            LocalizationSourceName = FunOAConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
