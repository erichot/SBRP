namespace SBRPWebPortal.Models
{
    public class AppSettingsModel
    {
        public string Portal_WEB_RootUrl { get; set; }



        // 以web client broswer 的角度來解析API url
        public string PSI_API_RootUrl { get; set; }

        // 以Web的角度來解析API url
        public string PSI_API_FromWeb_RootUrl { get; set; }

        public string PSI_WEB_RootUrl { get; set; }



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





}
