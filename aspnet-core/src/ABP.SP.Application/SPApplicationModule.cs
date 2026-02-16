using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.SP.Authorization;

namespace ABP.SP;

[DependsOn(
    typeof(SPCoreModule),
    typeof(AbpAutoMapperModule))]
public class SPApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<SPAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(SPApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
