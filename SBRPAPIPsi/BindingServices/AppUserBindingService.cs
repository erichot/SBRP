using System.Security.Claims;

namespace SBRPAPIPsi.BindingServices
{
    public class AppUserBindingService
    {
        private readonly IMapper m_Mapper;
        private readonly IdentityService m_IdentityService;
        private readonly AppUserService m_AppUserService;

        public AppUserBindingService(IMapper mapper, IdentityService identityService, AppUserService appUserService)
        {
            m_Mapper = mapper;
            m_IdentityService = identityService;
            m_AppUserService = appUserService;
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











        //public AppUser? GetEntity(string _loginId, string _passwordHash)
        //{
        //    return m_AppUserService.GetEntity(_loginId, _passwordHash);
        //}
        //public async Task<AppUser?> GetEntityAsync(string _loginId, string _passwordHash)
        //{
        //    return await m_AppUserService.GetEntityAsync(_loginId, _passwordHash);
        //}

        public AppUserBindingModel? GetEntity(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<AppUserBindingModel>(
                m_AppUserService.GetEntity(_userNo, _enableTracking, _includeDetails)
                );
        }
        public async Task<AppUserBindingModel?> GetEntityAsync(short _userNo, bool _enableTracking = false, bool _includeDetails = true)
        {
            return m_Mapper.Map<AppUserBindingModel>(
                await m_AppUserService.GetEntityAsync(_userNo, _enableTracking, _includeDetails)
                );
        }


        public AppUserBindingModel? GetEntity(string _loginId, string _passwordHash)
        {
            return m_Mapper.Map<AppUserBindingModel>(
                m_AppUserService.GetEntity(_loginId, _passwordHash)
                );
        }
        public async Task<AppUserBindingModel?> GetEntityAsync(string _loginId, string _passwordHash)
        {
            return m_Mapper.Map<AppUserBindingModel>(
                await m_AppUserService.GetEntityAsync(_loginId, _passwordHash)
                );
        }













        public async Task<SBRPData.Models.User?> LogForPasswordFailureAsync(string _loginID, short? _passwordFailureAttemptMaxCount = default(short))
        {
            return await m_AppUserService.LogForPasswordFailureAsync(_loginID, _passwordFailureAttemptMaxCount);
        }





        public async Task LogForLogonAsync(SBRPData.Models.UserLoginToken _info)
        {
            await m_AppUserService.LogForLogonAsync(_info);
        }









        public async Task ProcessToLogoutAsync(short _userNo)
        {
            await m_AppUserService.ProcessToLogoutAsync(_userNo);
        }




    }
}
