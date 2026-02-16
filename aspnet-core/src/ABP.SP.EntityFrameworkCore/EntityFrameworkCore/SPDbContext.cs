using Abp.Zero.EntityFrameworkCore;
using ABP.SP.Authorization.Roles;
using ABP.SP.Authorization.Users;
using ABP.SP.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace ABP.SP.EntityFrameworkCore;

public class SPDbContext(DbContextOptions<SPDbContext> options)
    : AbpZeroDbContext<Tenant, Role, User, SPDbContext>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("");
    }
}