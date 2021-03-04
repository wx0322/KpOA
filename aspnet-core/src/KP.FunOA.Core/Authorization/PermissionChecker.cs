using Abp.Authorization;
using KP.FunOA.Authorization.Roles;
using KP.FunOA.Authorization.Users;

namespace KP.FunOA.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
