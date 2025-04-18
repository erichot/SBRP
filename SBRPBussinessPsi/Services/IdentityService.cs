using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;

namespace SBRPBussinessPsi.Services
{
    public class IdentityService
    {
        private readonly CommonDbContext m_CommonDbContext;
        private readonly SBRPBusiness.Services.IdentityService m_IdentityService;

        public IdentityService(CommonDbContext commonDbContext)
        {
            m_CommonDbContext = commonDbContext;
            m_IdentityService = new SBRPBusiness.Services.IdentityService();
        }



        public IdentityClaimEntity GetCurrentLoginClaim(ClaimsPrincipal _httpContextUser)
        {
            return m_IdentityService.GetCurrentLoginClaim(_httpContextUser);
        }





        public ClaimsIdentity SetLoginClaimsIdentity(IdentityClaimEntity _loginClaimInfo
            , string _authenticationScheme = "Cookies")
        {
            return m_IdentityService.SetLoginClaimsIdentity(_loginClaimInfo, _authenticationScheme);
        }















    }
}
