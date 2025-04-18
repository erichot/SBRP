using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SBRPWebPortal.Pages
{
    [AllowAnonymous]
    public class SystemLogoutModel : PageModel
    {
        

        

        private readonly short? m_CurrentUserNo;
        private readonly int? m_CurrentLoginActionSN;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;



        private readonly UserBindingService m_UserBindingService;


        public SystemLogoutModel(IHttpContextAccessor httpContextAccessor
            ,UserBindingService userService)
        {
            m_HttpContextAccessor = httpContextAccessor;
            m_UserBindingService = userService;

            m_CurrentLoginClaimInfo = m_UserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentUserNo = m_CurrentLoginClaimInfo?.UserNo;
            m_CurrentLoginActionSN = m_CurrentLoginClaimInfo?.LoginActionNo;
        }





        public async Task OnGetAsync()
        {
            if (m_CurrentUserNo.IsNullOrDefault() == false)
                await m_UserBindingService.ProcessToLogoutAsync(m_CurrentUserNo.ToShort());

            await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.Response.Redirect("SystemLogin");
        }





    }
}
