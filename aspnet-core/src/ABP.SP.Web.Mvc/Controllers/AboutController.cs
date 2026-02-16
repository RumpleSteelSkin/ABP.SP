using Abp.AspNetCore.Mvc.Authorization;
using ABP.SP.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ABP.SP.Web.Controllers;

[AbpMvcAuthorize]
public class AboutController : SPControllerBase
{
    public ActionResult Index()
    {
        return View();
    }
}
