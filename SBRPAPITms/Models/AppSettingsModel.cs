using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBRPAPITms.Models
{
    public class AppSettingsModel
    {
       
        public string API_RootUrl { get; set; }

       
        public string WEB_RootUrl { get; set; }

        public int ApiLoginExpireTime { get; set; }

        public int WebLoginExpireTime { get; set; }
    }







    public class SmtpSettingsModel
    {
        public string SenderAddress { get; set; }
        public string SenderName { get; set; }
        public string SmtpServer { get; set; }
        public short Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }






    public class AppLogSettings
    {
        public string ApiAuthLogFileName { get; set; }
        public string ApiLogPath { get; set; }      
    }





    public class MailContentSettings
    {
        public string TemplatePath { get; set; }
        public string PasswordReset { get; set; }
        public string OTPNotification { get; set; }
        public string RegisterConfirmation { get; set; }
    }





    public class AppSystemSettingEntity
    {
        
    }

}
