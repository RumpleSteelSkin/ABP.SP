using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.SP.EntityFrameworkCore;
using ABP.SP.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ABP.SP.Web.Tests;

[DependsOn(
    typeof(SPWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class SPWebTestModule : AbpModule
{
    public SPWebTestModule(SPEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SPWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(SPWebMvcModule).Assembly);
    }
}