using Abp.Application.Services;
using ABP.SP.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace ABP.SP.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
