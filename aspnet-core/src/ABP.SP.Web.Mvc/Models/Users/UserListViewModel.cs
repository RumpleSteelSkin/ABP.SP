using ABP.SP.Roles.Dto;
using System.Collections.Generic;

namespace ABP.SP.Web.Models.Users;

public class UserListViewModel
{
    public IReadOnlyList<RoleDto> Roles { get; set; }
}
