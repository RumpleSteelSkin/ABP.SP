using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.SP.Configuration;
using ABP.SP.EntityFrameworkCore;
using ABP.SP.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace ABP.SP.Migrator;

[DependsOn(typeof(SPEntityFrameworkModule))]
public class SPMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public SPMigratorModule(SPEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(SPMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            SPConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(SPMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
