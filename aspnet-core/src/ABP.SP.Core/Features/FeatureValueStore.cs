using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.MultiTenancy;
using Abp.Runtime.Caching;
using ABP.SP.Authorization.Users;
using ABP.SP.MultiTenancy;

namespace ABP.SP.Features;

public class FeatureValueStore : AbpFeatureValueStore<Tenant, User>
{
    public FeatureValueStore(
        ICacheManager cacheManager,
        IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
        IRepository<Tenant> tenantRepository,
        IRepository<EditionFeatureSetting, long> editionFeatureRepository,
        IFeatureManager featureManager,
        IUnitOfWorkManager unitOfWorkManager)
        : base(
              cacheManager,
              tenantFeatureRepository,
              tenantRepository,
              editionFeatureRepository,
              featureManager,
              unitOfWorkManager)
    {
    }
}
