using Abp.Zero.EntityFrameworkCore;
using ABP.SP.Authorization.Roles;
using ABP.SP.Authorization.Users;
using ABP.SP.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace ABP.SP.EntityFrameworkCore;

public class SPDbContext : AbpZeroDbContext<Tenant, Role, User, SPDbContext>
{
    /* Define a DbSet for each entity of the application */

    public SPDbContext(DbContextOptions<SPDbContext> options)
        : base(options)
    {
    }
}
