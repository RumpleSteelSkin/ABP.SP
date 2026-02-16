using Abp.Application.Services;
using ABP.SP.MultiTenancy.Dto;

namespace ABP.SP.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

