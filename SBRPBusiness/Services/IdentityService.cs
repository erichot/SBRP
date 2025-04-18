using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Claims;


namespace SBRPBusiness.Services
{
    public class IdentityService
    {


        public IdentityClaimEntity GetCurrentLoginClaim(ClaimsPrincipal _httpContextUser)
        {
            var result = new IdentityClaimEntity()
            {
                SIGNo = default,
                UserNo = default,
                LoginActionNo = default,
                ApiToken = string.Empty,
                UserRoleNo = default
            };

            if (_httpContextUser.Claims != null && _httpContextUser.Claims.Count() > 0)
            {
                var sSIGNo = _httpContextUser.Claims
                   .FirstOrDefault(m => m.Type == ClaimTypeEnum.SIGNo)?.Value;
                if (byte.TryParse(sSIGNo, out byte _sIGNo) == false)
                    return result;

                var sUserNo = _httpContextUser.Claims
                    .FirstOrDefault(m => m.Type == ClaimTypeEnum.UserNo)?.Value;
                if (short.TryParse(sUserNo, out short _userNo) == false)
                    return result;


                var sUserName = _httpContextUser.Claims
                  .FirstOrDefault(m => m.Type == ClaimTypeEnum.UserName)?.Value ?? string.Empty;


                var sLoginActionNo = _httpContextUser.Claims
                    .FirstOrDefault(m => m.Type == ClaimTypeEnum.LoginActionNo)?.Value;
                if (int.TryParse(sLoginActionNo, out int LoginActionNo) == false)
                    return result;


                // NULL when identified from API
                var apiToken = _httpContextUser.Claims
                  .FirstOrDefault(m => m.Type == ClaimTypeEnum.ApiToken)?.Value??string.Empty;


                //UserRoleEnum roleID = UserRoleEnum.Clerk;
                var roleNoText = _httpContextUser.Claims.FirstOrDefault(m => m.Type == ClaimTypeEnum.UserRoleNo)?.Value;
                byte.TryParse(roleNoText, out byte roleNo);
                //Enum.TryParse<UserRoleEnum>(roleName, out var roleID);


              



                //var aaa = Array.ConvertAll(
                //            roleIDArray.Split(","), p => byte.Parse(p)
                //            );
                //var bbb = aaa.OfType<byte>().ToList();


                var loginClaim = new IdentityClaimEntity()
                {
                    SIGNo = _sIGNo,
                    UserNo = _userNo,
                    UserName = sUserName,
                    LoginActionNo = LoginActionNo,
                    ApiToken = apiToken,
                    UserRoleNo = roleNo
                   
                };

                return loginClaim;
            }


            return new IdentityClaimEntity()
            {
                UserNo = default,
                ApiToken = string.Empty,
            };

        }





        public ClaimsIdentity SetLoginClaimsIdentity(IdentityClaimEntity _loginClaimInfo
            , string _authenticationScheme = "Cookies")
        {
            var sSIGNo = _loginClaimInfo.SIGNo.ToString();
            var sUserNo = _loginClaimInfo.UserNo.ToString();
            var sUserName = _loginClaimInfo.UserName;
            var sLoginActionNo = _loginClaimInfo.LoginActionNo.ToString();
            var apiToken = _loginClaimInfo.ApiToken??string.Empty;
            var roleNo = _loginClaimInfo.UserRoleNo;
            //var roleIdArray = _loginClaimInfo.ToRoleIdArrayString();

            var claims = new List<Claim>
                        {
                            new Claim(ClaimTypeEnum.SIGNo, sSIGNo),
                            new Claim(ClaimTypeEnum.UserNo, sUserNo),
                            new Claim(ClaimTypeEnum.UserName, sUserName),
                            new Claim(ClaimTypeEnum.LoginActionNo, sLoginActionNo),
                            new Claim(ClaimTypeEnum.ApiToken, apiToken),
                            new Claim(ClaimTypeEnum.UserRoleNo, roleNo.ToString())
                            //new Claim(ClaimTypeEnum.RoleIDArray, roleIdArray)
                        };


            //var claimsIdentity = new ClaimsIdentity(
            //    claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsIdentity = new ClaimsIdentity(
                claims, _authenticationScheme);

            return claimsIdentity;
        }















    }
}
