using System.Security.Claims;

namespace SBRPWebPortal.BindingServices
{
    public class UserBindingService
    {
        private readonly IMapper m_Mapper;  
        private readonly UserService m_UserService;
        private readonly IdentityService m_IdentityService;



        public UserBindingService(IMapper _mapper, UserService _userService, IdentityService _identityService)
        {
            m_Mapper = _mapper;
            m_UserService = _userService;
            m_IdentityService = _identityService;
        }





        public ClaimsIdentity SetLoginClaimsIdentity(SBRPBusiness.Models.IdentityClaimEntity _loginClaimInfo)
        {
            return m_IdentityService.SetLoginClaimsIdentity(_loginClaimInfo
                , CookieAuthenticationDefaults.AuthenticationScheme);
        }



        public SBRPBusiness.Models.IdentityClaimEntity GetCurrentLoginClaim(ClaimsPrincipal _httpContextUser)
        {
            return m_IdentityService.GetCurrentLoginClaim(_httpContextUser);
        }



        public AuthenticationProperties SetLoginAuthenticationProperties(int _expireMinutes = 20)
        {
            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(_expireMinutes),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            return authProperties;
        }











        public SBRPData.Models.User? GetEntity(string _loginId, string _passwordHash)
        {
            return m_UserService.GetEntity(_loginId, _passwordHash);
        }
        public async Task<SBRPData.Models.User?> GetEntityAsync(string _loginId, string _passwordHash)
        {
            return await m_UserService.GetEntityAsync(_loginId, _passwordHash);
        }














        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID, short? _passwordFailureAttemptMaxCount = default(short))
        {
            return await m_UserService.LogForPasswordFailureAsync(_loginID, _passwordFailureAttemptMaxCount);
        }





        public async Task LogForLogonAsync(SBRPData.Models.UserLoginToken _info)
        {
            await m_UserService.LogForLogonAsync(_info);
        }









        public async Task ProcessToLogoutAsync(short _userNo)
        {
            await m_UserService.ProcessToLogoutAsync(_userNo);
        }


    }
}
