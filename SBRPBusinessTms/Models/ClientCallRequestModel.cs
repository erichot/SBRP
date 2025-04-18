using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Diagnostics.CodeAnalysis;



namespace SBRPBusinessTms.Models
{
    public class ClientCallRequestModel
    {
        public const string HttpClientName = "APIHttpClientName";

        public const string API_PATH_WebLogin = "api/WebLogin";
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
        
        public int UserSID { get; set; }
        
        public string UserName { get; set; }

        public string Password { get; set; }

        public int LoginActionSN { get; set; }

        public string WebToken { get; set; }

        // Fortify0804_ClientCallRequestModel.cs, line 55 (Mass Assignment: Sensitive Field Exposure
        //JsonException: The JSON value could not be converted to BOPCMSData.Models.UserRoleEnum. Path: $.userDetails.RoleID | LineNumber: 0 | BytePositionInLine: 399.        
        //public byte RoleID { get; set; }
        public byte RroolleeID { get; set; }


        //[AllowNull]
        //public List<byte> RoleIdList { get; set; }       

        //public string ToRoleIdArrayString()
        //{
        //    var roleIdArrayString = string.Empty;
        //    if (RoleIdList != null)
        //        roleIdArrayString = string.Join(",", RoleIdList.ToArray());

        //    return roleIdArrayString;
        //}
    }



   











}
