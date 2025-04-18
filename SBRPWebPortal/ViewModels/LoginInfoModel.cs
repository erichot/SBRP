using System.ComponentModel.DataAnnotations;

namespace SBRPWebPortal.ViewModels
{
    public class LoginInfoModel
    {
        public LoginInfoModel() { }


        public LoginInfoModel(string _appId) 
        {
            AppId = _appId;
        }


        [Required(ErrorMessage = "Please input login ID ")]
        [MaxLength(48)]
        public string LoginId { get; set; }


        [Required(ErrorMessage = "Please input Password")]
        [DataType(DataType.Password)]
        //public string Password { get; set; }
        public string Password { get; set; }



        public string AppId { get; set; }

    }
}
