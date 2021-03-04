using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.FunOA.Authorization;

namespace KP.FunOA
{
    [DependsOn(
        typeof(FunOACoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FunOAApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FunOAAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FunOAApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
