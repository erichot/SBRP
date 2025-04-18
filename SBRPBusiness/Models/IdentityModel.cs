using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRPBusiness.Models
{
    public class IdentityModel
    {
    }




    public class IdentityClaimEntity
    {
        public IdentityClaimEntity() {  }


        public IdentityClaimEntity(User _userInfo, UserLoginToken _userLoginToken)
        {
            SIGNo = _userInfo.SIGNo;
            UserNo = _userInfo.UserNo;
            UserName = _userInfo.UserName;
            LoginActionNo = _userLoginToken.LoginActionNo;
            UserRoleNo = _userInfo.UserRoleNo;
            UserGroupNo = _userInfo.UserGroupNo;
        }

        public IdentityClaimEntity(User _userInfo, UserLoginToken _userLoginToken, string _apiToken)
        {
            SIGNo = _userInfo.SIGNo;
            UserNo = _userInfo.UserNo;
            UserName = _userInfo.Person?.PersonName??string.Empty;
            LoginActionNo = _userLoginToken.LoginActionNo;
            ApiToken = _apiToken;
            //WebToken = _userLoginToken.WebToken;
            UserRoleNo = _userInfo.UserRoleNo;
            UserGroupNo = _userInfo.UserGroupNo;
            //RoleIdList = _orgUser.ToRoleIdList();
        }


        public byte SIGNo { get; set; }

        public short UserNo { get; set; }

        public string UserName { get; set; }

        public int LoginActionNo { get; set; }

        public string ApiToken { get; set; }     

          
        public short UserRoleNo { get; set; }



        public short? UserGroupNo { get; set; }




        //public IsRoleOfUser GetRoleOfCurrentUser()
        //{
        //    var result = new IsRoleOfUser();

        //    switch (this.RoleNo)
        //    {
        //        case UserRoleEnum.SystemAdministrator:
        //            result.SystemAdministrator = true;
        //            break;

        //        case UserRoleEnum.Supervisor:
        //            result.Supervisor = true;
        //            break;

        //        case UserRoleEnum.Clerk:
        //            result.Clerk = true;
        //            break;

        //        case UserRoleEnum.Sales:
        //            result.Sales = true;
        //            break;
        //    }
        //    return result;

        //}


    }








    public class JwtSettingEntity
    {
        public string Issuer { set; get; }

        public string SecretKey { set; get; }

        public string Audience { set; get; }
    }




    public static class ClaimTypeEnum
    {
        public const string SIGNo = "~SIGNo";
        public const string UserNo = "~UserNo";
        public const string UserName = "~UserName";
        public const string LoginActionNo = "~LoginActionNo";
        public const string ApiToken = "~ApiToken";
        public const string UserRoleNo = "~UserRoleNo";
        public const string UserGroupNo = "~DeptNo";
    }











}
