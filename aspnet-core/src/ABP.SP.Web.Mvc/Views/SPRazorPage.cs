using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace ABP.SP.Web.Views;

public abstract class SPRazorPage<TModel> : AbpRazorPage<TModel>
{
    [RazorInject]
    public IAbpSession AbpSession { get; set; }

    protected SPRazorPage()
    {
        LocalizationSourceName = SPConsts.LocalizationSourceName;
    }
}
