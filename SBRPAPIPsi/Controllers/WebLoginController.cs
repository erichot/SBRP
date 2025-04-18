
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Antiforgery;


namespace SBRPAPIPsi.Controllers
{
    /// <summary>
    /// API登入作業
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class WebLoginController : ControllerBase
    {

        private readonly JwtTokenService m_JwtToken;

        private readonly AppSettingsModel m_AppSetting;

        private readonly IHttpContextAccessor m_HttpContextAccessor;
        

        public WebLoginController(IHttpContextAccessor httpContextAccessor
            , JwtTokenService jwtToken
            , IOptions<AppSettingsModel> appSetting
            , IAntiforgery _antiforgery
            )
        {
            m_JwtToken = jwtToken;
            m_AppSetting = appSetting.Value;

            m_HttpContextAccessor = httpContextAccessor;
        }






        /// <summary>
        /// 【API作業登入作業】接受來自WebServer的呼叫（透過白名單管控），以取得API Token，由Web Server持有Token（儲存於用戶端cookies）
        /// </summary>
        /// <remarks>
        /// 如果是 ASP.NET Core，要接收 Json 需要指定 [FromBody]，否則收不進來 
        /// </remarks>
        /// <param name="_webUserTokenRequest">登入使用者請求資訊</param>
        /// <returns>
        /// ApiTokenSignInResponseEntity
        /// </returns>
        /// <response code="200">登入成功</response>
        /*
         {
        "AppId": 10,
         "SIGNo": 20,
        "UserNo": 30,
        "UserName":"dafsdfa",
        "Password":"dafsdfa",
        "LoginActionNo":1,
        "UserRoleNo":40,
        "WebToken":"dasdfas"       
        }
         */
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //[ServiceFilter(typeof(ClientIpCheckActionFilter))]
        public async Task<IActionResult> Login(
            [FromBody] WebUserTokenRequestBindingEntity _webUserTokenRequest)
        {            
            var loginActionNo = _webUserTokenRequest.LoginActionNo;
            var userNo = _webUserTokenRequest.UserNo;
            var webToken = _webUserTokenRequest.WebToken;
            IActionResult response = Unauthorized();

            var tokenString = m_JwtToken.GenerateToken(_webUserTokenRequest
                , m_AppSetting.ApiLoginExpireTime);

            var result = new ApiTokenSignInResponseEntity()
            {
                token = tokenString,
                userDetails = (WebUserTokenRequestEntity)_webUserTokenRequest,
            };



            //var tokenSet = m_AntiForgery.GetAndStoreTokens(m_HttpContextAccessor.HttpContext);
            // 將 AntiforgeryTokenSet 中的 RequestToken 設成 Cookie，並指定 HttpOnly 為 false，允許 JavaScript 取出作為 Request Header
            // 註：瀏覽器會自動傳送 Cookie，使用 Header 傳送安全性較高
            //m_HttpContextAccessor.HttpContext.Response.Cookies.Append("XSRF-TOKEN", tokenSet.RequestToken!, new CookieOptions { HttpOnly = false });


            return Ok(result);
        }





    }
}
