using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using System.ComponentModel.DataAnnotations;
using System.Security.Claims;



namespace SBRPWebPortal.Pages
{
    [AllowAnonymous]
    public class SystemLoginModel : PageModel
    {
        [TempData]
        public string ErrorMessage { get; set; }
        private readonly AppSettingsModel m_AppSettings;

        
        private IHttpContextAccessor m_HttpContextAccessor;

        private readonly UserBindingService m_UserBindingService;
        private readonly UserLoginBindingService m_UserLoginBindingService;

        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;

        private readonly WebSystemService m_WebSystemService;
       
        public SystemLoginModel(Microsoft.Extensions.Options.IOptions<AppSettingsModel> appSettings
            , IHttpContextAccessor httpContextAccessor
            , UserBindingService userService
            , UserLoginBindingService userLoginService
            , WebSystemService webSystemService)
        {
            m_AppSettings = appSettings.Value;
            m_WebSystemService = webSystemService;


            m_HttpContextAccessor = httpContextAccessor;
            m_UserBindingService = userService;
            m_UserLoginBindingService = userLoginService;

            m_CurrentLoginClaimInfo = m_UserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            PG_UserIdentity = m_HttpContextAccessor.HttpContext.User.Identity;
        }


        public System.Security.Principal.IIdentity? PG_UserIdentity { get; set; }
        private readonly short m_PasswordFailureAttemptMaxCount;





        public async Task<IActionResult> OnGetAsync(string _apno)
        {
            var apno = _apno ?? string.Empty;

            return Page();
        }








        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            var clientHttpContextInfo = new ClientHttpContext(m_HttpContextAccessor);

            var loginID = LoginInfo.LoginId.ToUpper().Trim();
            var password = LoginInfo.Password.Trim();
            UserLoginHistory userLoginHistory = null;



            
            var passwordHash =  CryptoHelper.AesEncrypt(password);
            var userInfo = await m_UserBindingService.GetEntityAsync(loginID, passwordHash);
            


            if (userInfo == null)
            {
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(SBRPData.SBRP_AppIdEnum.Portial, loginID, clientHttpContextInfo);
                var userFailureInfo = await m_UserBindingService.LogForPasswordFailureAsync(loginID, m_PasswordFailureAttemptMaxCount);
                var msg = "The login ID or password incorrect!";
                if (userFailureInfo != null)
                {
                    if (userFailureInfo.HasBeenLocked || userFailureInfo.PasswordFailureAttemptCount >= m_PasswordFailureAttemptMaxCount)
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
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(SBRPData.SBRP_AppIdEnum.Portial, loginID, clientHttpContextInfo
                    , _isAccountDisabled: true, _hasBeenLocked: false);
                ModelState.AddModelError(string.Empty, "The login ID has been disabled");
                return Page();
            }





            // =====================================================================
            if (userInfo.HasBeenLocked)
            {
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(SBRPData.SBRP_AppIdEnum.Portial, loginID, clientHttpContextInfo
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
            var userLoginTokenInfo = await m_UserLoginBindingService.GeneralUserLoginTokenAsync(SBRPData.SBRP_AppIdEnum.Portial, userInfo, clientHttpContextInfo);
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
            var loginClaim = new IdentityClaimEntity(userInfo, userLoginTokenInfo);
            var claimsIdentity = m_UserBindingService.SetLoginClaimsIdentity(loginClaim);
            var authProperties = m_UserBindingService.SetLoginAuthenticationProperties();


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);


            // ========================================================
            //await m_ApplicationLogService.SystemLoginSuccessLogAsync(
            //          orgUserInfo, userLoginTokenInfo, clientHttpContextInfo);
            
            await m_UserBindingService.LogForLogonAsync(userLoginTokenInfo);




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
