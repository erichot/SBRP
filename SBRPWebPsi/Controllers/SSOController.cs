using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace SBRPWebPsi.Controllers
{
    /// <summary>
    /// 接受來自SSO驗證通過，並返回至PSI的登入資訊
    /// </summary>
    [Route("[controller]")]
    public class SSOController : Controller
    {
        private readonly AppSettingsModel m_AppSettings;
        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly AppUserLoginBindingService m_AppUserLoginBindingService;
        private readonly ApiRequestService m_ApiRequestService;

        public SSOController(IOptions<AppSettingsModel> appSettings
            , AppUserBindingService appUserBindingService
            , AppUserLoginBindingService appUserLoginBindingService
            , ApiRequestService apiRequestService)
        {
            m_AppSettings = appSettings.Value;
            m_AppUserBindingService = appUserBindingService;
            m_AppUserLoginBindingService = appUserLoginBindingService;
            m_ApiRequestService = apiRequestService;
        }





        [HttpPost]
        public async Task<IActionResult> Index(SBRPBusiness.Models.SsoRedirectRequestModel _info)
        {
            // =================================================================
            // Phase 1: 確認SSO登入是否有效
            // 從SSO取得的資料，用來搜尋DB，確認該資料所對應的SSO登入是否有效
            var userLoginToken_Filter = new SBRPData.Models.UserLoginToken
            {
                IssuedDate = DateOnly.FromDateTime(DateTime.Now),
                WebToken = _info.webToken,
                LoginId = _info.loginId,
                InValid_Filter = false
            };
            var userLoginTokenInfo = await m_AppUserLoginBindingService
                .GetUserLoginTokenEntityAsync(userLoginToken_Filter
                    , _enableTracking: false
                    , _includeDetails: true);
            
            var userInfo = userLoginTokenInfo?.User;
            if (userLoginTokenInfo == null || userInfo == null)
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = "找不到User";
                return View("~/Views/SSO/Error.cshtml");
            }


            // =====================================================================
            // Phase 2: 識別完成，確認該User是否授權登入PSI


            // =================================================================
            // Phase 3: 登入成功，建立登入資訊
            SBRPBusiness.Models.WebUserTokenRequestEntity webUserTokenRequestInfo = new SBRPBusiness.Models.WebUserTokenRequestEntity
            {
                UserNo = userInfo.UserNo,
                UserName = userInfo.UserName,
                LoginActionNo = userLoginTokenInfo.LoginActionNo,
                Password = string.Empty,
                WebToken = userLoginTokenInfo.WebToken,
                UserRoleNo = userInfo.UserRoleNo,
                UserGroupNo = userInfo.UserGroupNo
            };


            // ==============================================================================
            var loginClaim = new SBRPBusiness.Models.IdentityClaimEntity(userInfo, userLoginTokenInfo);



            // =================================================================
            var apiToken = string.Empty;           
            apiToken = await m_ApiRequestService.AuthenticateApiJwtToken(
                m_AppSettings.PSI_API_RootUrl, webUserTokenRequestInfo);
            if (string.IsNullOrWhiteSpace(apiToken))
            {
                TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = "Token失敗";
                return View("~/Views/SSO/Error.cshtml");
            }



            // ==============================================================================
            var claimsIdentity = m_AppUserBindingService.SetLoginClaimsIdentity(loginClaim);
            var authProperties = m_AppUserBindingService.SetLoginAuthenticationProperties();


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);


            return RedirectToPage("/Index");
        }







    }
}
