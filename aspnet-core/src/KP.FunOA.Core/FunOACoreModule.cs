using Abp.Localization;
using Abp.Localization.Dictionaries;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using KP.FunOA.Authorization.Roles;
using KP.FunOA.Authorization.Users;
using KP.FunOA.Configuration;
using KP.FunOA.Localization;
using KP.FunOA.MultiTenancy;
using KP.FunOA.Timing;

namespace KP.FunOA
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class FunOACoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            FunOALocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = FunOAConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
            
            Configuration.Localization.Languages.Add(new LanguageInfo("zh-Hans", "中文", "famfamfam-flags ir"));
        
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FunOACoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
