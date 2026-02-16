using Abp.Modules;
using Abp.Reflection.Extensions;
using ABP.SP.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ABP.SP.Web.Host.Startup
{
    [DependsOn(
       typeof(SPWebCoreModule))]
    public class SPWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SPWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SPWebHostModule).GetAssembly());
        }
    }
}
