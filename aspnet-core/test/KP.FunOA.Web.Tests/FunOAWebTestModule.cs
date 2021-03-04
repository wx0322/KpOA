using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using KP.FunOA.EntityFrameworkCore;
using KP.FunOA.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace KP.FunOA.Web.Tests
{
    [DependsOn(
        typeof(FunOAWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FunOAWebTestModule : AbpModule
    {
        public FunOAWebTestModule(FunOAEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FunOAWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FunOAWebMvcModule).Assembly);
        }
    }
}