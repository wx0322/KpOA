using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using KP.FunOA.Authorization.Roles;
using KP.FunOA.Authorization.Users;
using KP.FunOA.MultiTenancy;
using KP.FunOA.DailyWorks;

namespace KP.FunOA.EntityFrameworkCore
{
    public class FunOADbContext : AbpZeroDbContext<Tenant, Role, User, FunOADbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<DailyWork> DailyWorks { get; set; }
        public FunOADbContext(DbContextOptions<FunOADbContext> options)
            : base(options)
        {
        }
    }
}
