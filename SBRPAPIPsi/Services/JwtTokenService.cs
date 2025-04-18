using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;



namespace SBRPAPIPsi.Services
{
    public class JwtTokenService
    {

        private JwtSettingEntity m_JwtSettings { get; set; }

        public JwtTokenService(
            IOptions<JwtSettingEntity> _jwtSettings)
        {
            m_JwtSettings = _jwtSettings.Value;
        }




        public string GenerateToken(
            WebUserTokenRequestEntity _webUserTokenRequest
            , int _expireMinutes)
        {

            var UserNo = _webUserTokenRequest.UserNo;
            var userName = _webUserTokenRequest.UserName;
            var LoginActionNo = _webUserTokenRequest.LoginActionNo;
            //var roleID = (byte)_webUserTokenRequest.RoleID;
            var UserRoleNo = ((byte)_webUserTokenRequest.UserRoleNo);
            //var roleIdArrayString = _webUserTokenRequest.ToRoleIdArrayString();

            try
            {
                var issuer = m_JwtSettings.Issuer;
                var secretKey = m_JwtSettings.SecretKey;
                var audience = m_JwtSettings.Audience;


                var claims = new[]
                {
                    new Claim(ClaimTypeEnum.UserNo , UserNo.ToString() ),
                    new Claim(ClaimTypeEnum.UserName , userName ),
                    new Claim(ClaimTypeEnum.LoginActionNo , LoginActionNo.ToString()),
                    new Claim(ClaimTypeEnum.UserRoleNo , UserRoleNo.ToString())
                    //new Claim(ClaimTypeEnum.RoleIDArray , roleIdArrayString)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwtToken = new JwtSecurityToken(issuer, audience, claims, expires: DateTime.Now.AddMinutes(_expireMinutes), signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                return token;
            }
            catch (DbUpdateConcurrencyException ex)
            {
               
               
                return string.Empty;
            }
        }








    }
}
