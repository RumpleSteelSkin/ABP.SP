using ABP.SP.Roles.Dto;
using System.Collections.Generic;

namespace ABP.SP.Web.Models.Roles;

public class RoleListViewModel
{
    public IReadOnlyList<PermissionDto> Permissions { get; set; }
}
