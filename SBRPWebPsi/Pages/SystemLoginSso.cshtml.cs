using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SBRPWebPsi.Pages
{
    public class SystemLoginSsoModel : PageModel
    {

        private readonly AppSettingsModel m_AppSetting;
        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly WebSystemService m_WebSystemService;

        public string Portal_WEB_RootUrl_SSO_PSI;


        public SystemLoginSsoModel(Microsoft.Extensions.Options.IOptions<AppSettingsModel> appSettings
            , IHttpContextAccessor httpContextAccessor
            , WebSystemService webSystemService)
        {
            m_AppSetting = appSettings.Value;
            m_HttpContextAccessor = httpContextAccessor;
            m_WebSystemService = webSystemService;
        }





        public void OnGet()
        {
            Portal_WEB_RootUrl_SSO_PSI = m_AppSetting.Portal_WEB_RootUrl + "SSO/PSI";
        }
    }
}
