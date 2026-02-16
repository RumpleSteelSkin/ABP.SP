using Abp.Authorization;
using Abp.Runtime.Session;
using ABP.SP.Configuration.Dto;
using System.Threading.Tasks;

namespace ABP.SP.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : SPAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
