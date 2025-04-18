using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SBRPWebPsi.Pages
{
    [AllowAnonymous]
    public class SystemLoginModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }
        private readonly AppSettingsModel m_AppSettings;

        
        private IHttpContextAccessor m_HttpContextAccessor;

        private readonly AppUserBindingService m_AppUserBindingService;
        private readonly AppUserLoginBindingService m_AppUserLoginBindingService;
        private readonly SBRPBusiness.Models.IdentityClaimEntity m_CurrentLoginClaimInfo;

        private readonly WebSystemService m_WebSystemService;
       
        public SystemLoginModel(Microsoft.Extensions.Options.IOptions<AppSettingsModel> appSettings
            , IHttpContextAccessor httpContextAccessor
            , AppUserBindingService userService
            , AppUserLoginBindingService userLoginService
            , WebSystemService webSystemService)
        {
            m_AppSettings = appSettings.Value;
            m_WebSystemService = webSystemService;


            m_HttpContextAccessor = httpContextAccessor;
            m_AppUserBindingService = userService;
            m_AppUserLoginBindingService = userLoginService;

            m_CurrentLoginClaimInfo = m_AppUserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            PG_UserIdentity = m_HttpContextAccessor.HttpContext.User.Identity;
        }


        public System.Security.Principal.IIdentity? PG_UserIdentity { get; set; }
        private readonly short m_PasswordFailureAttemptMaxCount;



        public async Task<IActionResult> OnGetAsync()
        {
            //if (AppSystem.AP_IsAuthenticatedByDomain == true)
            //{
            //    if (PG_UserIdentity.IsAuthenticated && string.IsNullOrEmpty(PG_UserIdentity.Name) == false)
            //    {
            //        if (m_CurrentLoginClaimInfo == null || m_CurrentLoginClaimInfo.UserNo.IsNullOrDefault())
            //        {
            //            var loginID = PG_UserIdentity.Name;
            //            var userInfo = await m_UserService.GetEntityAsync(
            //                    loginID, string.Empty);

            //            var clientHttpContextInfo = new ClientHttpContext(m_HttpContextAccessor);

            //            // =====================================================================
            //            var userLoginTokenInfo =  new UserLoginToken
            //            {
            //                IssuedDate = DateTime.Now,
            //                UserNo = userInfo.UserNo,
            //                SerialNo = 0,
            //                WebToken = string.Empty,
            //                RemoteIpAddress = string.Empty
            //            };

            //            // =================================================================
            //            var apiToken = string.Empty;
            //            WebUserTokenRequestEntity webUserTokenRequestInfo = new WebUserTokenRequestEntity
            //            {
            //                UserNo = userInfo.UserNo,
            //                UserName = userInfo.UserName,
            //                LoginActionNo = userLoginTokenInfo.LoginActionNo,
            //                Password = string.Empty,
            //                WebToken = userLoginTokenInfo.WebToken,
            //                RoleNo = userInfo.RoleNo,
            //                DivisionNo = userInfo.DivisionNo,
            //                DepartmentNo = userInfo.DepartmentNo
            //            };
            //            //apiToken = await m_ApiRequestService.AuthenticateApiJwtToken(
            //            //    m_AppSettings.API_RootUrl, webUserTokenRequestInfo);
            //            //if (string.IsNullOrEmpty(apiToken))
            //            //{
            //            //    ModelState.AddModelError(string.Empty, "API failure");
            //            //    return Page();
            //            //}

            //            var loginClaim = new IdentityClaimEntity(userInfo, userLoginTokenInfo, apiToken);
            //            //var claimsIdentity = m_UserManagementService.SetLoginClaimsIdentity(loginClaim);
            //            //var authProperties = m_UserManagementService.SetLoginAuthenticationProperties();

            //        }

            //        return Redirect("/Index");
            //    }

            //    // 尚未Widows驗證通過
            //}
                


            return Page();
        }








        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var clientHttpContextInfo = new  ClientHttpContext(m_HttpContextAccessor);

            var loginID = LoginInfo.LoginId.ToUpper().Trim();
            var password = LoginInfo.Password.Trim();
            SBRPData.Models.UserLoginHistory userLoginHistory = null;



            
            var passwordHash =  CryptoHelper.AesEncrypt(password);
            var appUserInfo = await m_AppUserBindingService.GetEntityAsync(loginID, passwordHash);
            var userInfo = appUserInfo?.User;


            if (userInfo == null)
            {
                userLoginHistory = await m_AppUserLoginBindingService.WriteLoginFailureEventAsync(loginID, clientHttpContextInfo);
                var userFailureInfo = await m_AppUserBindingService.LogForPasswordFailureAsync(loginID, m_PasswordFailureAttemptMaxCount);
                var msg = "The login ID or password incorrect!";
                if (userFailureInfo != null)
                {
                    if (userFailureInfo.HasBeenLocked 
                        || 
                        (!m_PasswordFailureAttemptMaxCount.IsNullOrDefault() && userFailureInfo.PasswordFailureAttemptCount >= m_PasswordFailureAttemptMaxCount)
                        )
                    {
                        msg = "Account is locked in Manpower system. Please contact administrator";
                    }
                    else
                    {
                        msg = $"{userFailureInfo.PasswordFailureAttemptCount.ToString()}/{m_PasswordFailureAttemptMaxCount.ToString()} invalid login attempts.";
                    }
                }
                ModelState.AddModelError(string.Empty, msg);
                return Page();
            }



            // =====================================================================
            if (userInfo.IsDisabled)
            {
                userLoginHistory = await m_AppUserLoginBindingService.WriteLoginFailureEventAsync(loginID, clientHttpContextInfo
                    , _isAccountDisabled: true, _hasBeenLocked: false);
                ModelState.AddModelError(string.Empty, "The login ID has been disabled");
                return Page();
            }





            // =====================================================================
            if (userInfo.HasBeenLocked)
            {
                userLoginHistory = await m_AppUserLoginBindingService.WriteLoginFailureEventAsync(loginID, clientHttpContextInfo
                    ,_isAccountDisabled: false, _hasBeenLocked: true);
                var msg = "Account is locked in Manpower system. Please contact administrator";
                ModelState.AddModelError(string.Empty, msg);
                return Page();
            }


            // =====================================================================
            //if (orgUserInfo.orIsLogon == true && orgUserInfo.orLastLogon >= DateTime.Now.AddMinutes(-10))
            //{
            //    ModelState.AddModelError(string.Empty, "已登入，不允許重複登入"
            //        + (
            //            (orgUserInfo.orLastLogon == null) ? string.Empty : $"（前次登入時間：{orgUserInfo.orLastLogon.GetValueOrDefault().ToBopTimeString()}）"
            //            )
            //        );
            //    return Page();
            //}


            // =====================================================================
            var userLoginTokenInfo = await m_AppUserLoginBindingService.GeneralUserLoginTokenAsync(userInfo, clientHttpContextInfo);
            if (userLoginTokenInfo == null)
            {
                ModelState.AddModelError(string.Empty, " token failure");
                return Page();
            }



            //  ============================================================
            // 覆寫 orgUserInfo.RoleID
            //var isForceToResetPassword = false;
            //var logonPromptMessage = string.Empty;

            //if (orgUserInfo.orPwdValidateDate == null
            //    || orgUserInfo.orPwdValidateDate < DateTime.Now.Date)
            //{
            //    isForceToResetPassword = true;

            //    orgUserInfo.RoleID = UserRoleEnum.ForceToResetPpsswwdd;

            //    if (orgUserInfo.orPwdValidateDate == null)
            //        logonPromptMessage = "請立即更換您的密碼，方可使用各項功能。";
            //    else
            //        logonPromptMessage = "您的密碼已經超過九十天未更換，請立即更換，方可使用各項功能。";
            //}



            // =================================================================
            SBRPBusiness.Models.WebUserTokenRequestEntity webUserTokenRequestInfo = new SBRPBusiness.Models.WebUserTokenRequestEntity
            {
                UserNo = userInfo.UserNo,
                UserName = userInfo.UserName,
                LoginActionNo = userLoginTokenInfo.LoginActionNo,
                Password = passwordHash,
                WebToken = userLoginTokenInfo.WebToken,
                UserRoleNo = userInfo.UserRoleNo,
                UserGroupNo = userInfo.UserGroupNo
            };
            



            // ==============================================================================
            var loginClaim = new SBRPBusiness.Models.IdentityClaimEntity(userInfo, userLoginTokenInfo);
            var claimsIdentity = m_AppUserBindingService.SetLoginClaimsIdentity(loginClaim);
            var authProperties = m_AppUserBindingService.SetLoginAuthenticationProperties();


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);


            // ========================================================
            //await m_ApplicationLogService.SystemLoginSuccessLogAsync(
            //          orgUserInfo, userLoginTokenInfo, clientHttpContextInfo);
            
            await m_AppUserBindingService.LogForLogonAsync(userLoginTokenInfo);




            //if (isForceToResetPassword)
            //{
            //    TempData[AppSystem.TD_UI_OnPageLoad_Message_Notification] = logonPromptMessage;
            //    return RedirectToPage("/Systems/ChangePassword");
            //}



            return RedirectToPage("/Index");
        }











        [BindProperty]
        public LoginInfoModel LoginInfo { get; set; }


        public class LoginInfoModel
        {
            [Required(ErrorMessage = "Please input login ID ")]
            [MaxLength(48)]
            public string LoginId { get; set; }


            [Required(ErrorMessage = "Please input Password")]
            [DataType(DataType.Password)]
            //public string Password { get; set; }
            public string Password { get; set; }

        }



    }
}
