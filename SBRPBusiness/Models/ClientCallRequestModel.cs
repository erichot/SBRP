using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;





namespace SBRPBusiness.Models
{
    public class ClientCallRequestModel
    {
        public const string HttpClientName = "APIHttpClientName";

        public const string API_PATH_WebLogin = "api/WebLogin";
    }








    public class SsoRedirectRequestModel
    {
        public string loginId { get; set; }
        public string webToken { get; set; }
        public string redirectUrl { get; set; }
    }



    //public class UserProfileRequest
    //{
    //    public string Token { get; set; }

    //    public int UserNo { get; set; }
    //}





    public class ApiTokenSignInResponseEntity
    {
        public string token { get; set; }
        public WebUserTokenRequestEntity userDetails { get; set; }
    }




    public class WebUserTokenRequestEntity
    {
        //SBRP_AppIdEnum
        public byte AppId { get; set; }

        public byte SIGNo { get; set; }

        public short UserNo { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }

        public int LoginActionNo { get; set; }

        public string WebToken { get; set; }

        public short UserRoleNo { get; set; }

        public short UserGroupNo { get; set; }       
    }



   











}
