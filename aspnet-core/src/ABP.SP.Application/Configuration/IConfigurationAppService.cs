using ABP.SP.Configuration.Dto;
using System.Threading.Tasks;

namespace ABP.SP.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
