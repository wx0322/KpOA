using Abp.MultiTenancy;
using KP.FunOA.Authorization.Users;

namespace KP.FunOA.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
