using Abp.AutoMapper;
using ABP.SP.Sessions.Dto;

namespace ABP.SP.Web.Views.Shared.Components.TenantChange;

[AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
public class TenantChangeViewModel
{
    public TenantLoginInfoDto Tenant { get; set; }
}
