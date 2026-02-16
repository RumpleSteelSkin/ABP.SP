using Abp.Authorization;
using ABP.SP.Authorization.Roles;
using ABP.SP.Authorization.Users;

namespace ABP.SP.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
