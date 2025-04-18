using Microsoft.AspNetCore.Mvc;
using SBRPData;
using System.Net.Http;
using System.Security.Claims;
using System.Text;


namespace SBRPWebPortal.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class SSOController : Controller
    {
        [TempData]
        public string ErrorMessage { get; set; }
        private readonly AppSettingsModel m_AppSettings;

        private IHttpContextAccessor m_HttpContextAccessor;

        private readonly UserBindingService m_UserBindingService;
        private readonly UserLoginBindingService m_UserLoginBindingService;

        private readonly IdentityClaimEntity m_CurrentLoginClaimInfo;

        private readonly WebSystemService m_WebSystemService;

        public SSOController(Microsoft.Extensions.Options.IOptions<AppSettingsModel> appSettings
            , IHttpContextAccessor httpContextAccessor
            , UserBindingService userBindingService
            , UserLoginBindingService userLoginBindingService, WebSystemService webSystemService)
        {
            m_AppSettings = appSettings.Value;
            m_WebSystemService = webSystemService;


            m_HttpContextAccessor = httpContextAccessor;
            m_UserBindingService = userBindingService;
            m_UserLoginBindingService = userLoginBindingService;

            m_CurrentLoginClaimInfo = m_UserBindingService.GetCurrentLoginClaim(m_HttpContextAccessor.HttpContext.User);
            PG_UserIdentity = m_HttpContextAccessor.HttpContext.User.Identity;
        }

        public System.Security.Principal.IIdentity? PG_UserIdentity { get; set; }
        private readonly short m_PasswordFailureAttemptMaxCount;









        public IActionResult Index()
        {
            return View();
        }







        [HttpGet("{_appId}")]
        public IActionResult SystemLogin(string _appId)
        {
            if (string.IsNullOrEmpty(_appId))
                return NotFound();

            SBRP_AppIdEnum appIdEnum = SBRPData.Helpers.DataConvertHelper.ToAppIdEnum(_appId);


            var loginInfoDefault = new LoginInfoModel(_appId);
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                loginInfoDefault.LoginId = "ADMIN";
                loginInfoDefault.Password = "1234";
            }

            return View(loginInfoDefault);
        }







        [HttpPost("{_appId}")]
        public async Task<IActionResult> SystemLogin(LoginInfoModel _info)
        {
            var _appId = _info.AppId;
            if (string.IsNullOrEmpty(_appId))
                return NotFound();

            SBRP_AppIdEnum appId = SBRPData.Helpers.DataConvertHelper.ToAppIdEnum(_appId);



            var clientHttpContextInfo = new ClientHttpContext(m_HttpContextAccessor);

            var loginID = _info.LoginId.ToUpper().Trim();
            var password = _info.Password.Trim();
            UserLoginHistory userLoginHistory = null;




            var passwordHash = CryptoHelper.AesEncrypt(password);
            var userInfo = await m_UserBindingService.GetEntityAsync(loginID, passwordHash);



            if (userInfo == null)
            {
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(appId, loginID, clientHttpContextInfo);
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
                return View(_info);
            }



            // =====================================================================
            if (userInfo.IsDisabled)
            {
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(appId, loginID, clientHttpContextInfo
                    , _isAccountDisabled: true, _hasBeenLocked: false);
                ModelState.AddModelError(string.Empty, "The login ID has been disabled");
                return View(_info);
            }





            // =====================================================================
            if (userInfo.HasBeenLocked)
            {
                userLoginHistory = await m_UserLoginBindingService.WriteLoginFailureEventAsync(appId, loginID, clientHttpContextInfo
                    , _isAccountDisabled: false, _hasBeenLocked: true);
                var msg = "Account is locked in Manpower system. Please contact administrator";
                ModelState.AddModelError(string.Empty, msg);
                return View(_info);
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
            var userLoginTokenInfo = await m_UserLoginBindingService.GeneralUserLoginTokenAsync(appId, userInfo, clientHttpContextInfo);
            if (userLoginTokenInfo == null)
            {
                ModelState.AddModelError(string.Empty, " token failure");
                return View(_info);
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
                AppId = (byte)appId,
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


            await m_UserBindingService.LogForLogonAsync(userLoginTokenInfo);
            // ========================================================
            //await m_ApplicationLogService.SystemLoginSuccessLogAsync(
            //          orgUserInfo, userLoginTokenInfo, clientHttpContextInfo);



            string redirectUrl = m_AppSettings.PSI_WEB_RootUrl + "SSO/";
            var postInfo = new SBRPBusiness.Models.SsoRedirectRequestModel()
            {
                webToken = webUserTokenRequestInfo.WebToken,
                loginId = loginID,
                redirectUrl = redirectUrl
            };
            return View("~/Views/SSO/RedirectBack.cshtml", postInfo);
        }





        //public async Task<IActionResult> PostToExternalAsync()
        //{
        //    var redirectUrl = m_AppSettings.PSI_WEB_RootUrl + "/SSO/ASDASDFASD";

        //    var content = new StringContent("Your request content here", Encoding.UTF8, "application/json");
        //    var response = await m_HttpClient.PostAsync(redirectUrl, content);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var responseData = await response.Content.ReadAsStringAsync();
        //        return Ok(responseData);
        //    }

        //    return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
        //}













    }
}
