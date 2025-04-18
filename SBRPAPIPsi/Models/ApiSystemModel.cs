using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace SBRPAPIPsi.Models
{
    public class ApiSystemModel
    {
    }


    public static class ApiSystem
    {
        public const string CD_NonBreakingSpace = "\xA0";






        public static string ComposeIdAndName(string _id, string _name)
        {
            _id = _id.Trim();

            var byteCount = Encoding.Default.GetByteCount(_id);
            string separatorText = string.Empty;
            if (byteCount < 20)
            {
                var repeatCount = 17 - byteCount;
                separatorText = CD_NonBreakingSpace.Repeat(repeatCount);
            }
            return $"{_id}{separatorText}{_name}";
        }
    }




    public static class ApiStatusCode
    {
        // 403 Forbidden    Unauthorized request. The client does not have access rights to the content. Unlike 401, the client’s identity is known to the server
        public const int ForbidOnGeneralAccess = 403;


        // 404 Not Found    The server can not find the requested resource.
        public const int NoFoundOnGetProfile = 404;

        public const int MethodNotAllowed = 405;

        public const int NotAcceptable = 406;


        // Duplicated   The request could not be completed due to a conflict with the current state of the resource
        public const int Conflict = 409;


        // The 422 (Unprocessable Entity) status code means the server understands the content type of the request entity (hence a 415(Unsupported Media Type) status code is inappropriate), and the syntax of the request entity is correct (thus a 400 (Bad Request) status code is inappropriate) but was unable to process the contained instructions
        // validation errors
        public const int UnprocessableEntity = 422;


        public const int InternalServerError = 500;

    }







    public class ApiErrorMessageResponeEntity
    {
        public ApiErrorMessageResponeEntity() { }

        public ApiErrorMessageResponeEntity(string _message)
        {
            Message = _message;
        }


        public string Message { get; set; }
        public string Detail { get; set; }
    }








    [BindRequired]
    public class WebUserTokenRequestBindingEntity: WebUserTokenRequestEntity
    {

        

    }


}
