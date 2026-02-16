using Abp.Application.Services;
using ABP.SP.Sessions.Dto;
using System.Threading.Tasks;

namespace ABP.SP.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
