using Microsoft.AspNetCore.Mvc;

namespace SBRPWebPsi.Components
{
    public class NavHeaderViewComponent : ViewComponent
    {
        
        private readonly IHttpContextAccessor m_HttpContextAccessor;
        //private readonly UserBindingService m_UserBindingService;
        private readonly AppUserBindingService m_AppUserBindingService;
        //private readonly UserMenuitemService m_UserMenuitemService;
        private readonly SBRPBusiness.Models.IdentityClaimEntity m_CurrentLoginClaimInfo;


        private readonly short m_CurrentUserNo;
        

        public AppUserViewModel PG_Info;

        public NavHeaderViewComponent(IHttpContextAccessor httpContextAccessor
            , AppUserBindingService appUserBindingService)
        {
            //m_UserMenuitemService = userMenuitemService;
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            //m_CurrentRoleID = m_CurrentLoginClaimInfo.RoleID;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            PG_Info = await m_AppUserBindingService.GetEntityAsync(m_CurrentUserNo);
            
            return View(PG_Info);
        }


    }
}
