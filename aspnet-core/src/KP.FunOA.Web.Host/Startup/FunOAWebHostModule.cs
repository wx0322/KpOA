using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.FunOA.Configuration;

namespace KP.FunOA.Web.Host.Startup
{
    [DependsOn(
       typeof(FunOAWebCoreModule))]
    public class FunOAWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FunOAWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FunOAWebHostModule).GetAssembly());
        }
    }
}
