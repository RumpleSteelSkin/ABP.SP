using Abp.Configuration;
using System.Collections.Generic;

namespace ABP.SP.Configuration;

public class AppSettingProvider : SettingProvider
{
    public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
    {
        return
        [
            new SettingDefinition(AppSettingNames.UiTheme, "red",
                scopes: SettingScopes.Application | SettingScopes.Tenant | SettingScopes.User,
                clientVisibilityProvider: new VisibleSettingClientVisibilityProvider())
        ];
    }
}