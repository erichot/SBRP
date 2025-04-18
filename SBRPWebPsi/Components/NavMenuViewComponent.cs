using Microsoft.AspNetCore.Mvc;


namespace SBRPWebPsi.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        
        private readonly IHttpContextAccessor m_HttpContextAccessor;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly MenuitemBindingService m_MenuitemBindingService;
        
        private readonly SBRPBusiness.Models.IdentityClaimEntity m_CurrentLoginClaimInfo;


        private readonly short m_CurrentUserNo;
        private readonly byte m_CurrentSIGNo;
        //private readonly UserRoleEnum m_CurrentRoleID;

        public NavMenuViewComponent(MenuitemBindingService menuitemBindingService
            , IHttpContextAccessor httpContextAccessor
            , AppUserBindingService appUserBindingService)
        {
            m_MenuitemBindingService = menuitemBindingService;
            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = appUserBindingService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            m_CurrentUserNo = m_CurrentLoginClaimInfo.UserNo;
            m_CurrentSIGNo = m_CurrentLoginClaimInfo.SIGNo;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await 
                m_MenuitemBindingService
                    .GetMenuitemWithPGCDByUserWithPermissionAsync(m_CurrentSIGNo, m_CurrentUserNo);
            //AppMenuitem.UserMenuitemList = await m_UserMenuitemService
            //    .GetUserMenuitemListByUserAsync(
            //        m_CurrentUserRole, m_CurrentUserSID
            //    );
            //AppMenuitem.UserMenuitemList = await m_UserMenuitemService
            //   .GetListAsync(
            //       m_CurrentRoleID, m_CurrentUserSID
            //   );
            //return View(AppMenuitem.UserMenuitemList);
            return View(result);
        }


    }
}
