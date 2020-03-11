using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ABP.TPLMS.Controllers
{
    public abstract class TPLMSControllerBase: AbpController
    {
        protected TPLMSControllerBase()
        {
            LocalizationSourceName = TPLMSConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
