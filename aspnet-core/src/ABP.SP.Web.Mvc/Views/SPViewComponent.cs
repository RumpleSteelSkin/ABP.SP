using Abp.AspNetCore.Mvc.ViewComponents;

namespace ABP.SP.Web.Views;

public abstract class SPViewComponent : AbpViewComponent
{
    protected SPViewComponent()
    {
        LocalizationSourceName = SPConsts.LocalizationSourceName;
    }
}
